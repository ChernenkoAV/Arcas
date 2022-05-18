using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Arcas.Settings;
using Cav;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.ProcessConfiguration.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.VersionControl.Common;
using Microsoft.TeamFoundation.VersionControl.Controls;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

#pragma warning disable CS0618 // Тип или член устарел

namespace Arcas.BL.TFS
{

    /// <summary>
    /// Элемент в представлении (дереве) запросов рабочих элементов
    /// </summary>
    public class QueryItemNode
    {
        internal QueryItemNode() { }

        /// <summary>
        /// Элемент является каталогом
        /// </summary>
        public Boolean IsFolder => !QueryID.HasValue;
        /// <summary>
        /// Имя элемента
        /// </summary>
        public String Name { get; internal set; }
        internal String ProjectName { get; set; }
        /// <summary>
        /// Дочерние элементы
        /// </summary>
        public ReadOnlyCollection<QueryItemNode> ChildNodes { get; internal set; }
        internal Guid? QueryID { get; set; }

        /// <summary>
        /// получение имени
        /// </summary>
        /// <returns>Имя</returns>
        public override string ToString() => Name;
    }

    /// <summary>
    /// Взаимодействие с ТФС
    /// </summary>
    public class TfsRoutineBL : IDisposable
    {
        public TfsRoutineBL(Uri serverTfs)
        {
            // чистим папку
            if (Directory.Exists(Tempdir))
                Utils.DeleteDirectory(Tempdir);

            Directory.CreateDirectory(Tempdir);

            vcs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(serverTfs)
                .GetService<VersionControlServer>();
        }

        private VersionControlServer vcs;

        private const string arcasWorkspaceName = "Arcas Workspace";
        private const string arcasShelveName = "Arcas Roll DB";
        public String Tempdir { get; } = Path.Combine(DomainContext.TempPath, Guid.NewGuid().ToString());

        private Workspace tempWorkspace;
        private String serverPath;

        // Создаем временную рабочую область
        private Workspace getTempWorkspace()
        {
            if (vcs == null)
                throw new ArgumentException("Не установленна связь с TFS");

            if (tempWorkspace != null)
                return tempWorkspace;

            var cwp = new CreateWorkspaceParameters(Guid.NewGuid().ToString())
            {
                Comment = arcasWorkspaceName,
                OwnerName = vcs.TeamProjectCollection.AuthorizedIdentity.UniqueName,
                Location = WorkspaceLocation.Server
            };

            tempWorkspace = vcs.CreateWorkspace(cwp);

            return tempWorkspace;
        }

        /// <summary>
        /// Связывание пути на сервере TFS с временной папкой во временной рабочей области
        /// </summary>
        /// <param name="serverPath"></param>
        public void MapTempWorkspace(String serverPath)
        {
            try
            {
                if (tempWorkspace != null)
                {
                    var mfdr = tempWorkspace.Folders.FirstOrDefault();

                    // Если в процесе ремапят, то надо удалить предыдущюю раб.обл.
                    if (mfdr != null &&
                    mfdr.LocalItem != Tempdir &&
                    mfdr.ServerItem != serverPath)

                    {
                        if (tempWorkspace.GetPendingChanges().Any())
                            tempWorkspace.Undo(tempWorkspace.GetPendingChanges());
                        tempWorkspace.Delete();
                        tempWorkspace = null;
                    }
                }

                this.serverPath = serverPath;
                // Для этого рабочего пространства папка на сервере сопоставляется с локальной папкой 
                getTempWorkspace().Map(this.serverPath, Tempdir);
            }
            catch
            {
                if (tempWorkspace != null)
                {
                    if (tempWorkspace.GetPendingChanges().Any())
                        tempWorkspace.Undo(tempWorkspace.GetPendingChanges());
                    tempWorkspace.Delete();
                    tempWorkspace = null;
                }

                throw;
            }
        }

        public void DownloadFile(string serverPathToSettings, string tempfile) => vcs.DownloadFile(serverPathToSettings, tempfile);

