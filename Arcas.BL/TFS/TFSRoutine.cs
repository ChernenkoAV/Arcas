using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cav;
using Cav.Tfs;

namespace Arcas.BL.TFS
{
    /// <summary>
    /// Взаимодействие с ТФС
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
    public class TFSRoutineBL : IDisposable
    {
        public TFSRoutineBL()
        {
            // чистим папку
            if (Directory.Exists(Tempdir))
                Utils.DeleteDirectory(Tempdir);

            Directory.CreateDirectory(Tempdir);
        }

        private WrapTfs wrapTfs = new WrapTfs();

        private VersionControlServer vcs;

        private const string arcasWorkspaceName = "Arcas Workspace";
        private const string arcasShelveName = "Arcas Roll DB";
        /// <summary>
        /// Получение сервиса управления хранилищем
        /// </summary>
        /// <param name="TfsServer">Url сервера TFS</param>
        /// <returns>Контроллер хранилища</returns>
        public void VersionControl(Uri serverTfs)
        {
            vcs = wrapTfs.VersionControlServerGet(serverTfs);
        }

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

            tempWorkspace = wrapTfs.WorkspaceCreate(vcs, Guid.NewGuid().ToString(), arcasWorkspaceName, true);

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
                    var mfdr = wrapTfs.WorkspaceFoldersGet(tempWorkspace).FirstOrDefault();

                    // Если в процесе ремапят, то надо удалить предыдущюю раб.обл.
                    if (mfdr != null &&
                    mfdr.LocalItem != Tempdir &&
                    mfdr.ServerItem != serverPath)

                    {
                        wrapTfs.WorkspaceUndo(tempWorkspace);
                        wrapTfs.WorkspaceDelete(tempWorkspace);
                        tempWorkspace = null;
                    }
                }

                this.serverPath = serverPath;
                // Для этого рабочего пространства папка на сервере сопоставляется с локальной папкой 
                wrapTfs.WorkspaceMap(getTempWorkspace(), this.serverPath, Tempdir);
            }
            catch
            {
                if (tempWorkspace != null)
                {
                    wrapTfs.WorkspaceUndo(tempWorkspace);
                    wrapTfs.WorkspaceDelete(tempWorkspace);
                    tempWorkspace = null;
                }

                throw;
            }
        }

        public void DownloadFile(string serverPathToSettings, string tempfile)
        {
            wrapTfs.VersionControlServerDownloadFile(vcs, serverPathToSettings, tempfile);
        }

        /// <summary>
        /// Получение последней версии файлав в временной рабочей области
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Кол-во новых файлов</returns>
        public long GetLastFile(String fileName)
        {
            return wrapTfs.WorkspaceGetLastItem(getTempWorkspace(), serverPath + "/" + fileName);
        }

        /// <summary>
        /// Добавить файл в рабочую область
        /// </summary>
        /// <param name="pathFileName">Полный путь файла, находящийся в папке, замапленой в рабочей области</param>
        public void AddFile(string pathFileName)
        {
            wrapTfs.WorkspaceAddFile(getTempWorkspace(), pathFileName);
        }

        /// <summary>
        /// Возврат изменений в рабочей области
        /// </summary>
        /// <param name="commentOnCheckIn">Комментарий для изменения</param>
        /// <param name="numberTasks">Номера задач для чекина</param>
        public void CheckIn(string commentOnCheckIn, List<int> numberTasks = null)
        {
            wrapTfs.WorkspaceCheckIn(getTempWorkspace(), commentOnCheckIn, numberTasks);
        }

        /// <summary>
        /// Блокировка файла. Псевдо транзанкция
        /// </summary>
        /// <param name="fileName">Имя файла(можно с путем. на сервере)</param>
        /// <param name="Block"></param>
        /// <returns>true - успешно, false - неуспешно</returns>
        public bool LockFile(string fileName)
        {
            return wrapTfs.WorkspaceLockFile(getTempWorkspace(), serverPath + "/" + fileName, LockLevel.CheckOut);
        }

        /// <summary>
        /// Извлечение файла для редактирования
        /// </summary>
        /// <param name="pathFileName">Полный путь файла, находящийся в папке, замапленой в рабочей области</param>
        /// <returns>true - успешно, false - неуспешно</returns>
        public bool CheckOut(string pathFileName)
        {
            return wrapTfs.WorkspaceCheckOut(getTempWorkspace(), pathFileName);
        }

        public bool ExistsShelveset()
        {
            var shlvs = wrapTfs.ShelvesetsCurrenUserLoad(vcs);
            return shlvs.Any(x => x.Name == arcasShelveName);
        }

        public void DeleteShelveset()
        {
            wrapTfs.ShelvesetDelete(vcs, arcasShelveName);
        }

        public void CreateShelveset(string comment, List<int> linkedTask)
        {
            wrapTfs.WorkspaceShelvesetCreate(getTempWorkspace(), arcasShelveName, comment, linkedTask);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        public void Dispose()
        {
            try
            {
                if (tempWorkspace != null)
                {
                    wrapTfs.WorkspaceUndo(tempWorkspace);
                    wrapTfs.WorkspaceDelete(tempWorkspace);
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
    }
}
