using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Arcas.BL.TFS;
using Cav;
using Cav.Tfs;
using Cav.WinForms.BaseClases;

namespace Arcas.Settings
{
    public partial class CreateSettingUpdater : DialogFormBase
    {
        private class ErrorTracker
        {
            private HashSet<Control> mErrors = new HashSet<Control>();
            private ErrorProvider mProvider;

            public ErrorTracker(ErrorProvider provider)
            {
                mProvider = provider;
            }
            public void SetError(Control ctl, string text)
            {
                if (string.IsNullOrEmpty(text))
                    mErrors.Remove(ctl);
                else
                    if (!mErrors.Contains(ctl))
                    mErrors.Add(ctl);
                mProvider.SetError(ctl, text);
            }
            public int Count { get { return mErrors.Count; } }

            public override string ToString()
            {
                if (!mErrors.Any())
                    return null;

                return mErrors.Select(x => mProvider.GetError(x)).JoinValuesToString(Environment.NewLine);
            }
        }

        private class DbTypeItem
        {
            public Type ConType { get; set; }
            public byte[] AssembyRawBytes { get; set; }
            public AssemblyName AssembyNameFile { get; set; }
            public override string ToString()
            {
                if (ConType == null)
                    return "<Добавить сборку>";
                return ConType.ToString();
            }
        }

        public CreateSettingUpdater()
        {
            InitializeComponent();

            errorTracker = new ErrorTracker(errorProvider);

            cmbDbConectionType.Items.Add(new DbTypeItem() { ConType = typeof(SqlConnection) });
            cmbDbConectionType.Items.Add(new DbTypeItem());
            cmbDbConectionType.SelectedIndex = 0;

            ValidateAll();
        }

        public TFSDBList ItemsInSets { get; set; }


        private ErrorTracker errorTracker = null;
        private WrapTfs wrapTfs = new WrapTfs();
        private TfsDbLink editLink = null;


        private UpdateDbSetting dbSettingGet(DbTypeItem dbItem)
        {
            return new UpdateDbSetting()
            {
                ServerPathScripts = tbFolderForScripts.Text,
                TypeConnectionFullName = dbItem.ConType.ToString(),
                AssemplyWithImplementDbConnection = dbItem.AssembyRawBytes,
                ConnectionStringModelDb = tbConnectionString.Text,
                ScriptPartBeforeBodyWithTran = tbPartBeforescript.Text.GetNullIfIsNullOrWhiteSpace(),
                ScriptPartAfterBodyWithTran = tbPartAfterScript.Text.GetNullIfIsNullOrWhiteSpace(),
                ScriptUpdateVer = tbScriptUpdateVer.Text.GetNullIfIsNullOrWhiteSpace(),
                FormatBinary = new FormatBinaryData()
                {
                    Prefix = tbFormatBinPrefix.Text,
                    FormatByte = tbFormatBinFormat.Text
                }
            };
        }


        private void dbSettingLoad(UpdateDbSetting upsets)
        {
            if (upsets == null || upsets.ServerPathScripts.IsNullOrWhiteSpace())
            {
                throw new Exception("Получение файла настроек неуспешно");
            }

            Type conn = typeof(SqlConnection);
            Boolean useSqlConnection = true;

            if (upsets.TypeConnectionFullName != conn.ToString())
            {
                if (upsets.AssemplyWithImplementDbConnection == null)
                    throw new Exception($"В настроках указан тип DbConnection '{upsets.TypeConnectionFullName}', но отсутствует бинарное представление сборки реализации");

                conn = null;
                Assembly conAss = null;

                foreach (var asmly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    conn = asmly.GetType(upsets.TypeConnectionFullName, false);

                    if (conn != null)
                    {
                        conAss = asmly;
                        break;
                    }
                }

                if (conn == null)
                    conAss = AppDomain.CurrentDomain.Load(upsets.AssemplyWithImplementDbConnection);

                conn = conAss.ExportedTypes.FirstOrDefault(x => x.FullName == upsets.TypeConnectionFullName);

                if (conn == null)
                    throw new Exception($"Не удалось найти тип DbConnection '{upsets.TypeConnectionFullName}'");
                useSqlConnection = false;
            }

            tbFolderForScripts.Text = upsets.ServerPathScripts;
            tbConnectionString.Text = upsets.ConnectionStringModelDb;
            tbPartBeforescript.Text = upsets.ScriptPartBeforeBodyWithTran;
            tbPartAfterScript.Text = upsets.ScriptPartAfterBodyWithTran;
            tbScriptUpdateVer.Text = upsets.ScriptUpdateVer;

            var formatBin = upsets.FormatBinary ?? new FormatBinaryData();
            tbFormatBinPrefix.Text = formatBin.Prefix;
            tbFormatBinFormat.Text = formatBin.FormatByte;

            if (!useSqlConnection)
            {
                var item = new DbTypeItem();
                item.AssembyRawBytes = upsets.AssemplyWithImplementDbConnection;
                item.ConType = conn;
                item.AssembyNameFile = conn.Assembly.GetName();

                cmbDbConectionType.Items.Insert(cmbDbConectionType.Items.Count - 1, item);
                cmbDbConectionType.SelectedItem = item;
            }

            ValidateAll();
        }

