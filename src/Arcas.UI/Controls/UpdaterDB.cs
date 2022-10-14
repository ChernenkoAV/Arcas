using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Arcas.BL;
using Arcas.BL.TFS;
using Arcas.Settings;
using Cav;

namespace Arcas.Controls
{
    public partial class UpdaterDB : TabControlBase
    {
        public UpdaterDB()
        {
            InitializeComponent();
            Text = "Накатка БД";
        }

        private Boolean textChanged = true;
        private FormatBinaryData formatbin = null;

        private void btSaveScript_Click(object sender, EventArgs e)
        {
            if (!textChanged)
                if (!Dialogs.QuestionOKCancelF(this, "Текст скрипта не изменился с предыдущего запуска. Повторить?"))
                    return;

            String msg = null;

            btSaveScript.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            var savbl = new TfsDBSaveBL();
            savbl.StatusMessages += savbl_StatusMessages;
            try
            {
                if (savbl.ChekExistsShelveset((TfsDbLink)cbxTfsDbLinc.SelectedItem) &&
                    Dialogs.QuestionOKCancelF(this, "В шельве присутствуют несохраненные изменения. Удалить?"))
                    savbl.DeleteShelveset((TfsDbLink)cbxTfsDbLinc.SelectedItem);
            }
            catch (Exception ex)
            {
                msg = ex.Expand();
                if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                    msg = ex.InnerException.Message;
            }

            var taskIds = lbLinkedWirkItem.Items.Cast<Lwi>().Select(x => x.ID).ToList();

            if (msg.IsNullOrWhiteSpace())
                msg = savbl.SaveScript(
                    (TfsDbLink)cbxTfsDbLinc.SelectedItem,
                    rtbScriptBody.Text,
                    tbComment.Text,
                    chbTransaction.Checked,
                    taskIds);
            if (msg.IsNullOrWhiteSpace())
                Dialogs.InformationF(this, "Успешно");
            else
                Dialogs.ErrorF(this, msg);

            textChanged = false;
            btSaveScript.Enabled = true;
            savbl_StatusMessages(String.Empty);

            Config.Instance.UpdaterDb.SelestedTFSDB = cbxTfsDbLinc.Text;
            Config.Instance.UpdaterDb.Comment = tbComment.Text;
            Config.Instance.UpdaterDb.Script = rtbScriptBody.Text;
            Config.Instance.UpdaterDb.Tasks = taskIds;
            Config.Instance.Save();

            Cursor.Current = Cursors.Default;
        }

        private void savbl_StatusMessages(string message) =>
            SetSateProgress(message);

        public override void CloseApp()
        {
            Config.Instance.UpdaterDb.SelestedTFSDB = cbxTfsDbLinc.Text;
            Config.Instance.UpdaterDb.Comment = tbComment.Text;
            Config.Instance.UpdaterDb.Script = rtbScriptBody.Text;
            Config.Instance.UpdaterDb.Tasks = lbLinkedWirkItem.Items.Cast<Lwi>().Select(x => x.ID).ToList();
        }

        public override void RefreshTab()
        {
            AssemblyResolver.AddResolver();

            if (Config.Instance.UpdaterDb == null)
                Config.Instance.UpdaterDb = new UpdaterDbSetting();

            var selName = Config.Instance.UpdaterDb.SelestedTFSDB ?? Config.Instance.SelestedTFSDB;

            if (Config.Instance.UpdaterDb.TfsDbSets == null || !Config.Instance.UpdaterDb.TfsDbSets.Any())
                Config.Instance.UpdaterDb.TfsDbSets = Config.Instance.TfsDbSets;
            cbxTfsDbLinc.DataSource = Config.Instance.UpdaterDb.TfsDbSets
            ;
            if (cbxTfsDbLinc.DataSource != null)
                cbxTfsDbLinc.SelectedItem = ((List<TfsDbLink>)cbxTfsDbLinc.DataSource).FirstOrDefault(x => x.Name == selName);
            if (cbxTfsDbLinc.SelectedItem == null && cbxTfsDbLinc.Items.Count > 0)
                cbxTfsDbLinc.SelectedIndex = 0;

            tbComment.Text = Config.Instance.UpdaterDb.Comment;
            rtbScriptBody.Text = Config.Instance.UpdaterDb.Script;

            addTaskOnIds(Config.Instance.UpdaterDb.Tasks);

            cbxTfsDbLinc_SelectionChangeCommitted(null, null);
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbComment.Text = null;
            rtbScriptBody.Text = null;
            lbLinkedWirkItem.Items.Clear();
        }

        private void bttvQueryRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                tvQuerys.Nodes.Clear();

                if (!(cbxTfsDbLinc.SelectedItem is TfsDbLink curset) || curset.ServerUri == null || curset.ServerPathToSettings.IsNullOrWhiteSpace())
                {
                    bttvQueryRefresh.Enabled = false;
                    return;
                }

                var qs = TfsRoutineBL.QueryItemsGet(curset.ServerUri, curset.ServerPathToSettings);

