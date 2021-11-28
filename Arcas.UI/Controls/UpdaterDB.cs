using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Arcas.BL;
using Arcas.BL.TFS;
using Arcas.Settings;
using Cav;
using Cav.Tfs;

namespace Arcas.Controls
{
    public partial class UpdaterDB : TabControlBase
    {
        public UpdaterDB()
        {
            InitializeComponent();
            this.Text = "Накатка БД";
        }

        Boolean textChanged = true;
        FormatBinaryData formatbin = null;

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

            if (msg.IsNullOrWhiteSpace())
                msg = savbl.SaveScript(
                    (TfsDbLink)cbxTfsDbLinc.SelectedItem,
                    rtbScriptBody.Text,
                    tbComment.Text,
                    chbTransaction.Checked,
                    lbLinkedWirkItem.Items.Cast<Lwi>().Select(x => x.ID).ToList());
            if (msg.IsNullOrWhiteSpace())
                Dialogs.InformationF(this, "Успешно");
            else
                Dialogs.ErrorF(this, msg);

            textChanged = false;
            btSaveScript.Enabled = true;
            savbl_StatusMessages(String.Empty);
            Config.Instance.SelestedTFSDB = cbxTfsDbLinc.Text;
            Cursor.Current = Cursors.Default;
        }

        private void savbl_StatusMessages(string message)
        {
            this.SetSateProgress(message);
        }

        public override void RefreshTab()
        {
            var selName = Config.Instance.SelestedTFSDB;
            cbxTfsDbLinc.DataSource = Config.Instance.TfsDbSets;
            if (cbxTfsDbLinc.DataSource != null)
                cbxTfsDbLinc.SelectedItem = ((List<TfsDbLink>)cbxTfsDbLinc.DataSource).FirstOrDefault(x => x.Name == selName);
            if (cbxTfsDbLinc.SelectedItem == null && cbxTfsDbLinc.Items.Count > 0)
                cbxTfsDbLinc.SelectedIndex = 0;

            cbxTfsDbLinc_SelectionChangeCommitted(null, null);
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbComment.Text = null;
            rtbScriptBody.Text = null;
        }

        private void bttvQueryRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                tvQuerys.Nodes.Clear();

                TfsDbLink curset = cbxTfsDbLinc.SelectedItem as TfsDbLink;

                if (curset == null || curset.ServerUri == null || curset.ServerPathToSettings.IsNullOrWhiteSpace())
                {
                    bttvQueryRefresh.Enabled = false;
                    return;
                }

                var tfs = new WrapTfs();
                var qs = tfs.QueryItemsGet(curset.ServerUri, curset.ServerPathToSettings);

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
                String exMsg = ex.Expand();
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

                TfsDbLink curset = cbxTfsDbLinc.SelectedItem as TfsDbLink;
                if (curset == null)
                    return;

                if (curset.ServerUri == null)
                {
                    Dialogs.InformationF(this, "В настройках связки не указан сервер TFS");
                    return;
                }

                QueryItemNode qin = (QueryItemNode)e.Node.Tag;

                if (qin.IsFolder)
                    return;

                var tfs = new WrapTfs();
                var wims = tfs.WorkItemsFromQueryGet(curset.ServerUri, qin);
                foreach (var wi in wims)
                    lbWorkItems.Items.Add(new Lwi(wi));
            }
            catch (Exception ex)
            {
                String exMsg = ex.Expand();
                if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                    exMsg = ex.InnerException.Message;
                Dialogs.ErrorF(this, exMsg);
            }
        }
        class Lwi
        {
            public Lwi(WorkItem wi)
            {
                ID = wi.ID;
                Title = wi.Title;
            }
            public int ID { get; set; }
            public String Title { get; set; }
            public override string ToString()
            {
                return $"({ID}) {Title}";
            }
        }

        private void btAddWorkItem_Click(object sender, EventArgs e)
        {
            foreach (Lwi item in lbWorkItems.SelectedItems)
            {
                Lwi si = (Lwi)item;

                if (lbLinkedWirkItem.Items.Cast<Lwi>().Any(x => x.ID == si.ID))
                    continue;
                lbLinkedWirkItem.Items.Add(si);
            }

            lbWorkItems.SelectedItems.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar);
        }

        private void btAddInIDTask_Click(object sender, EventArgs e)
        {
            try
            {
                int idTask;
                if (!int.TryParse(tbIdTask.Text, out idTask))
                    return;

                TfsDbLink curset = cbxTfsDbLinc.SelectedItem as TfsDbLink;
                if (curset == null)
                    return;

                if (curset.ServerUri == null)
                {
                    Dialogs.InformationF(this, "В настройках связки не указан сервер TFS");
                    return;
                }

                var tfs = new WrapTfs();
                var wi = tfs.WorkItemByIdGet(curset.ServerUri, idTask);
                if (lbLinkedWirkItem.Items.Cast<Lwi>().Any(x => x.ID == wi.ID))
                    return;
                lbLinkedWirkItem.Items.Add(new Lwi(wi));

                tbIdTask.Text = null;
            }
            catch (Exception ex)
            {
                String exMsg = ex.Expand();
                if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                    exMsg = ex.InnerException.Message;
                Dialogs.ErrorF(this, exMsg);
            }
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
            this.RefreshTab();
        }

        private void tbScriptBody_TextChanged(object sender, EventArgs e)
        {
            textChanged = true;
        }

        private void cbxTfsDbLinc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TfsDbLink curset = cbxTfsDbLinc.SelectedItem as TfsDbLink;

            this.btSaveScript.Enabled = false;
            formatbin = null;

            if (curset != null)
            {
                if (!curset.ServerPathToSettings.IsNullOrWhiteSpace() & curset.ServerUri != null)
                {
                    String tempfile = null;
                    try
                    {
                        // Проверяем доступность TFS
                        // подгружаем настройку бинарныго формата
                        using (var tfsbl = new TFSRoutineBL())
                        {
                            tfsbl.VersionControl(curset.ServerUri);
                            tempfile = Path.Combine(DomainContext.TempPath, Guid.NewGuid().ToString());
                            tfsbl.DownloadFile(curset.ServerPathToSettings, tempfile);
                            var upsets = File.ReadAllBytes(tempfile).DeserializeAesDecrypt<UpdateDbSetting>(curset.ServerPathToSettings);
                            formatbin = upsets.FormatBinary;
                        }

                        this.btSaveScript.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        String exMsg = ex.Expand();
                        if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                            exMsg = ex.InnerException.Message;
                        Dialogs.ErrorF(this, exMsg);
                    }
                    finally
                    {
                        if (!tempfile.IsNullOrWhiteSpace() && File.Exists(tempfile))
                            File.Delete(tempfile);
                    }
                }

                Config.Instance.SelestedTFSDB = curset.Name;
            }

            bttvQueryRefresh_Click(null, null);
        }

        private void tsmiClearScriptText_Click(object sender, EventArgs e)
        {
            rtbScriptBody.Text = null;
        }

        int posCurscript = 0;

        private void cmsScriptArea_Opening(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void tsmiCopySelect_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbScriptBody.SelectedText, TextDataFormat.UnicodeText);
        }

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

        private void rtbScriptBody_MouseDown(object sender, MouseEventArgs e)
        {
            rtbScriptBody.Focus();
        }

        private void tbIdTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbIdTask.Text.IsNullOrWhiteSpace())
                return;

            if (e.KeyCode == Keys.Enter)
                btAddInIDTask_Click(null, null);
        }
    }
}