        public void EditedSet(TfsDbLink tfsDbLinckSet)
        {
            editLink = tfsDbLinckSet;
            if (
                editLink == null ||
                editLink.Name.IsNullOrWhiteSpace() ||
                editLink.ServerUri == null ||
                editLink.ServerUri.AbsolutePath.IsNullOrWhiteSpace()
                )
                return;

            tbTfsProject.Text = editLink.ServerUri.OriginalString;
            tbSettingName.Text = editLink.Name;

            ValidateAll();

            if (editLink.ServerPathToSettings.IsNullOrWhiteSpace())
                return;

            String tempfile = null;
            try
            {
                UpdateDbSetting upsets = null;
                using (TFSRoutineBL tfsbl = new TFSRoutineBL())
                {
                    tfsbl.VersionControl(editLink.ServerUri);

                    tempfile = Path.Combine(DomainContext.TempPath, Guid.NewGuid().ToString());
                    tfsbl.DownloadFile(editLink.ServerPathToSettings, tempfile);
                }

                try
                {

                    var revStr = new String(editLink.ServerPathToSettings.Reverse().ToArray());
                    var revFileName = revStr.SubString(0, revStr.IndexOf("/"));
                    var revServPath = revStr.SubString(revStr.IndexOf("/") + 1);
                    tbSetFileServerFolder.Text = new String(revServPath.Reverse().ToArray());
                    tbFileNameSet.Text = new String(revFileName.Reverse().ToArray());

                    upsets = File.ReadAllBytes(tempfile).DeserializeAesDecrypt<UpdateDbSetting>(editLink.ServerPathToSettings);
                }
                catch (Exception ex)
                {
                    String msg = ex.Expand();
                    if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                        msg = ex.InnerException.Message;
                    throw new Exception("Получение файла настроек неуспешно. Exception: " + msg);
                }

                dbSettingLoad(upsets);

                tbFileNameSet.ReadOnly = true;
                btPathFoldertoFileSet.Enabled = false;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (!tempfile.IsNullOrWhiteSpace() || File.Exists(tempfile))
                    File.Delete(tempfile);
            }
        }

        #region валидаторы

        private void ValidateAll()
        {
            tbSettingName_Validating(null, null);
            tbSetFileName_Validating(null, null);
            tbSetFileServerFolder_Validating(null, null);
            tbFolderForScripts_Validating(null, null);
            tbConnectionString_Validating(null, null);
            tbFormatBinPrefix_Validating(null, null);
            tbFormatBinFormat_Validating(null, null);
        }

        private void tbSettingName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbSettingName.Text.IsNullOrWhiteSpace())
            {
                errorTracker.SetError(tbSettingName, "Не указано наименование связки");
                return;
            }

            var exstSet = ItemsInSets.FirstOrDefault(x => x.Name == tbSettingName.Text);
            if (exstSet != editLink)
            {
                errorTracker.SetError(tbSettingName, "Наименование должно быть уникальным");
                return;
            }