                Action<QueryItemNode, TreeNode> recNod = null;
                recNod = new Action<QueryItemNode, TreeNode>((qn, tn) =>
                    {
                        tn.Text = qn.Name;
                        tn.Tag = qn;
                        tn.StateImageIndex = 0;
                        if (!qn.IsFolder)
                            tn.StateImageIndex = 1;

                        foreach (var cqin in qn.ChildNodes)
                        {
                            var tnod = new TreeNode();
                            recNod(cqin, tnod);
                            tn.Nodes.Add(tnod);
                        }
                    });

                foreach (var qin in qs)
                {
                    var tnod = new TreeNode();
                    recNod(qin, tnod);
                    tvQuerys.Nodes.Add(tnod);
                }

                if (tvQuerys.Nodes.Count == 1)
                    tvQuerys.Nodes[0].Expand();
            }
            catch (Exception ex)
            {
                var exMsg = ex.Expand();
                if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                    exMsg = ex.InnerException.Message;
                Dialogs.ErrorF(this, exMsg);
            }
        }

        private void tvQuerys_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                lbWorkItems.Items.Clear();

                if (!(cbxTfsDbLinc.SelectedItem is TfsDbLink curset))
                    return;

                if (curset.ServerUri == null)
                {
                    Dialogs.InformationF(this, "В настройках связки не указан сервер TFS");
                    return;
                }

                var qin = (QueryItemNode)e.Node.Tag;

                if (qin.IsFolder)
                    return;

                var wims = TfsRoutineBL.WorkItemsFromQueryGet(curset.ServerUri, qin);
                foreach (var wi in wims)
                    lbWorkItems.Items.Add(new Lwi() { ID = wi.Key, Title = wi.Value });
            }
            catch (Exception ex)
            {
                var exMsg = ex.Expand();
                if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                    exMsg = ex.InnerException.Message;
                Dialogs.ErrorF(this, exMsg);
            }
        }

        private class Lwi
        {
            public int ID { get; set; }
            public String Title { get; set; }
            public override string ToString() =>
                $"({ID}) {Title}";
        }

        private void btAddWorkItem_Click(object sender, EventArgs e)
        {
            foreach (Lwi item in lbWorkItems.SelectedItems)
            {
                var si = item;

                if (lbLinkedWirkItem.Items.Cast<Lwi>().Any(x => x.ID == si.ID))
                    continue;
                lbLinkedWirkItem.Items.Add(si);
            }

            lbWorkItems.SelectedItems.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) =>
            e.Handled = !char.IsDigit(e.KeyChar);

        private void addTaskOnIds(IEnumerable<int> taskIds)
        {
            if (taskIds == null)
                return;

            try
            {
                if (!(cbxTfsDbLinc.SelectedItem is TfsDbLink curset))
                    return;

                foreach (var tskId in taskIds)
                {
                    if (lbLinkedWirkItem.Items.Cast<Lwi>().Any(x => x.ID == tskId))
                        continue;

                    if (curset.ServerUri == null)
                    {
                        Dialogs.InformationF(this, "В настройках связки не указан сервер TFS");
                        return;
                    }

                    var title = TfsRoutineBL.TitleWorkItemByIdGet(curset.ServerUri, tskId);
                    if (title.IsNullOrWhiteSpace())
                        return;

                    lbLinkedWirkItem.Items.Add(new Lwi() { ID = tskId, Title = title });
                }
            }
            catch (Exception ex)
            {
                var exMsg = ex.Expand();
                if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                    exMsg = ex.InnerException.Message;
                Dialogs.ErrorF(this, exMsg);
            }
        }

        private void btAddInIDTask_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbIdTask.Text, out var idTask))
                return;

            addTaskOnIds(new[] { idTask });

            tbIdTask.Text = null;
        }

        private void lbLinkedWirkItem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            deleteToolStripMenuItem_Click(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in lbLinkedWirkItem.SelectedItems.Cast<Object>().ToArray())
                lbLinkedWirkItem.Items.Remove(item);
        }

        private void lbLinkedWirkItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            if (lbLinkedWirkItem.SelectedItems.Count == 0)
                return;
            cmsLinkedWorkItems.Show(Cursor.Position);
        }

        private void btTfsDbLinkSettings_Click(object sender, EventArgs e)
        {
            new TFSDBLinkForm().ShowDialog(this);
            RefreshTab();
        }

        private void tbScriptBody_TextChanged(object sender, EventArgs e) =>
            textChanged = true;

        private void cbxTfsDbLinc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btSaveScript.Enabled = false;
            formatbin = null;
            panelScript.Enabled = false;
            panelTfsWorkItems.Enabled = false;

            if (cbxTfsDbLinc.SelectedItem is TfsDbLink curset)
                if (!curset.ServerPathToSettings.IsNullOrWhiteSpace() & curset.ServerUri != null)
                    if (!bwRequestTfs.IsBusy)
                        bwRequestTfs.RunWorkerAsync(curset);
        }

        private void tsmiClearScriptText_Click(object sender, EventArgs e) =>
            rtbScriptBody.Text = null;

        private int posCurscript = 0;

        private void cmsScriptArea_Opening(object sender, CancelEventArgs e)
        {
            tsmiClearScriptText.Enabled = !rtbScriptBody.Text.IsNullOrWhiteSpace();
            tsmiTextSelectDelete.Enabled =
            tsmiTextSelectCopy.Enabled =
            tsmiTextSelectCute.Enabled =
            rtbScriptBody.SelectionLength != 0;
            tsmiPasteText.Enabled = Clipboard.ContainsText();
            posCurscript = rtbScriptBody.SelectionStart;
            tsmiInsertBinfile.Enabled = formatbin != null;

        }

        private void tsmiInsertBinfile_Click(object sender, EventArgs e)
        {
            try
            {
                var fmbn = formatbin ?? new FormatBinaryData();
                if (fmbn.FormatByte.IsNullOrWhiteSpace() || fmbn.Prefix.IsNullOrWhiteSpace())
                    return;

                String binstr = null;

                var filePath = Dialogs.FileBrowser(this,
                    Title: "Выбор файла для бинарного представления"
                    ).FirstOrDefault();

                if (filePath.IsNullOrWhiteSpace())
                    return;

                if (!File.Exists(filePath))
                    return;

                if (new FileInfo(filePath).Length > (1024 * 1024))
                {
                    Dialogs.ErrorF(this, "Файлы более 1 мегабайта нельзя обрабатывать");
                    return;
                }

                var rawBytes = File.ReadAllBytes(filePath);

                binstr = $"'{fmbn.Prefix}{rawBytes.JoinValuesToString("", false, fmbn.FormatByte)}'";

                binstr = rtbScriptBody.Text.SubString(0, rtbScriptBody.SelectionStart) + binstr + rtbScriptBody.Text.SubString(rtbScriptBody.SelectionStart);

                rtbScriptBody.Text = binstr;
                posCurscript = posCurscript + binstr.Length;
                setPosCur();
            }
            catch (Exception ex)
            {
                Dialogs.ErrorF(this, ex.Expand());
            }
        }

        private void tsmiCopySelect_Click(object sender, EventArgs e) =>
            Clipboard.SetText(rtbScriptBody.SelectedText, TextDataFormat.UnicodeText);

        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            var clipText = Clipboard.GetText();
            rtbScriptBody.Text = rtbScriptBody.Text.Insert(rtbScriptBody.SelectionStart, clipText);
            posCurscript = posCurscript + clipText.Length;
            setPosCur();
        }

        private void tsmiDeleteText_Click(object sender, EventArgs e)
        {
            rtbScriptBody.Text = rtbScriptBody.Text.Remove(rtbScriptBody.SelectionStart, rtbScriptBody.SelectionLength);
            setPosCur();
        }

        private void tsmiTextSelectCute_Click(object sender, EventArgs e)
        {
            tsmiCopySelect_Click(null, null);
            tsmiDeleteText_Click(null, null);
        }

        private void setPosCur()
        {
            rtbScriptBody.SelectionLength = 0;
            rtbScriptBody.SelectionStart = posCurscript;
            rtbScriptBody.ScrollToCaret();
        }

        private void rtbScriptBody_MouseDown(object sender, MouseEventArgs e) =>
            rtbScriptBody.Focus();

        private void tbIdTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbIdTask.Text.IsNullOrWhiteSpace())
                return;

            if (e.KeyCode == Keys.Enter)
                btAddInIDTask_Click(null, null);
        }

        private void bwRequestTfs_DoWork(object sender, DoWorkEventArgs e)
        {
            var curset = (TfsDbLink)e.Argument;

            string tempfile = null;
            try
            {

                // Проверяем доступность TFS
                // подгружаем настройку бинарныго формата
                bwRequestTfs.ReportProgress(0, $"Проверка настроек TFS '{curset.Name}'");

                using (var tfsbl = new TfsRoutineBL(curset.ServerUri))
                {
                    tempfile = Path.Combine(DomainContext.TempPath, Guid.NewGuid().ToString());
                    tfsbl.DownloadFile(curset.ServerPathToSettings, tempfile);
                    var upsets = File.ReadAllBytes(tempfile).DeserializeAesDecrypt<UpdateDbSetting>(curset.ServerPathToSettings);
                    e.Result = Tuple.Create(curset.Name, upsets.FormatBinary);
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
            finally
            {
                if (!tempfile.IsNullOrWhiteSpace() && File.Exists(tempfile))
                    File.Delete(tempfile);
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e) =>
            savbl_StatusMessages((string)e.UserState);

        private void bwRequestTfs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            savbl_StatusMessages(null);

            if (e.Result is Exception ex)
            {
                var exMsg = ex.Expand();
                if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                    exMsg = ex.InnerException.Message;

                Dialogs.ErrorF(this, exMsg);

                return;
            }

            var res = (Tuple<String, FormatBinaryData>)e.Result;

            Config.Instance.UpdaterDb.SelestedTFSDB = res.Item1;
            formatbin = res.Item2;

            btSaveScript.Enabled = true;

            bttvQueryRefresh_Click(null, null);

            panelTfsWorkItems.Enabled =
            panelScript.Enabled = true;
        }

    }
}
