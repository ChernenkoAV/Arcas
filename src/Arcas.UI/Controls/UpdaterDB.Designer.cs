namespace Arcas.Controls
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
            this.rtbScriptBody = new System.Windows.Forms.RichTextBox();
            this.cmsScriptArea = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTextSelectCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPasteText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTextSelectCute = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTextSelectDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiClearScriptText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiInsertBinfile = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTfsDbLinc = new System.Windows.Forms.ComboBox();
            this.btClear = new System.Windows.Forms.Button();
            this.panelScript = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.btTfsDbLinkSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTfsWorkItems = new System.Windows.Forms.Panel();
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
            this.cmsLinkedWorkItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bwRequestTfs = new System.ComponentModel.BackgroundWorker();
            this.cmsScriptArea.SuspendLayout();
            this.panelScript.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelTfsWorkItems.SuspendLayout();
            this.cmsLinkedWorkItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbTransaction
            // 
            this.chbTransaction.AutoSize = true;
            this.chbTransaction.Checked = true;
            this.chbTransaction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTransaction.Location = new System.Drawing.Point(158, 4);
            this.chbTransaction.Name = "chbTransaction";
            this.chbTransaction.Size = new System.Drawing.Size(159, 17);
            this.chbTransaction.TabIndex = 15;
            this.chbTransaction.Text = "Выполнять в транзанкции";
            this.chbTransaction.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Тело скрипта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Комментарий к накатке";
            // 
            // tbComment
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.Location = new System.Drawing.Point(3, 22);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbComment.Size = new System.Drawing.Size(663, 50);
            this.tbComment.TabIndex = 12;
            // 
            // btSaveScript
            // 
            this.btSaveScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveScript.Location = new System.Drawing.Point(557, 519);
            this.btSaveScript.Name = "btSaveScript";
            this.btSaveScript.Size = new System.Drawing.Size(109, 23);
            this.btSaveScript.TabIndex = 11;
            this.btSaveScript.Text = "Сохранить скрипт";
            this.btSaveScript.UseVisualStyleBackColor = true;
            this.btSaveScript.Click += new System.EventHandler(this.btSaveScript_Click);
            // 
            // rtbScriptBody
            // 
            this.rtbScriptBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbScriptBody.AutoWordSelection = true;
            this.rtbScriptBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbScriptBody.ContextMenuStrip = this.cmsScriptArea;
            this.rtbScriptBody.Location = new System.Drawing.Point(3, 102);
            this.rtbScriptBody.MaxLength = 0;
            this.rtbScriptBody.Name = "rtbScriptBody";
            this.rtbScriptBody.Size = new System.Drawing.Size(663, 410);
            this.rtbScriptBody.TabIndex = 10;
            this.rtbScriptBody.Text = "";
            this.rtbScriptBody.TextChanged += new System.EventHandler(this.tbScriptBody_TextChanged);
            this.rtbScriptBody.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbScriptBody_MouseDown);
            // 
            // cmsScriptArea
            // 
            this.cmsScriptArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTextSelectCopy,
            this.tsmiPasteText,
            this.tsmiTextSelectCute,
            this.tsmiTextSelectDelete,
            this.toolStripMenuItem2,
            this.tsmiClearScriptText,
            this.toolStripMenuItem1,
            this.tsmiInsertBinfile});
            this.cmsScriptArea.Name = "contextMenuStrip1";
            this.cmsScriptArea.Size = new System.Drawing.Size(303, 148);
            this.cmsScriptArea.Opening += new System.ComponentModel.CancelEventHandler(this.cmsScriptArea_Opening);
            // 
            // tsmiTextSelectCopy
            // 
            this.tsmiTextSelectCopy.Name = "tsmiTextSelectCopy";
            this.tsmiTextSelectCopy.Size = new System.Drawing.Size(302, 22);
            this.tsmiTextSelectCopy.Text = "Копировать";
            this.tsmiTextSelectCopy.Click += new System.EventHandler(this.tsmiCopySelect_Click);
            // 
            // tsmiPasteText
            // 
            this.tsmiPasteText.Name = "tsmiPasteText";
            this.tsmiPasteText.Size = new System.Drawing.Size(302, 22);
            this.tsmiPasteText.Text = "Вставить";
            this.tsmiPasteText.Click += new System.EventHandler(this.tsmiPaste_Click);
            // 
            // tsmiTextSelectCute
            // 
            this.tsmiTextSelectCute.Name = "tsmiTextSelectCute";
            this.tsmiTextSelectCute.Size = new System.Drawing.Size(302, 22);
            this.tsmiTextSelectCute.Text = "Вырезать";
            this.tsmiTextSelectCute.Click += new System.EventHandler(this.tsmiTextSelectCute_Click);
            // 
            // tsmiTextSelectDelete
            // 
            this.tsmiTextSelectDelete.Name = "tsmiTextSelectDelete";
            this.tsmiTextSelectDelete.Size = new System.Drawing.Size(302, 22);
            this.tsmiTextSelectDelete.Text = "Удалить";
            this.tsmiTextSelectDelete.Click += new System.EventHandler(this.tsmiDeleteText_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(299, 6);
            // 
            // tsmiClearScriptText
            // 
            this.tsmiClearScriptText.Name = "tsmiClearScriptText";
            this.tsmiClearScriptText.Size = new System.Drawing.Size(302, 22);
            this.tsmiClearScriptText.Text = "Очистить тело скрипта";
            this.tsmiClearScriptText.Click += new System.EventHandler(this.tsmiClearScriptText_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(299, 6);
            // 
            // tsmiInsertBinfile
            // 
            this.tsmiInsertBinfile.Name = "tsmiInsertBinfile";
            this.tsmiInsertBinfile.Size = new System.Drawing.Size(302, 22);
            this.tsmiInsertBinfile.Text = "Вставить бинарное представление файла";
            this.tsmiInsertBinfile.Click += new System.EventHandler(this.tsmiInsertBinfile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
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
            this.cbxTfsDbLinc.Location = new System.Drawing.Point(98, 5);
            this.cbxTfsDbLinc.Name = "cbxTfsDbLinc";
            this.cbxTfsDbLinc.Size = new System.Drawing.Size(210, 21);
            this.cbxTfsDbLinc.TabIndex = 8;
            this.cbxTfsDbLinc.SelectionChangeCommitted += new System.EventHandler(this.cbxTfsDbLinc_SelectionChangeCommitted);
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.Location = new System.Drawing.Point(526, 76);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(129, 23);
            this.btClear.TabIndex = 16;
            this.btClear.Text = "Очистить поля ввода";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // panelScript
            // 
            this.panelScript.Controls.Add(this.btClear);
            this.panelScript.Controls.Add(this.chbTransaction);
            this.panelScript.Controls.Add(this.label3);
            this.panelScript.Controls.Add(this.label2);
            this.panelScript.Controls.Add(this.tbComment);
            this.panelScript.Controls.Add(this.btSaveScript);
            this.panelScript.Controls.Add(this.rtbScriptBody);
            this.panelScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScript.Location = new System.Drawing.Point(3, 38);
            this.panelScript.MinimumSize = new System.Drawing.Size(450, 300);
            this.panelScript.Name = "panelScript";
            this.panelScript.Size = new System.Drawing.Size(669, 550);
            this.panelScript.TabIndex = 17;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.btTfsDbLinkSettings);
            this.panelSettings.Controls.Add(this.label1);
            this.panelSettings.Controls.Add(this.cbxTfsDbLinc);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(3, 3);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(669, 29);
            this.panelSettings.TabIndex = 18;
            // 
            // btTfsDbLinkSettings
            // 
            this.btTfsDbLinkSettings.Location = new System.Drawing.Point(314, 4);
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelTfsWorkItems, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 597F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(931, 597);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panelSettings, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelScript, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(675, 591);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // panelTfsWorkItems
            // 
            this.panelTfsWorkItems.Controls.Add(this.tbIdTask);
            this.panelTfsWorkItems.Controls.Add(this.label4);
            this.panelTfsWorkItems.Controls.Add(this.bttvQueryRefresh);
            this.panelTfsWorkItems.Controls.Add(this.tvQuerys);
            this.panelTfsWorkItems.Controls.Add(this.label6);
            this.panelTfsWorkItems.Controls.Add(this.lbWorkItems);
            this.panelTfsWorkItems.Controls.Add(this.btAddInIDTask);
            this.panelTfsWorkItems.Controls.Add(this.btAddWorkItem);
            this.panelTfsWorkItems.Controls.Add(this.label5);
            this.panelTfsWorkItems.Controls.Add(this.lbLinkedWirkItem);
            this.panelTfsWorkItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTfsWorkItems.Location = new System.Drawing.Point(684, 3);
            this.panelTfsWorkItems.Name = "panelTfsWorkItems";
            this.panelTfsWorkItems.Size = new System.Drawing.Size(244, 591);
            this.panelTfsWorkItems.TabIndex = 18;
            // 
            // tbIdTask
            // 
            this.tbIdTask.Location = new System.Drawing.Point(146, 361);
            this.tbIdTask.Name = "tbIdTask";
            this.tbIdTask.Size = new System.Drawing.Size(92, 20);
            this.tbIdTask.TabIndex = 10;
            this.tbIdTask.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbIdTask_KeyDown);
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
            this.lbLinkedWirkItem.Size = new System.Drawing.Size(235, 160);
            this.lbLinkedWirkItem.TabIndex = 6;
            this.lbLinkedWirkItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbLinkedWirkItem_KeyUp);
            this.lbLinkedWirkItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbLinkedWirkItem_MouseDown);
            // 
            // cmsLinkedWorkItems
            // 
            this.cmsLinkedWorkItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsLinkedWorkItems.Name = "contextMenuStrip1";
            this.cmsLinkedWorkItems.Size = new System.Drawing.Size(119, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // bwRequestTfs
            // 
            this.bwRequestTfs.WorkerReportsProgress = true;
            this.bwRequestTfs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRequestTfs_DoWork);
            this.bwRequestTfs.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            this.bwRequestTfs.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRequestTfs_RunWorkerCompleted);
            // 
            // UpdaterDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UpdaterDB";
            this.Size = new System.Drawing.Size(931, 597);
            this.cmsScriptArea.ResumeLayout(false);
            this.panelScript.ResumeLayout(false);
            this.panelScript.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelTfsWorkItems.ResumeLayout(false);
            this.panelTfsWorkItems.PerformLayout();
            this.cmsLinkedWorkItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chbTransaction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Button btSaveScript;
        private System.Windows.Forms.RichTextBox rtbScriptBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTfsDbLinc;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Panel panelScript;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTfsWorkItems;
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
        private System.Windows.Forms.ContextMenuStrip cmsLinkedWorkItems;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btTfsDbLinkSettings;
        private System.Windows.Forms.ContextMenuStrip cmsScriptArea;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearScriptText;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiInsertBinfile;
        private System.Windows.Forms.ToolStripMenuItem tsmiTextSelectCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiPasteText;
        private System.Windows.Forms.ToolStripMenuItem tsmiTextSelectCute;
        private System.Windows.Forms.ToolStripMenuItem tsmiTextSelectDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.ComponentModel.BackgroundWorker bwRequestTfs;
    }
}