        /// <summary>
        /// Получение последней версии файлав в временной рабочей области
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Кол-во новых файлов</returns>
        public long GetLastFile(String fileName) =>
            getTempWorkspace().Get(new GetRequest(new ItemSpec(serverPath + "/" + fileName, RecursionType.Full), VersionSpec.Latest), GetOptions.GetAll | GetOptions.Overwrite).NumFiles;

        /// <summary>
        /// Добавить файл в рабочую область
        /// </summary>
        /// <param name="pathFileName">Полный путь файла, находящийся в папке, замапленой в рабочей области</param>
        public void AddFile(string pathFileName) => getTempWorkspace().PendAdd(pathFileName);

        /// <summary>
        /// Возврат изменений в рабочей области
        /// </summary>
        /// <param name="commentOnCheckIn">Комментарий для изменения</param>
        /// <param name="numberTasks">Номера задач для чекина</param>
        public void CheckIn(string commentOnCheckIn, IEnumerable<int> numberTasks)
        {
            var ws = getTempWorkspace();

            var wscp = new WorkspaceCheckInParameters(ws.GetPendingChanges(), commentOnCheckIn);

            if (numberTasks.Any())
            {
                var wis = new WorkItemStore(ws.VersionControlServer.TeamProjectCollection);

                wscp.AssociatedWorkItems = numberTasks
                    .Select(x => wis.GetWorkItem(x))
                    .Select(x => new WorkItemCheckinInfo(x, WorkItemCheckinAction.Associate))
                    .ToArray();
            }

            ws.CheckIn(wscp);
        }

