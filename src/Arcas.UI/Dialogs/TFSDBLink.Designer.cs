namespace Arcas.Settings
{
    partial class TFSDBLinkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btDelete = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.dgvTFSDB = new System.Windows.Forms.DataGridView();
            this.LinkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TFS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTFSDB)).BeginInit();
            this.SuspendLayout();
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(113, 12);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 3;
            this.btDelete.Text = "Удалить";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(12, 12);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 4;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // dgvTFSDB
            // 
            this.dgvTFSDB.AllowUserToAddRows = false;
            this.dgvTFSDB.AllowUserToDeleteRows = false;
            this.dgvTFSDB.AllowUserToResizeRows = false;
            this.dgvTFSDB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTFSDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTFSDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTFSDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LinkName,
            this.TFS,
            this.DB});
            this.dgvTFSDB.Location = new System.Drawing.Point(12, 41);
            this.dgvTFSDB.MultiSelect = false;
            this.dgvTFSDB.Name = "dgvTFSDB";
            this.dgvTFSDB.ReadOnly = true;
            this.dgvTFSDB.RowHeadersVisible = false;
            this.dgvTFSDB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTFSDB.ShowEditingIcon = false;
            this.dgvTFSDB.ShowRowErrors = false;
            this.dgvTFSDB.Size = new System.Drawing.Size(540, 201);
            this.dgvTFSDB.TabIndex = 5;
            this.dgvTFSDB.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTFSDB_CellMouseDoubleClick);
            // 
            // LinkName
            // 
            this.LinkName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LinkName.DataPropertyName = "Name";
            this.LinkName.HeaderText = "Наименование";
            this.LinkName.Name = "LinkName";
            this.LinkName.ReadOnly = true;
            this.LinkName.Width = 108;
            // 
            // TFS
            // 
            this.TFS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TFS.DataPropertyName = "ServerUri";
            this.TFS.HeaderText = "TFS проект";
            this.TFS.Name = "TFS";
            this.TFS.ReadOnly = true;
            this.TFS.Width = 90;
            // 
            // DB
            // 
            this.DB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DB.DataPropertyName = "ServerPathToSettings";
            this.DB.HeaderText = "Файл настроек";
            this.DB.Name = "DB";
            this.DB.ReadOnly = true;
            // 
            // TFSDBLinkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 297);
            this.Controls.Add(this.dgvTFSDB);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "TFSDBLinkForm";
            this.ShowIcon = false;
            this.Text = "Связка TFS-DB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.tFSDBLinkForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tFSDBLinkForm_KeyDown);
            this.Controls.SetChildIndex(this.btDelete, 0);
            this.Controls.SetChildIndex(this.btAdd, 0);
            this.Controls.SetChildIndex(this.dgvTFSDB, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTFSDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.DataGridView dgvTFSDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TFS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB;
    }
}