namespace Arcas.Settings
{
    partial class CreateSettingUpdater
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSettingName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTfsProject = new System.Windows.Forms.TextBox();
            this.tbSetFileServerFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFileNameSet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btPathFoldertoFileSet = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbFormatBinFormat = new System.Windows.Forms.TextBox();
            this.tbFormatBinPrefix = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbScriptUpdateVer = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btScriptFolder = new System.Windows.Forms.Button();
            this.tbPartAfterScript = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPartBeforescript = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btChekConnection = new System.Windows.Forms.Button();
            this.cmbDbConectionType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.tbFolderForScripts = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbNumberTask = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.export = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 28);
            this.label1.TabIndex = 10000;
            this.label1.Text = "Наименование связки (локально)";
            // 
            // tbSettingName
            // 
            this.tbSettingName.Location = new System.Drawing.Point(119, 19);
            this.tbSettingName.MaxLength = 50;
            this.tbSettingName.Name = "tbSettingName";
            this.tbSettingName.Size = new System.Drawing.Size(306, 20);
            this.tbSettingName.TabIndex = 10001;
            this.tbSettingName.Validating += new System.ComponentModel.CancelEventHandler(this.tbSettingName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 10003;
            this.label2.Text = "Проект TFS";
            // 
            // tbTfsProject
            // 
            this.tbTfsProject.Location = new System.Drawing.Point(119, 54);
            this.tbTfsProject.Name = "tbTfsProject";
            this.tbTfsProject.ReadOnly = true;
            this.tbTfsProject.Size = new System.Drawing.Size(306, 20);
            this.tbTfsProject.TabIndex = 10004;
            // 
            // tbSetFileServerFolder
            // 
            this.tbSetFileServerFolder.Location = new System.Drawing.Point(119, 128);
            this.tbSetFileServerFolder.Name = "tbSetFileServerFolder";
            this.tbSetFileServerFolder.ReadOnly = true;
            this.tbSetFileServerFolder.Size = new System.Drawing.Size(306, 20);
            this.tbSetFileServerFolder.TabIndex = 10007;
            this.tbSetFileServerFolder.Validating += new System.ComponentModel.CancelEventHandler(this.tbSetFileServerFolder_Validating);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 41);
            this.label3.TabIndex = 10006;
            this.label3.Text = "Путь на сервере для хранения файла настроек";
            // 
            // tbFileNameSet
            // 
            this.tbFileNameSet.Location = new System.Drawing.Point(119, 90);
            this.tbFileNameSet.MaxLength = 50;
            this.tbFileNameSet.Name = "tbFileNameSet";
            this.tbFileNameSet.Size = new System.Drawing.Size(306, 20);
            this.tbFileNameSet.TabIndex = 10009;
            this.tbFileNameSet.Validating += new System.ComponentModel.CancelEventHandler(this.tbSetFileName_Validating);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 28);
            this.label4.TabIndex = 10008;
            this.label4.Text = "Имя файла настроек";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btPathFoldertoFileSet);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbSetFileServerFolder);
            this.groupBox1.Controls.Add(this.tbTfsProject);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbSettingName);
            this.groupBox1.Controls.Add(this.tbFileNameSet);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 178);
            this.groupBox1.TabIndex = 10011;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настроки хранения файла настроек";
            // 
            // btPathFoldertoFileSet
            // 
            this.btPathFoldertoFileSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btPathFoldertoFileSet.Location = new System.Drawing.Point(448, 126);
            this.btPathFoldertoFileSet.Name = "btPathFoldertoFileSet";
            this.btPathFoldertoFileSet.Size = new System.Drawing.Size(24, 23);
            this.btPathFoldertoFileSet.TabIndex = 10010;
            this.btPathFoldertoFileSet.UseVisualStyleBackColor = true;
            this.btPathFoldertoFileSet.Click += new System.EventHandler(this.btPathFoldertoFileSet_Click);
            this.btPathFoldertoFileSet.Validating += new System.ComponentModel.CancelEventHandler(this.tbSetFileServerFolder_Validating);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(12, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 378);
            this.groupBox2.TabIndex = 10012;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки накатки";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.tbScriptUpdateVer);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btScriptFolder);
            this.panel2.Controls.Add(this.tbPartAfterScript);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.tbPartBeforescript);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btChekConnection);
            this.panel2.Controls.Add(this.cmbDbConectionType);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.tbConnectionString);
            this.panel2.Controls.Add(this.tbFolderForScripts);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 359);
            this.panel2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbFormatBinFormat);
            this.groupBox3.Controls.Add(this.tbFormatBinPrefix);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(6, 453);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(440, 44);
            this.groupBox3.TabIndex = 10027;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Формат для вставки бинарного представления файла";
            // 
            // tbFormatBinFormat
            // 
            this.tbFormatBinFormat.Location = new System.Drawing.Point(261, 16);
            this.tbFormatBinFormat.MaxLength = 10;
            this.tbFormatBinFormat.Name = "tbFormatBinFormat";
            this.tbFormatBinFormat.Size = new System.Drawing.Size(52, 20);
            this.tbFormatBinFormat.TabIndex = 3;
            this.tbFormatBinFormat.Validating += new System.ComponentModel.CancelEventHandler(this.tbFormatBinFormat_Validating);
            // 
            // tbFormatBinPrefix
            // 
            this.tbFormatBinPrefix.Location = new System.Drawing.Point(58, 16);
            this.tbFormatBinPrefix.MaxLength = 10;
            this.tbFormatBinPrefix.Name = "tbFormatBinPrefix";
            this.tbFormatBinPrefix.Size = new System.Drawing.Size(52, 20);
            this.tbFormatBinPrefix.TabIndex = 2;
            this.tbFormatBinPrefix.Validating += new System.ComponentModel.CancelEventHandler(this.tbFormatBinPrefix_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(153, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Формат для байта";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Префикс";
            // 
            // tbScriptUpdateVer
            // 
            this.tbScriptUpdateVer.Location = new System.Drawing.Point(6, 269);
            this.tbScriptUpdateVer.Multiline = true;
            this.tbScriptUpdateVer.Name = "tbScriptUpdateVer";
            this.tbScriptUpdateVer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScriptUpdateVer.Size = new System.Drawing.Size(440, 43);
            this.tbScriptUpdateVer.TabIndex = 10026;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 221);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(451, 46);
            this.label12.TabIndex = 10025;
            this.label12.Text = "Скрипт обновления значения версии в БД. Идет после основного тела скрипта изменен" +
    "ий. Текстовка оборачиваются в String.Format(... Параметр: 0 - сгенернная версия " +
    "(String) формат \"000000 yyyy-MM-dd\"\r\n";
            // 
            // btScriptFolder
            // 
            this.btScriptFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btScriptFolder.Location = new System.Drawing.Point(445, 8);
            this.btScriptFolder.Name = "btScriptFolder";
            this.btScriptFolder.Size = new System.Drawing.Size(24, 23);
            this.btScriptFolder.TabIndex = 10011;
            this.btScriptFolder.UseVisualStyleBackColor = true;
            this.btScriptFolder.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbPartAfterScript
            // 
            this.tbPartAfterScript.Location = new System.Drawing.Point(6, 356);
            this.tbPartAfterScript.Multiline = true;
            this.tbPartAfterScript.Name = "tbPartAfterScript";
            this.tbPartAfterScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPartAfterScript.Size = new System.Drawing.Size(440, 91);
            this.tbPartAfterScript.TabIndex = 10023;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 324);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(447, 28);
            this.label10.TabIndex = 10022;
            this.label10.Text = "Часть скрипта, идущая ПОСЛЕ  основного тела скрипта версии ( + обновления значени" +
    "я версии) ПРИ НАЛИЧИИ ТРАНЗАКЦИИ";
            // 
            // tbPartBeforescript
            // 
            this.tbPartBeforescript.Location = new System.Drawing.Point(6, 165);
            this.tbPartBeforescript.Multiline = true;
            this.tbPartBeforescript.Name = "tbPartBeforescript";
            this.tbPartBeforescript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPartBeforescript.Size = new System.Drawing.Size(440, 49);
            this.tbPartBeforescript.TabIndex = 10021;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(443, 30);
            this.label9.TabIndex = 10020;
            this.label9.Text = "Часть скрипта, идущая ПЕРЕД основным телом скрипта версии при НАЛИЧИИ ТРАНЗАКЦИИ";
            // 
            // btChekConnection
            // 
            this.btChekConnection.Enabled = false;
            this.btChekConnection.Location = new System.Drawing.Point(116, 104);
            this.btChekConnection.Name = "btChekConnection";
            this.btChekConnection.Size = new System.Drawing.Size(176, 23);
            this.btChekConnection.TabIndex = 10019;
            this.btChekConnection.Text = "Проверить подключение";
            this.btChekConnection.UseVisualStyleBackColor = true;
            this.btChekConnection.Click += new System.EventHandler(this.btChekConnection_Click);
            // 
            // cmbDbConectionType
            // 
            this.cmbDbConectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDbConectionType.FormattingEnabled = true;
            this.cmbDbConectionType.Location = new System.Drawing.Point(116, 43);
            this.cmbDbConectionType.Name = "cmbDbConectionType";
            this.cmbDbConectionType.Size = new System.Drawing.Size(306, 21);
            this.cmbDbConectionType.TabIndex = 10016;
            this.cmbDbConectionType.SelectedIndexChanged += new System.EventHandler(this.cmbDbConectionType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 28);
            this.label7.TabIndex = 10015;
            this.label7.Text = "Тип конекшена к серверу БД";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 28);
            this.label6.TabIndex = 10013;
            this.label6.Text = "Строка соединения с модельной БД.";
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Location = new System.Drawing.Point(116, 78);
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.Size = new System.Drawing.Size(306, 20);
            this.tbConnectionString.TabIndex = 10014;
            this.tbConnectionString.TextChanged += new System.EventHandler(this.tbConnectionString_TextChanged);
            this.tbConnectionString.Validating += new System.ComponentModel.CancelEventHandler(this.tbConnectionString_Validating);
            // 
            // tbFolderForScripts
            // 
            this.tbFolderForScripts.Location = new System.Drawing.Point(116, 10);
            this.tbFolderForScripts.Name = "tbFolderForScripts";
            this.tbFolderForScripts.ReadOnly = true;
            this.tbFolderForScripts.Size = new System.Drawing.Size(306, 20);
            this.tbFolderForScripts.TabIndex = 10011;
            this.tbFolderForScripts.Validating += new System.ComponentModel.CancelEventHandler(this.tbFolderForScripts_Validating);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 34);
            this.label5.TabIndex = 0;
            this.label5.Text = "Путь на сервере для скриптов";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(18, 577);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 28);
            this.label11.TabIndex = 10013;
            this.label11.Text = "Номер таска, под который зачекинить настройки";
            // 
            // tbNumberTask
            // 
            this.tbNumberTask.Location = new System.Drawing.Point(177, 580);
            this.tbNumberTask.MaxLength = 50;
            this.tbNumberTask.Name = "tbNumberTask";
            this.tbNumberTask.Size = new System.Drawing.Size(260, 20);
            this.tbNumberTask.TabIndex = 10014;
            this.tbNumberTask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumberTask_KeyPress);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // export
            // 
            this.export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.export.Location = new System.Drawing.Point(463, 577);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(21, 23);
            this.export.TabIndex = 10015;
            this.export.Text = "Экспорт";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // import
            // 
            this.import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.import.Location = new System.Drawing.Point(490, 577);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(21, 23);
            this.import.TabIndex = 10016;
            this.import.Text = "Импорт";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // CreateSettingUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 663);
            this.Controls.Add(this.import);
            this.Controls.Add(this.export);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbNumberTask);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "CreateSettingUpdater";
            this.ShowIcon = false;
            this.Text = "Создание связки TFS-DB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateSettingUpdater_FormClosing);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.tbNumberTask, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.export, 0);
            this.Controls.SetChildIndex(this.import, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSettingName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTfsProject;
        private System.Windows.Forms.TextBox tbSetFileServerFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFileNameSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFolderForScripts;
        private System.Windows.Forms.ComboBox cmbDbConectionType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.TextBox tbPartAfterScript;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPartBeforescript;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btChekConnection;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbNumberTask;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btPathFoldertoFileSet;
        private System.Windows.Forms.Button btScriptFolder;
        private System.Windows.Forms.TextBox tbScriptUpdateVer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbFormatBinFormat;
        private System.Windows.Forms.TextBox tbFormatBinPrefix;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button export;
    }
}