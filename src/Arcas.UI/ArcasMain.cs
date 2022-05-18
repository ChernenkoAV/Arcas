﻿using System;
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
#pragma warning disable CS0618 // Тип или член устарел
            tsVersion.Text = Updater.CurrentVersion();
#pragma warning restore CS0618 // Тип или член устарел

            foreach (var tb in Locator.GetInstances<TabControlBase>())
            {
                var ts = new TabPage();

                ts.Controls.Add(tb);
                ts.Name = tb.Name;
                ts.Text = tb.Text;
                ts.UseVisualStyleBackColor = true;
                refreshTabAction.Add(tb.RefreshTab);
                rcloseAppAction.Add(tb.CloseApp);
                tb.StateProgress += savbl_StatusMessages;
                tb.Dock = DockStyle.Fill;
                tcTabs.TabPages.Add(ts);
            }
        }

        private List<Action> refreshTabAction = new List<Action>();
        private List<Action> rcloseAppAction = new List<Action>();

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) =>
            Close();

        private void tabPageDBVer_Enter(object sender, EventArgs e)
        {
            foreach (var item in refreshTabAction)
                try
                {
                    item.Invoke();
                }
                catch (Exception ex)
                {
                    var msg = ex.Expand();
                    if (ex.GetType().Name == "TargetInvocationException" && ex.InnerException != null)
                        msg = ex.InnerException.Message;

                    Dialogs.ErrorF(this, msg);
                }
        }

        private void savbl_StatusMessages(string message)
        {
            tsProgressMessage.Text = message;
            Refresh();
        }

        private void arcasMainMindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var closeTab in rcloseAppAction)
                try
                {
                    closeTab();
                }
                catch { }

            Config.Instance.Save();

            try
            {
                Utils.DeleteDirectory(DomainContext.TempPath);
            }
            catch { }
        }

        private void arcasMain_Load(object sender, EventArgs e) =>
            tabPageDBVer_Enter(null, null);
    }
}
