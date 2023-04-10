using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Arcas.BL.TFS;
using Cav;
using Cav.WinForms.BaseClases;

namespace Arcas.Settings
{
    public partial class TFSDBLinkForm : DialogFormBase
    {
        public TFSDBLinkForm()
        {
            links = Config.Instance.UpdaterDb.TfsDbSets ?? new List<TfsDbLink>();

            InitializeComponent();
            dgvTFSDB.AutoGenerateColumns = false;
            dgvTFSDB.DataSource = links;
        }

        private TFSDBList links;

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

                if (links.Any(x => x.Name == nl.Name))
                    MessageBox.Show(this, "Наименование должно быть уникальным");

            } while (links.Any(x => x.Name == nl.Name));

            nl.ServerUri = TfsRoutineBL.ShowTeamProjectPicker(this);

            selFileOnServer(nl);

            links.Add(nl);

            dgvTFSDB.Update();
        }

        private void selFileOnServer(TfsDbLink link)
        {
            if (link.ServerUri == null)
                return;

            string selPath;
            try
            {
                selPath = TfsRoutineBL.SelectServerPathSetting(this, link.ServerUri);
            }
            catch (Exception ex)
            {
                Dialogs.Information(this, ex.Message);
                return;
            }

            if (!selPath.IsNullOrWhiteSpace())
                link.ServerPathToSettings = selPath;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvTFSDB.SelectedRows.Count == 0)
                return;
            foreach (DataGridViewRow item in dgvTFSDB.SelectedRows)
            {
                if (item.DataBoundItem == null)
                    continue;

                links.Remove((TfsDbLink)item.DataBoundItem);
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
            var tdbli = (TfsDbLink)dgvTFSDB.SelectedRows[0].DataBoundItem;

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
                var server = TfsRoutineBL.ShowTeamProjectPicker(this);
                if (server == null)
                    return;
                tdbli.ServerUri = server;
                tdbli.ServerPathToSettings = null;
            }

            if (e.ColumnIndex == 2)
            {
                if (tdbli.ServerUri == null)
                {
                    Dialogs.Error(this, "Необходимо выбрать проект");
                    return;
                }

                selFileOnServer(tdbli);
            }
        }

        private void tFSDBLinkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                return;

            Config.Instance.UpdaterDb.TfsDbSets = links;
            Config.Instance.Save();
        }

        private void tFSDBLinkForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Alt && e.Control))
                return;

            if (!(e.KeyCode == Keys.C || e.KeyCode == Keys.E))
                return;

            var crSet = new CreateSettingUpdater
            {
                ItemsInSets = links
            };

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
                    Dialogs.Error(this, "Открыть для редактирования невозможно: " + ex.Expand());
                    return;
                }
            }

            crSet.ShowDialog(this);
        }
    }
}
