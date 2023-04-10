using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Arcas.Controls;
using Arcas.Update;
using Cav;
using Cav.Container;

namespace Arcas
{
    public partial class ArcasMain : Form
    {
        public ArcasMain()
        {
            InitializeComponent();

            Text = "Аркас " + Updater.CurrentVersion();

            tabs.AddRange(Locator.GetInstances<TabControlBase>());

            foreach (var tb in tabs)
            {
                var ts = new TabPage();

                ts.Controls.Add(tb);
                ts.Name = tb.Name;
                ts.Text = tb.Text;
                ts.UseVisualStyleBackColor = true;
                tb.StateProgress += savbl_StatusMessages;
                tb.Dock = DockStyle.Fill;
                tcTabs.TabPages.Add(ts);
            }
        }

        private List<TabControlBase> tabs = new List<TabControlBase>();

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) =>
            Close();

        private void arcasMain_Load(object sender, EventArgs e)
        {
            foreach (var item in tabs)
            {
                try
                {
                    item.RefreshTab();
                }
                catch (Exception ex)
                {
                    var msg = ex.Expand();
                    if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                        msg = ex.InnerException.Message;

                    Dialogs.Error(this, msg);
                }
            }
        }

        private void savbl_StatusMessages(string message)
        {
            tsProgressMessage.Text = message;
            Refresh();
        }

        private void arcasMainMindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in tabs)
            {
                try
                {
                    item.CloseApp();
                }
                catch { }
            }

            Config.Instance.Save();

            try
            {
                DomainContext.TempPath.DeleteDirectory();
            }
            catch { }
        }
    }
}
