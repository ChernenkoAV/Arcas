﻿namespace Arcas.Controls
{
    partial class UpdaterDB
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdaterDB));
            this.chbTransaction = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.btSaveScript = new System.Windows.Forms.Button();
            this.tbScriptBody = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTfsDbLinc = new System.Windows.Forms.ComboBox();
            this.btClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btTfsDbLinkSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbIdTask = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bttvQueryRefresh = new System.Windows.Forms.Button();
            this.tvQuerys = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lbWorkItems = new System.Windows.Forms.ListBox();
            this.btAddInIDTask = new System.Windows.Forms.Button();
            this.btAddWorkItem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbLinkedWirkItem = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbTransaction
            // 
            this.chbTransaction.AutoSize = true;
            this.chbTransaction.Location = new System.Drawing.Point(158, 32);
            this.chbTransaction.Name = "chbTransaction";
            this.chbTransaction.Size = new System.Drawing.Size(159, 17);
            this.chbTransaction.TabIndex = 15;
            this.chbTransaction.Text = "Выполнять в транзанкции";
            this.chbTransaction.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Тело скрипта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Комментарий к накатке";
            // 
            // tbComment
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.Location = new System.Drawing.Point(3, 52);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbComment.Size = new System.Drawing.Size(669, 50);
            this.tbComment.TabIndex = 12;
            // 
            // btSaveScript
            // 
            this.btSaveScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveScript.Location = new System.Drawing.Point(563, 560);
            this.btSaveScript.Name = "btSaveScript";
            this.btSaveScript.Size = new System.Drawing.Size(109, 23);
            this.btSaveScript.TabIndex = 11;
            this.btSaveScript.Text = "Сохранить скрипт";
            this.btSaveScript.UseVisualStyleBackColor = true;
            this.btSaveScript.Click += new System.EventHandler(this.btSaveScript_Click);
            // 
            // tbScriptBody
            // 
            this.tbScriptBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScriptBody.Location = new System.Drawing.Point(3, 133);
            this.tbScriptBody.Multiline = true;
            this.tbScriptBody.Name = "tbScriptBody";
            this.tbScriptBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScriptBody.Size = new System.Drawing.Size(669, 421);
            this.tbScriptBody.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Связка TFS-DB";
            // 
            // cbxTfsDbLinc
            // 
            this.cbxTfsDbLinc.DisplayMember = "Name";
            this.cbxTfsDbLinc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTfsDbLinc.FormattingEnabled = true;
            this.cbxTfsDbLinc.Location = new System.Drawing.Point(94, 3);
            this.cbxTfsDbLinc.Name = "cbxTfsDbLinc";
            this.cbxTfsDbLinc.Size = new System.Drawing.Size(210, 21);
            this.cbxTfsDbLinc.TabIndex = 8;
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.Location = new System.Drawing.Point(532, 104);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(129, 23);
            this.btClear.TabIndex = 16;
            this.btClear.Text = "Очистить поля ввода";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btTfsDbLinkSettings);
            this.panel1.Controls.Add(this.btClear);
            this.panel1.Controls.Add(this.chbTransaction);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbComment);
            this.panel1.Controls.Add(this.btSaveScript);
            this.panel1.Controls.Add(this.tbScriptBody);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbxTfsDbLinc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.MinimumSize = new System.Drawing.Size(450, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 591);
            this.panel1.TabIndex = 17;
            // 
            // btTfsDbLinkSettings
            // 
            this.btTfsDbLinkSettings.Location = new System.Drawing.Point(310, 2);
            this.btTfsDbLinkSettings.Name = "btTfsDbLinkSettings";
            this.btTfsDbLinkSettings.Size = new System.Drawing.Size(75, 23);
            this.btTfsDbLinkSettings.TabIndex = 17;
            this.btTfsDbLinkSettings.Text = "Настройки";
            this.btTfsDbLinkSettings.UseVisualStyleBackColor = true;
            this.btTfsDbLinkSettings.Click += new System.EventHandler(this.btTfsDbLinkSettings_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(931, 597);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbIdTask);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.bttvQueryRefresh);
            this.panel2.Controls.Add(this.tvQuerys);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lbWorkItems);
            this.panel2.Controls.Add(this.btAddInIDTask);
            this.panel2.Controls.Add(this.btAddWorkItem);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lbLinkedWirkItem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(684, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 591);
            this.panel2.TabIndex = 18;
            // 
            // tbIdTask
            // 
            this.tbIdTask.Location = new System.Drawing.Point(146, 361);
            this.tbIdTask.Name = "tbIdTask";
            this.tbIdTask.Size = new System.Drawing.Size(92, 20);
            this.tbIdTask.TabIndex = 10;
            this.tbIdTask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Запросы в проекте";
            // 
            // bttvQueryRefresh
            // 
            this.bttvQueryRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bttvQueryRefresh.BackgroundImage")));
            this.bttvQueryRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bttvQueryRefresh.Location = new System.Drawing.Point(111, 3);
            this.bttvQueryRefresh.Name = "bttvQueryRefresh";
            this.bttvQueryRefresh.Size = new System.Drawing.Size(22, 21);
            this.bttvQueryRefresh.TabIndex = 2;
            this.bttvQueryRefresh.UseVisualStyleBackColor = true;
            this.bttvQueryRefresh.Click += new System.EventHandler(this.bttvQueryRefresh_Click);
            // 
            // tvQuerys
            // 
            this.tvQuerys.Location = new System.Drawing.Point(3, 24);
            this.tvQuerys.Name = "tvQuerys";
            this.tvQuerys.ShowNodeToolTips = true;
            this.tvQuerys.ShowPlusMinus = false;
            this.tvQuerys.ShowRootLines = false;
            this.tvQuerys.Size = new System.Drawing.Size(235, 150);
            this.tvQuerys.StateImageList = this.imageList1;
            this.tvQuerys.TabIndex = 0;
            this.tvQuerys.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvQuerys_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder");
            this.imageList1.Images.SetKeyName(1, "list");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Связанные рабочие элементы";
            // 
            // lbWorkItems
            // 
            this.lbWorkItems.FormattingEnabled = true;
            this.lbWorkItems.Location = new System.Drawing.Point(3, 203);
            this.lbWorkItems.Name = "lbWorkItems";
            this.lbWorkItems.ScrollAlwaysVisible = true;
            this.lbWorkItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbWorkItems.Size = new System.Drawing.Size(235, 121);
            this.lbWorkItems.TabIndex = 5;
            // 
            // btAddInIDTask
            // 
            this.btAddInIDTask.Location = new System.Drawing.Point(3, 359);
            this.btAddInIDTask.Name = "btAddInIDTask";
            this.btAddInIDTask.Size = new System.Drawing.Size(133, 23);
            this.btAddInIDTask.TabIndex = 9;
            this.btAddInIDTask.Text = "Добавить по номеру";
            this.btAddInIDTask.UseVisualStyleBackColor = true;
            this.btAddInIDTask.Click += new System.EventHandler(this.btAddInIDTask_Click);
            // 
            // btAddWorkItem
            // 
            this.btAddWorkItem.Location = new System.Drawing.Point(3, 330);
            this.btAddWorkItem.Name = "btAddWorkItem";
            this.btAddWorkItem.Size = new System.Drawing.Size(75, 23);
            this.btAddWorkItem.TabIndex = 8;
            this.btAddWorkItem.Text = "Добавить";
            this.btAddWorkItem.UseVisualStyleBackColor = true;
            this.btAddWorkItem.Click += new System.EventHandler(this.btAddWorkItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Рабочие элементы";
            // 
            // lbLinkedWirkItem
            // 
            this.lbLinkedWirkItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLinkedWirkItem.FormattingEnabled = true;
            this.lbLinkedWirkItem.Location = new System.Drawing.Point(3, 410);
            this.lbLinkedWirkItem.Name = "lbLinkedWirkItem";
            this.lbLinkedWirkItem.ScrollAlwaysVisible = true;
            this.lbLinkedWirkItem.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbLinkedWirkItem.Size = new System.Drawing.Size(235, 173);
            this.lbLinkedWirkItem.TabIndex = 6;
            this.lbLinkedWirkItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbLinkedWirkItem_KeyUp);
            this.lbLinkedWirkItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbLinkedWirkItem_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // UpdaterDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UpdaterDB";
            this.Size = new System.Drawing.Size(931, 597);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chbTransaction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Button btSaveScript;
        private System.Windows.Forms.TextBox tbScriptBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTfsDbLinc;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView tvQuerys;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button bttvQueryRefresh;
        private System.Windows.Forms.ListBox lbWorkItems;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btAddWorkItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbLinkedWirkItem;
        private System.Windows.Forms.Button btAddInIDTask;
        private System.Windows.Forms.TextBox tbIdTask;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btTfsDbLinkSettings;
    }
}