            errorTracker.SetError(tbSettingName, "");
        }

        private void tbSetFileName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbFileNameSet.Text.IsNullOrWhiteSpace())
                errorTracker.SetError(tbFileNameSet, "Не указано наименование файла настроек");
            else
                errorTracker.SetError(tbFileNameSet, null);


            tbFileNameSet.Text = tbFileNameSet.Text.ReplaceInvalidPathChars();
        }

        private void tbSetFileServerFolder_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbSetFileServerFolder.Text.IsNullOrWhiteSpace())
                errorTracker.SetError(tbSetFileServerFolder, "Не указан путь сохранения файла настроек на сервере");
            else
                errorTracker.SetError(tbSetFileServerFolder, null);
        }

        private void tbFolderForScripts_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbFolderForScripts.Text.IsNullOrWhiteSpace())
                errorTracker.SetError(tbFolderForScripts, "Не указан путь сохранения скриптов на сервере");
            else
                errorTracker.SetError(tbFolderForScripts, null);
        }

        private void tbConnectionString_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbConnectionString.Text.IsNullOrWhiteSpace())
                errorTracker.SetError(tbConnectionString, "Не указана строка соединения с модельной БД");
            else
                errorTracker.SetError(tbConnectionString, null);

            btChekConnection.Enabled = !tbConnectionString.Text.IsNullOrWhiteSpace();
            if (btChekConnection.Enabled)
                errorTracker.SetError(btChekConnection, "Необходимо проверить строку соединения");
        }

        private void tbFormatBinPrefix_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbFormatBinPrefix.Text.IsNullOrWhiteSpace())
                errorTracker.SetError(tbFormatBinPrefix, "Не указан префикс для построения строки представления бинарных данных");
            else
                errorTracker.SetError(tbFormatBinPrefix, null);

        }

        private void tbFormatBinFormat_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbFormatBinFormat.Text.IsNullOrWhiteSpace())
                errorTracker.SetError(tbFormatBinFormat, "Не указан формат для построения строки представления бинарных данных");
            else
                errorTracker.SetError(tbFormatBinFormat, null);
        }

        #endregion

        private void btPathFoldertoFileSet_Click(object sender, EventArgs e)
        {
            var vc = wrapTfs.VersionControlServerGet(new Uri(tbTfsProject.Text));
            var folder = wrapTfs.ShowDialogChooseServerFolder(this, vc, null);
            tbSetFileServerFolder.Text = folder;
            tbSetFileServerFolder_Validating(null, null);
        }

        private void cmbDbConectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDbConectionType.SelectedIndex < 0)
                return;

            DbTypeItem selItem = (DbTypeItem)cmbDbConectionType.SelectedItem;

            if (selItem.ConType != null)
            {
                tbConnectionString_Validating(null, null);
                return;
            }

            var filePathAssembly = Dialogs.FileBrowser(
                    Owner: this,
                    Title: "Выбор сборки с реализацией DbConnection",
                    DefaultExt: ".ddl",
                    Filter: "Assemblys dll|*.dll",
                    AddExtension: false).FirstOrDefault();

            if (filePathAssembly.IsNullOrWhiteSpace())
            {
                cmbDbConectionType.SelectedIndex = 0;
                return;
            }

            Assembly fileAssembly = null;
            byte[] fileAssemblyRaw = null;

            try
            {
                var assName = AssemblyName.GetAssemblyName(filePathAssembly);

                fileAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName == assName.FullName);
                fileAssemblyRaw = File.ReadAllBytes(filePathAssembly);

                if (fileAssembly == null)
                    fileAssembly = Assembly.LoadFile(filePathAssembly);
                else
                {
                    var setItem = cmbDbConectionType.Items.Cast<DbTypeItem>().FirstOrDefault(x => x.AssembyNameFile != null && x.AssembyNameFile.FullName == assName.FullName);
                    if (setItem != null)
                    {
                        cmbDbConectionType.SelectedItem = setItem;
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                Dialogs.ErrorF(this, ex.Expand());
                cmbDbConectionType.SelectedIndex = 0;
                return;
            }

            foreach (var asType in fileAssembly.ExportedTypes.Where(x => x.IsSubclassOf(typeof(DbConnection))))
            {
                var item = new DbTypeItem();
                item.ConType = asType;
                item.AssembyRawBytes = fileAssemblyRaw;
                item.AssembyNameFile = fileAssembly.GetName();
                cmbDbConectionType.Items.Insert(cmbDbConectionType.Items.Count - 1, item);
                cmbDbConectionType.SelectedItem = item;
            }

            if (cmbDbConectionType.SelectedItem == selItem)
                cmbDbConectionType.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var vc = wrapTfs.VersionControlServerGet(new Uri(tbTfsProject.Text));
            var folder = wrapTfs.ShowDialogChooseServerFolder(this, vc, null);
            tbFolderForScripts.Text = folder;
            tbFolderForScripts_Validating(null, null);

        }

        private void btChekConnection_Click(object sender, EventArgs e)
        {
            DbTypeItem selitem = (DbTypeItem)cmbDbConectionType.SelectedItem;

            String context = tbConnectionString.Text;

            try
            {
                DomainContext.InitConnection(selitem.ConType, context);
                Dialogs.InformationF(this, "Тест соединения успешен.");
            }
            catch (Exception ex)
            {
                Dialogs.ErrorF(this, ex.Expand());
                errorTracker.SetError(btChekConnection, "Проверка строки соединения неуспешна");
                return;
            }

            errorTracker.SetError(btChekConnection, null);
        }

        private void tbNumberTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar);
        }

        private void CreateSettingUpdater_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((e.CloseReason != CloseReason.UserClosing & e.CloseReason != CloseReason.None) ||
                this.DialogResult != DialogResult.OK)
                return;

            if (errorTracker.Count != 0)
            {
                Dialogs.ErrorF(this, errorTracker.ToString());
                e.Cancel = true;

                if (editLink != null)
                    ItemsInSets.Add(editLink);
                return;
            }

            int? taskId = null;
            int tid;
            if (int.TryParse(tbNumberTask.Text, out tid))
                taskId = tid;

            // формируем настройку для получения настроек
            TfsDbLink newLink = editLink ?? new TfsDbLink();
            newLink.Name = tbSettingName.Text;
            newLink.ServerUri = new Uri(tbTfsProject.Text);
            newLink.ServerPathToSettings = tbSetFileServerFolder.Text + "/" + tbFileNameSet.Text;

            var encodedSetting = dbSettingGet((DbTypeItem)cmbDbConectionType.SelectedItem).SerializeAesEncrypt(newLink.ServerPathToSettings);

            string fileNameSet = tbFileNameSet.Text;

            try
            {
                using (var tfsbl = new TFSRoutineBL())
                {
                    var localFileSetPath = Path.Combine(tfsbl.Tempdir, fileNameSet);

                    tfsbl.VersionControl(new Uri(tbTfsProject.Text));
                    tfsbl.MapTempWorkspace(tbSetFileServerFolder.Text);

                    tfsbl.GetLastFile(fileNameSet);

                    var fileExist = File.Exists(localFileSetPath);

                    if (fileExist && !tfsbl.CheckOut(localFileSetPath))
                        throw new Exception("Извлечение настроек неуспешно. Повторите позже");

                    // блокируем от изменений
                    if (fileExist && !tfsbl.LockFile(fileNameSet))
                        throw new Exception("Производится сохранение настроек другим пользователем.");

                    // если есть - удаляем
                    if (fileExist)
                        File.Delete(localFileSetPath);

                    // записываем новый
                    File.WriteAllBytes(localFileSetPath, encodedSetting);

                    if (!fileExist)
                        tfsbl.AddFile(localFileSetPath);

                    List<int> linkedTask = new List<int>();
                    if (taskId.HasValue)
                        linkedTask.Add(taskId.Value);
                    tfsbl.CheckIn("Добавленение настроек версионности", linkedTask);
                }

                if (editLink == null)
                    this.ItemsInSets.Add(newLink);
            }
            catch (Exception ex)
            {
                String msg = ex.Expand();
                if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                    msg = ex.InnerException.Message;
                Dialogs.ErrorF(this, "Сохранение неуспешно" + Environment.NewLine + msg);
                e.Cancel = true;
            }
        }

        private void tbConnectionString_TextChanged(object sender, EventArgs e)
        {
            tbConnectionString_Validating(null, null);
        }

        private void export_Click(object sender, EventArgs e)
        {
            try
            {
                var expFile = Dialogs.SaveFile(Owner: this, FileName: "rollUpDb.xml");

                if (expFile.IsNullOrWhiteSpace())
                    return;

                if (File.Exists(expFile))
                    File.Delete(expFile);

                dbSettingGet((DbTypeItem)cmbDbConectionType.SelectedItem).XMLSerialize(expFile);
            }
            catch (Exception ex)
            {
                Dialogs.ErrorF(this, "Экспорт неуспешен " + ex.Expand());
                return;
            }
        }

        private void import_Click(object sender, EventArgs e)
        {
            try
            {
                var expFile = Dialogs.FileBrowser(Owner: this, FileName: "rollUpDb.xml").FirstOrDefault();

                if (expFile.IsNullOrWhiteSpace())
                    return;

                dbSettingLoad(expFile.XMLDeserializeFromFile<UpdateDbSetting>());

                tbFileNameSet.ReadOnly = false;
                btPathFoldertoFileSet.Enabled = true;
            }
            catch (Exception ex)
            {
                Dialogs.ErrorF(this, "Импорт неуспешен: " + ex.Expand());
                return;
            }
        }
    }
}