        /// <summary>
        /// Блокировка файла. Псевдо транзанкция
        /// </summary>
        /// <param name="fileName">Имя файла(можно с путем. на сервере)</param>
        /// <param name="Block"></param>
        /// <returns>true - успешно, false - неуспешно</returns>
        public bool LockFile(string fileName)
        {
            try
            {
                return getTempWorkspace().SetLock(serverPath + "/" + fileName, LockLevel.CheckOut) != 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Извлечение файла для редактирования
        /// </summary>
        /// <param name="pathFileName">Полный путь файла, находящийся в папке, замапленой в рабочей области</param>
        /// <returns>true - успешно, false - неуспешно</returns>
        public bool CheckOut(string pathFileName) =>
            getTempWorkspace().PendEdit(pathFileName) != 0;

        public bool ExistsShelveset() => vcs.QueryShelvesets(arcasShelveName, RepositoryConstants.AuthenticatedUser).Any();

        public void DeleteShelveset()
        {
            foreach (var shelv in vcs.QueryShelvesets(arcasShelveName, RepositoryConstants.AuthenticatedUser).ToArray())
                vcs.DeleteShelveset(shelv);
        }

        public void CreateShelveset(string comment, IEnumerable<int> linkedTask)
        {
            var ws = getTempWorkspace();
            var pcs = ws.GetPendingChanges();
            if (!pcs.Any())
                return;

            var vcs = ws.VersionControlServer;

            var newShelveset = new Shelveset(vcs, arcasShelveName, RepositoryConstants.AuthenticatedUser)
            {
                Comment = comment,
                WorkItemInfo = linkedTask
                .Select(x => new WorkItemCheckinInfo(
                    vcs.TeamProjectCollection.GetService<WorkItemStore>().GetWorkItem(x),
                    WorkItemCheckinAction.Associate))
                .ToArray()
            };

            ws.Shelve(newShelveset, pcs, ShelvingOptions.None);
        }

        public void Dispose()
        {
            try
            {
                if (tempWorkspace != null)
                {
                    if (tempWorkspace.GetPendingChanges().Any())
                        tempWorkspace.Undo(tempWorkspace.GetPendingChanges());
                    tempWorkspace.Delete();
                    tempWorkspace = null;
                }

                if (Directory.Exists(Tempdir))
                    Utils.DeleteDirectory(Tempdir);
            }
            catch
            {
                // очистка мусора неуспешна. жаль. ну а что поделать..
            }
        }

        #region 

        /// <summary>
        /// Отобразить диалог выбора проектов TFS. Настроенно на выбор только одгного проекта
        /// </summary>
        /// <param name="parentWindow">Родительское окно</param>
        /// <returns>Uri выбранного проекта. Иначе null</returns>
        public static Uri ShowTeamProjectPicker(IWin32Window parentWindow)
        {
            var tpp = new TeamProjectPicker(TeamProjectPickerMode.NoProject, false);
            var dr = tpp.ShowDialog(parentWindow);
            return dr != DialogResult.OK ? null : tpp.SelectedTeamProjectCollection.Uri;
        }

        /// <summary>
        /// Отображение диалога выбора пути на сервере СКВ
        /// </summary>
        /// <param name="parentWindow">Родительское окно</param>
        /// <param name="serverUri">сервер</param>
        /// <param name="initalPath">Путь для инизиализации диалога</param>
        /// <returns>Выбранный путь на сервере. Иначе null.</returns>
        public static String ShowDialogChooseServerFolder(IWin32Window parentWindow, Uri serverUri)
        {
            var vcs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(serverUri)
                        .GetService<VersionControlServer>();

            var dcsf = new DialogChooseServerFolder(vcs, null)
            {
                ShowInTaskbar = false
            };

            return dcsf.ShowDialog(parentWindow) != DialogResult.OK
                ? null
                : dcsf.CurrentServerItem;
        }

        /// <summary>
        /// Получение рабочего элемента ло его Id
        /// </summary>
        /// <param name="serverUri">Uri сервера TFS</param>
        /// <param name="id">Id рабочего элемента</param>
        /// <returns></returns>
        public static string TitleWorkItemByIdGet(Uri serverUri, int id)
        {
            var wisc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(serverUri).GetService<WorkItemStore>();
            return wisc.GetWorkItem(id)?.Title;
        }

        /// <summary>
        /// Получение древовидного представления запросов. Папки, в которых ничего нет - не выводятся.
        /// </summary>
        /// <param name="serverUri">Uri к TFS</param>
        /// <param name="serverItemPath">Путь к элементу на сервере СКВ</param>
        /// <returns></returns>
        public static ReadOnlyCollection<QueryItemNode> QueryItemsGet(Uri serverUri, String serverItemPath)
        {
            var res = new List<QueryItemNode>();
            var tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(serverUri);
            var vc = tpc.GetService<VersionControlServer>();
            var projectNoServerPath = vc.GetTeamProjectForServerPath(serverItemPath);
            var projectName = projectNoServerPath.Name;

            var wis = tpc.GetService<WorkItemStore>();
            var prs = wis.Projects;

            QueryHierarchy wip = null;

            foreach (Project pr in prs)
            {
                if (pr.Name != projectName)
                    continue;
                wip = pr.QueryHierarchy;
                break;
            }

            if (wip == null)
                throw new ArgumentException("Не удалось определить проект");

            Func<QueryItem, QueryItemNode> recSeek = null;

            recSeek = new Func<QueryItem, QueryItemNode>(itm =>
            {
                var qin = new QueryItemNode
                {
                    Name = itm.Name,
                    ProjectName = projectName
                };

                var folder = itm as QueryFolder;
                var defQuery = itm as QueryDefinition;
                if (folder == null)
                    qin.QueryID = itm.Id;

                var childEls = new List<QueryItemNode>();

                if (folder != null)
                {
                    foreach (var itemInfolder in folder)
                    {
                        if (itemInfolder is QueryFolder qflr && qflr.Count == 0)
                            continue;

                        var childEl = recSeek(itemInfolder);
                        if (childEl != null)
                            childEls.Add(childEl);
                    }
                }
                else
                {
                    if (defQuery.QueryType != QueryType.List)
                        return null;
                }

                qin.ChildNodes = new ReadOnlyCollection<QueryItemNode>(childEls);

                if (qin.IsFolder && !qin.ChildNodes.Any())
                    return null;

                return qin;
            });

            foreach (var item in wip)
            {
                var nitmNode = recSeek(item);
                if (nitmNode != null)
                    res.Add(nitmNode);
            }

            return new ReadOnlyCollection<QueryItemNode>(res);
        }

        /// <summary>
        /// Получение рабочих элементов по сохраненному запросу
        /// </summary>
        /// <param name="serverUri">Uri сервера TFS</param>
        /// <param name="queryitem">экземпляр запроса</param>
        /// <returns>Коллекция рабочих элементов</returns>
        public static Dictionary<int, string> WorkItemsFromQueryGet(Uri serverUri, QueryItemNode queryitem)
        {
            var res = new Dictionary<int, string>();

            if (queryitem.IsFolder)
                return res;

            var tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(serverUri);
            var wis = tpc.GetService<WorkItemStore>();
            var prject = tpc.GetService<ICommonStructureService4>().GetProjectFromName(queryitem.ProjectName);

            var tscs = tpc.GetService<TeamSettingsConfigurationService>();
            var team = tscs.GetTeamConfigurationsForUser(new[] { prject.Uri }).FirstOrDefault();

            var query = wis.GetQueryDefinition(queryitem.QueryID.Value);

            if (query == null)
                throw new ArgumentOutOfRangeException("Не найден запрос с именем " + queryitem.Name);

            var queryText = query.QueryText;

            var variables = new Dictionary<string, string>
            {
                { "project", queryitem.ProjectName }
            };

            if (team != null)
                variables.Add("currentIteration", team.TeamSettings.CurrentIterationPath);

            queryText = "SELECT [System.Id], [System.Title] " + queryText.SubString(queryText.IndexOf(" FROM ", StringComparison.OrdinalIgnoreCase));

            var wims = wis.Query(queryText, variables);
            foreach (WorkItem wim in wims)
                res.Add(wim.Id, wim.Title);

            return res;

        }

        public static string SelectServerPathSetting(IWin32Window parentWindow, Uri serverUri)
        {
            if (parentWindow is null)
                throw new ArgumentNullException(nameof(parentWindow));

            var vcs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(serverUri)
                .GetService<VersionControlServer>();

            var typeDialog = typeof(DialogChooseServerFolder).Assembly.GetType("Microsoft.TeamFoundation.VersionControl.Controls.DialogChooseItem");
            var consInfo = typeDialog.GetConstructor(
                                   BindingFlags.Instance | BindingFlags.NonPublic,
                                   null,
                                   new Type[] { typeof(VersionControlServer) },
                                   null);
            var instDialog = (Form)consInfo.Invoke(new object[] { vcs });
            var dr = instDialog.ShowDialog(parentWindow);
            if (dr != DialogResult.OK)
                return null;

            var selitemprpinfo = typeDialog.GetProperty("SelectedItem", BindingFlags.Instance | BindingFlags.NonPublic);
#pragma warning disable IDE0059 // Ненужное присваивание значения
            var selectedItem = selitemprpinfo.GetValue(instDialog, null) as Item;
#pragma warning restore IDE0059 // Ненужное присваивание значения

            if (selectedItem.ItemType != ItemType.File)
                throw new Exception("Необходимо выборать файл настроек");

            var tempFile = Path.Combine(DomainContext.TempPath, Guid.NewGuid().ToString());

            vcs.DownloadFile(selectedItem.ServerItem, tempFile);

            UpdateDbSetting sets = null;
            var msg = "Файл настроек не расшифрован. Либо выбран не файл настроек, либо еще чо.";
            try
            {
                sets = File.ReadAllBytes(tempFile).DeserializeAesDecrypt<UpdateDbSetting>(selectedItem.ServerItem);
            }
            catch (Exception ex)
            {
                msg += ex.Expand();
            }

            if (sets == null || sets.ServerPathScripts.IsNullOrWhiteSpace())
                throw new Exception(msg);

            return selectedItem.ServerItem;

        }

        #endregion
    }
}
