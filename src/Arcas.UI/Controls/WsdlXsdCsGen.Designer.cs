namespace Arcas.Controls
{
    partial class WsdlXsdCsGen
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbGenClient = new System.Windows.Forms.RadioButton();
            this.rbGenService = new System.Windows.Forms.RadioButton();
            this.btSelFileForSaveWsdl = new System.Windows.Forms.Button();
            this.tbSaveWsdlTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTargetNamespaceWsdl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btGenerateCsFromWsdl = new System.Windows.Forms.Button();
            this.chbCreateAsuncMethod = new System.Windows.Forms.CheckBox();
            this.btFromFile = new System.Windows.Forms.Button();
            this.tbWsdlUri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btSetXsdFile = new System.Windows.Forms.Button();
            this.tbXsdUri = new System.Windows.Forms.TextBox();
            this.btSelFileForSaveXsd = new System.Windows.Forms.Button();
            this.tbSaveXsdTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTargetNamespaceXsd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btGenerateCsFromXsd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btSelFileForSaveWsdl);
            this.groupBox1.Controls.Add(this.tbSaveWsdlTo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbTargetNamespaceWsdl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btGenerateCsFromWsdl);
            this.groupBox1.Controls.Add(this.chbCreateAsuncMethod);
            this.groupBox1.Controls.Add(this.btFromFile);
            this.groupBox1.Controls.Add(this.tbWsdlUri);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Генерация из WSDL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbGenClient);
            this.groupBox2.Controls.Add(this.rbGenService);
            this.groupBox2.Location = new System.Drawing.Point(9, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 40);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Цель кода";
            // 
            // rbGenClient
            // 
            this.rbGenClient.AutoSize = true;
            this.rbGenClient.Checked = true;
            this.rbGenClient.Location = new System.Drawing.Point(6, 19);
            this.rbGenClient.Name = "rbGenClient";
            this.rbGenClient.Size = new System.Drawing.Size(61, 17);
            this.rbGenClient.TabIndex = 13;
            this.rbGenClient.TabStop = true;
            this.rbGenClient.Text = "Клиент";
            this.rbGenClient.UseVisualStyleBackColor = true;
            // 
            // rbGenService
            // 
            this.rbGenService.AutoSize = true;
            this.rbGenService.Location = new System.Drawing.Point(73, 19);
            this.rbGenService.Name = "rbGenService";
            this.rbGenService.Size = new System.Drawing.Size(62, 17);
            this.rbGenService.TabIndex = 14;
            this.rbGenService.Text = "Сервис";
            this.rbGenService.UseVisualStyleBackColor = true;
            // 
            // btSelFileForSaveWsdl
            // 
            this.btSelFileForSaveWsdl.Location = new System.Drawing.Point(117, 122);
            this.btSelFileForSaveWsdl.Name = "btSelFileForSaveWsdl";
            this.btSelFileForSaveWsdl.Size = new System.Drawing.Size(37, 23);
            this.btSelFileForSaveWsdl.TabIndex = 12;
            this.btSelFileForSaveWsdl.Text = "...";
            this.btSelFileForSaveWsdl.UseVisualStyleBackColor = true;
            this.btSelFileForSaveWsdl.Click += new System.EventHandler(this.btSelFileForSave_Click);
            // 
            // tbSaveWsdlTo
            // 
            this.tbSaveWsdlTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSaveWsdlTo.Location = new System.Drawing.Point(160, 124);
            this.tbSaveWsdlTo.MaxLength = 250;
            this.tbSaveWsdlTo.Name = "tbSaveWsdlTo";
            this.tbSaveWsdlTo.ReadOnly = true;
            this.tbSaveWsdlTo.Size = new System.Drawing.Size(481, 20);
            this.tbSaveWsdlTo.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Сохранить в файл";
            // 
            // tbTargetNamespaceWsdl
            // 
            this.tbTargetNamespaceWsdl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTargetNamespaceWsdl.Location = new System.Drawing.Point(182, 56);
            this.tbTargetNamespaceWsdl.MaxLength = 250;
            this.tbTargetNamespaceWsdl.Name = "tbTargetNamespaceWsdl";
            this.tbTargetNamespaceWsdl.Size = new System.Drawing.Size(459, 20);
            this.tbTargetNamespaceWsdl.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Целевое пространство имен C#";
            // 
            // btGenerateCsFromWsdl
            // 
            this.btGenerateCsFromWsdl.Location = new System.Drawing.Point(9, 155);
            this.btGenerateCsFromWsdl.Name = "btGenerateCsFromWsdl";
            this.btGenerateCsFromWsdl.Size = new System.Drawing.Size(75, 23);
            this.btGenerateCsFromWsdl.TabIndex = 4;
            this.btGenerateCsFromWsdl.Text = "Генерация кода";
            this.btGenerateCsFromWsdl.UseVisualStyleBackColor = true;
            this.btGenerateCsFromWsdl.Click += new System.EventHandler(this.btGenerateCsFromWsdl_Click);
            // 
            // chbCreateAsuncMethod
            // 
            this.chbCreateAsuncMethod.AutoSize = true;
            this.chbCreateAsuncMethod.Location = new System.Drawing.Point(160, 96);
            this.chbCreateAsuncMethod.Name = "chbCreateAsuncMethod";
            this.chbCreateAsuncMethod.Size = new System.Drawing.Size(192, 17);
            this.chbCreateAsuncMethod.TabIndex = 3;
            this.chbCreateAsuncMethod.Text = "Создавать асинхронные методы";
            this.chbCreateAsuncMethod.UseVisualStyleBackColor = true;
            // 
            // btFromFile
            // 
            this.btFromFile.Location = new System.Drawing.Point(87, 23);
            this.btFromFile.Name = "btFromFile";
            this.btFromFile.Size = new System.Drawing.Size(67, 23);
            this.btFromFile.TabIndex = 2;
            this.btFromFile.Text = "Из файла";
            this.btFromFile.UseVisualStyleBackColor = true;
            this.btFromFile.Click += new System.EventHandler(this.btFromFile_Click);
            // 
            // tbWsdlUri
            // 
            this.tbWsdlUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWsdlUri.Location = new System.Drawing.Point(160, 25);
            this.tbWsdlUri.MaxLength = 250;
            this.tbWsdlUri.Name = "tbWsdlUri";
            this.tbWsdlUri.Size = new System.Drawing.Size(481, 20);
            this.tbWsdlUri.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к WSDL";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(685, 521);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btSetXsdFile);
            this.groupBox3.Controls.Add(this.tbXsdUri);
            this.groupBox3.Controls.Add(this.btSelFileForSaveXsd);
            this.groupBox3.Controls.Add(this.tbSaveXsdTo);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbTargetNamespaceXsd);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btGenerateCsFromXsd);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(3, 197);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(672, 146);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Генерация из XSD";
            // 
            // btSetXsdFile
            // 
            this.btSetXsdFile.Location = new System.Drawing.Point(87, 23);
            this.btSetXsdFile.Name = "btSetXsdFile";
            this.btSetXsdFile.Size = new System.Drawing.Size(67, 23);
            this.btSetXsdFile.TabIndex = 14;
            this.btSetXsdFile.Text = "Из файла";
            this.btSetXsdFile.UseVisualStyleBackColor = true;
            this.btSetXsdFile.Click += new System.EventHandler(this.btSetXsdFile_Click);
            // 
            // tbXsdUri
            // 
            this.tbXsdUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbXsdUri.Location = new System.Drawing.Point(160, 25);
            this.tbXsdUri.MaxLength = 250;
            this.tbXsdUri.Name = "tbXsdUri";
            this.tbXsdUri.Size = new System.Drawing.Size(481, 20);
            this.tbXsdUri.TabIndex = 13;
            // 
            // btSelFileForSaveXsd
            // 
            this.btSelFileForSaveXsd.Location = new System.Drawing.Point(117, 82);
            this.btSelFileForSaveXsd.Name = "btSelFileForSaveXsd";
            this.btSelFileForSaveXsd.Size = new System.Drawing.Size(37, 23);
            this.btSelFileForSaveXsd.TabIndex = 12;
            this.btSelFileForSaveXsd.Text = "...";
            this.btSelFileForSaveXsd.UseVisualStyleBackColor = true;
            this.btSelFileForSaveXsd.Click += new System.EventHandler(this.btSelFileForSaveXsd_Click);
            // 
            // tbSaveXsdTo
            // 
            this.tbSaveXsdTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSaveXsdTo.Location = new System.Drawing.Point(160, 84);
            this.tbSaveXsdTo.MaxLength = 250;
            this.tbSaveXsdTo.Name = "tbSaveXsdTo";
            this.tbSaveXsdTo.ReadOnly = true;
            this.tbSaveXsdTo.Size = new System.Drawing.Size(481, 20);
            this.tbSaveXsdTo.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Сохранить в файл";
            // 
            // tbTargetNamespaceXsd
            // 
            this.tbTargetNamespaceXsd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTargetNamespaceXsd.Location = new System.Drawing.Point(182, 56);
            this.tbTargetNamespaceXsd.MaxLength = 250;
            this.tbTargetNamespaceXsd.Name = "tbTargetNamespaceXsd";
            this.tbTargetNamespaceXsd.Size = new System.Drawing.Size(459, 20);
            this.tbTargetNamespaceXsd.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Целевое пространство имен C#";
            // 
            // btGenerateCsFromXsd
            // 
            this.btGenerateCsFromXsd.Location = new System.Drawing.Point(9, 115);
            this.btGenerateCsFromXsd.Name = "btGenerateCsFromXsd";
            this.btGenerateCsFromXsd.Size = new System.Drawing.Size(75, 23);
            this.btGenerateCsFromXsd.TabIndex = 4;
            this.btGenerateCsFromXsd.Text = "Генерация кода";
            this.btGenerateCsFromXsd.UseVisualStyleBackColor = true;
            this.btGenerateCsFromXsd.Click += new System.EventHandler(this.btGenerateCsFromXsd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Путь к XSD";
            // 
            // WsdlXsdCsGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "WsdlXsdCsGen";
            this.Size = new System.Drawing.Size(685, 521);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btFromFile;
        private System.Windows.Forms.TextBox tbWsdlUri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGenerateCsFromWsdl;
        private System.Windows.Forms.CheckBox chbCreateAsuncMethod;
        private System.Windows.Forms.TextBox tbTargetNamespaceWsdl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSelFileForSaveWsdl;
        private System.Windows.Forms.TextBox tbSaveWsdlTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbGenClient;
        private System.Windows.Forms.RadioButton rbGenService;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btSelFileForSaveXsd;
        private System.Windows.Forms.TextBox tbSaveXsdTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTargetNamespaceXsd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btGenerateCsFromXsd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btSetXsdFile;
        private System.Windows.Forms.TextBox tbXsdUri;
    }
}
