namespace Arcas.Controls
{
    partial class IbmMqTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.tbManagerName = new System.Windows.Forms.TextBox();
            this.tbChannelName = new System.Windows.Forms.TextBox();
            this.tbQueueName = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvAddProperties = new System.Windows.Forms.DataGridView();
            this.APKeyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMessageID = new System.Windows.Forms.TextBox();
            this.tbBodyMessage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btSend = new System.Windows.Forms.Button();
            this.btGetMessage = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chbRollbakGet = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPutDate = new System.Windows.Forms.TextBox();
            this.btSendFromFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Хост";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя канала";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Имя менеджера";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Логин";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Имя очереди";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Пароль";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(108, 13);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(206, 20);
            this.tbHost.TabIndex = 6;
            // 
            // tbManagerName
            // 
            this.tbManagerName.Location = new System.Drawing.Point(108, 65);
            this.tbManagerName.Name = "tbManagerName";
            this.tbManagerName.Size = new System.Drawing.Size(206, 20);
            this.tbManagerName.TabIndex = 7;
            // 
            // tbChannelName
            // 
            this.tbChannelName.Location = new System.Drawing.Point(108, 39);
            this.tbChannelName.Name = "tbChannelName";
            this.tbChannelName.Size = new System.Drawing.Size(206, 20);
            this.tbChannelName.TabIndex = 8;
            // 
            // tbQueueName
            // 
            this.tbQueueName.Location = new System.Drawing.Point(108, 90);
            this.tbQueueName.Name = "tbQueueName";
            this.tbQueueName.Size = new System.Drawing.Size(206, 20);
            this.tbQueueName.TabIndex = 9;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(108, 130);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(206, 20);
            this.tbUser.TabIndex = 10;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(108, 156);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(206, 20);
            this.tbPass.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(345, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Дополнительные свойства сообщения";
            // 
            // dgvAddProperties
            // 
            this.dgvAddProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAddProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.APKeyCol,
            this.APValueCol});
            this.dgvAddProperties.Location = new System.Drawing.Point(348, 39);
            this.dgvAddProperties.Name = "dgvAddProperties";
            this.dgvAddProperties.RowHeadersWidth = 20;
            this.dgvAddProperties.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAddProperties.Size = new System.Drawing.Size(362, 162);
            this.dgvAddProperties.TabIndex = 13;
            // 
            // APKeyCol
            // 
            this.APKeyCol.HeaderText = "Ключ";
            this.APKeyCol.Name = "APKeyCol";
            // 
            // APValueCol
            // 
            this.APValueCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.APValueCol.HeaderText = "Значение";
            this.APValueCol.Name = "APValueCol";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "MessageID";
            // 
            // tbMessageID
            // 
            this.tbMessageID.Location = new System.Drawing.Point(108, 188);
            this.tbMessageID.Name = "tbMessageID";
            this.tbMessageID.ReadOnly = true;
            this.tbMessageID.Size = new System.Drawing.Size(206, 20);
            this.tbMessageID.TabIndex = 15;
            // 
            // tbBodyMessage
            // 
            this.tbBodyMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBodyMessage.Location = new System.Drawing.Point(3, 282);
            this.tbBodyMessage.Multiline = true;
            this.tbBodyMessage.Name = "tbBodyMessage";
            this.tbBodyMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBodyMessage.Size = new System.Drawing.Size(731, 218);
            this.tbBodyMessage.TabIndex = 16;
            this.tbBodyMessage.TextChanged += new System.EventHandler(this.tbBodyMessage_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Тело сообщения";
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(348, 207);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(90, 23);
            this.btSend.TabIndex = 18;
            this.btSend.Text = "Посыл в Mq";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btGetMessage
            // 
            this.btGetMessage.Location = new System.Drawing.Point(503, 207);
            this.btGetMessage.Name = "btGetMessage";
            this.btGetMessage.Size = new System.Drawing.Size(106, 23);
            this.btGetMessage.TabIndex = 19;
            this.btGetMessage.Text = "Прочитать из Mq";
            this.btGetMessage.UseVisualStyleBackColor = true;
            this.btGetMessage.Click += new System.EventHandler(this.btGetMessage_Click);
            // 
            // chbRollbakGet
            // 
            this.chbRollbakGet.AutoSize = true;
            this.chbRollbakGet.Checked = true;
            this.chbRollbakGet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRollbakGet.Location = new System.Drawing.Point(503, 232);
            this.chbRollbakGet.Name = "chbRollbakGet";
            this.chbRollbakGet.Size = new System.Drawing.Size(218, 17);
            this.chbRollbakGet.TabIndex = 20;
            this.chbRollbakGet.Text = "Откатить чтение (оставить в очереди)";
            this.chbRollbakGet.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "PutDate";
            // 
            // tbPutDate
            // 
            this.tbPutDate.Location = new System.Drawing.Point(108, 214);
            this.tbPutDate.Name = "tbPutDate";
            this.tbPutDate.ReadOnly = true;
            this.tbPutDate.Size = new System.Drawing.Size(206, 20);
            this.tbPutDate.TabIndex = 22;
            // 
            // btSendFromFile
            // 
            this.btSendFromFile.Location = new System.Drawing.Point(135, 253);
            this.btSendFromFile.Name = "btSendFromFile";
            this.btSendFromFile.Size = new System.Drawing.Size(179, 23);
            this.btSendFromFile.TabIndex = 23;
            this.btSendFromFile.Text = "Посыл в Mq из файла(ов)";
            this.btSendFromFile.UseVisualStyleBackColor = true;
            this.btSendFromFile.Click += new System.EventHandler(this.btSendFromFile_Click);
            // 
            // IbmMqTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btSendFromFile);
            this.Controls.Add(this.tbPutDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chbRollbakGet);
            this.Controls.Add(this.btGetMessage);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbBodyMessage);
            this.Controls.Add(this.tbMessageID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvAddProperties);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbQueueName);
            this.Controls.Add(this.tbChannelName);
            this.Controls.Add(this.tbManagerName);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IbmMqTest";
            this.Size = new System.Drawing.Size(751, 512);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.TextBox tbManagerName;
        private System.Windows.Forms.TextBox tbChannelName;
        private System.Windows.Forms.TextBox tbQueueName;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvAddProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn APKeyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn APValueCol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMessageID;
        private System.Windows.Forms.TextBox tbBodyMessage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btGetMessage;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox chbRollbakGet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPutDate;
        private System.Windows.Forms.Button btSendFromFile;
    }
}
