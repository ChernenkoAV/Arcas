using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Cav;
using Cav.Tfs;
using Cav.WinForms.BaseClases;

namespace Arcas.Settings
{
    public partial class TFSDBLinkForm : DialogFormBase
    {
        public TFSDBLinkForm()
        {
            InitializeComponent();
            dgvTFSDB.AutoGenerateColumns = false;
            dgvTFSDB.DataSource = link;
        }

        private TFSDBList link = Config.Instance.TfsDbSets ?? new List<TfsDbLink>();

        private void btAdd_Click(object sender, EventArgs e)
        {
            var nl = new TfsDbLink();

            do
            {
                nl.Name = Dialogs.InputBox(this, "Наименование связки TFS-DB.", "Наименование связки", "Новая связка");

                if (nl.Name.IsNullOrWhiteSpace())
                {
                    MessageBox.Show(this, "Не указано наименование связки");
                    return;
                }

                if (link.Any(x => x.Name == nl.Name))
                    MessageBox.Show(this, "Наименование должно быть уникальным");

            } while (link.Any(x => x.Name == nl.Name));

            WrapTfs wrapTfs = new WrapTfs();
            nl.ServerUri = wrapTfs.ShowTeamProjectPicker(this);

            selFileOnServer(nl);

            link.Add(nl);

            dgvTFSDB.Update();
        }

        private void selFileOnServer(TfsDbLink link)
        {
            if (link.ServerUri != null)
            {
                WrapTfs wrapTfs = new WrapTfs();
                var vc = wrapTfs.VersionControlServerGet(link.ServerUri);

                var selItem = wrapTfs.ShowDialogChooseItem(this, vc);

                if (selItem == null)
                    return;

                if (selItem.ItemType != ItemType.File)
                {
                    Dialogs.ErrorF(this, "Необходимо выбрать файл настроек");
                    return;
                }

                var tempFile = Path.Combine(DomainContext.TempPath, Guid.NewGuid().ToString());

                wrapTfs.VersionControlServerDownloadFile(vc, selItem.Path, tempFile);

                UpdateDbSetting sets = null;
                String msg = "Файл настроек не расшифрован. Либо выбран не файл настроек, либо еще чо. Exception: {0}";
                try
                {
                    sets = File.ReadAllBytes(tempFile).DeserializeAesDecrypt<UpdateDbSetting>(selItem.Path);
                }
                catch (Exception ex)
                {
                    msg = String.Format(msg, ex.Expand());
                }

                if (sets == null || sets.ServerPathScripts.IsNullOrWhiteSpace())
                {
                    Dialogs.InformationF(this, msg);
                }
                else
                    link.ServerPathToSettings = selItem.Path;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvTFSDB.SelectedRows.Count == 0)
                return;
            foreach (DataGridViewRow item in dgvTFSDB.SelectedRows)
            {
                if (item.DataBoundItem == null)
                    continue;

                link.Remove((TfsDbLink)item.DataBoundItem);
            }
        }

        private void dgvTFSDB_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.Button != MouseButtons.Left)
                return;
            if (dgvTFSDB.SelectedRows.Count == 0)
                return;
            var tdbli = (TfsDbLink)((DataGridViewRow)dgvTFSDB.SelectedRows[0]).DataBoundItem;

            if (e.ColumnIndex == 0)
            {
                var nn = Dialogs.InputBox(this, "Наименование связки TFS-DB.", "Наименование связки", tdbli.Name);
                if (nn.IsNullOrWhiteSpace())
                {
                    MessageBox.Show(this, "Не указано наименование связки");
                    return;
                }

                tdbli.Name = nn;
            }

            if (e.ColumnIndex == 1)
            {
                var wraptfs = new WrapTfs();
                var server = wraptfs.ShowTeamProjectPicker(this);
                if (server == null)
                    return;
                tdbli.ServerUri = server;
                tdbli.ServerPathToSettings = null;
            }

            if (e.ColumnIndex == 2)
            {
                if (tdbli.ServerUri == null)
                {
                    Dialogs.ErrorF(this, "Необходимо выбрать проект");
                    return;
                }

                selFileOnServer(tdbli);
            }
        }

        private void tFSDBLinkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                return;

            Config.Instance.TfsDbSets = link;
            Config.Instance.Save();
        }

        private void tFSDBLinkForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Alt && e.Control))
                return;

            if (!(e.KeyCode == Keys.C || e.KeyCode == Keys.E))
                return;

            var crSet = new CreateSettingUpdater();
            crSet.ItemsInSets = link;

            if (e.KeyCode == Keys.E)
            {
                try
                {
                    var selrow = dgvTFSDB.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
                    if (selrow != null)
                        crSet.EditedSet(selrow.DataBoundItem as TfsDbLink);
                }
                catch (Exception ex)
                {
                    Dialogs.ErrorF(this, "Открыть для редактирования невозможно: " + ex.Expand());
                    return;
                }
            }

            crSet.ShowDialog(this);
        }
    }
}
