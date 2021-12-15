namespace Arcas.Controls
{
    partial class XsltTransform
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbTransform = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSourseXML = new System.Windows.Forms.TextBox();
            this.btSourseXMLClear = new System.Windows.Forms.Button();
            this.btSourseXMLFormat = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbResTransform = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbXsltText = new System.Windows.Forms.TextBox();
            this.btXsltTextClear = new System.Windows.Forms.Button();
            this.btXsltTextFormat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(1159, 662);
            this.splitContainer1.SplitterDistance = 609;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.DoubleClick += new System.EventHandler(this.splitContainer1_DoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(609, 662);
            this.splitContainer2.SplitterDistance = 331;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.DoubleClick += new System.EventHandler(this.splitContainer2_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbTransform);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btSourseXMLClear);
            this.panel1.Controls.Add(this.btSourseXMLFormat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 331);
            this.panel1.TabIndex = 0;
            // 
            // tbTransform
            // 
            this.tbTransform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTransform.Location = new System.Drawing.Point(496, 3);
            this.tbTransform.Name = "tbTransform";
            this.tbTransform.Size = new System.Drawing.Size(104, 23);
            this.tbTransform.TabIndex = 3;
            this.tbTransform.Text = "Преобразовать";
            this.tbTransform.UseVisualStyleBackColor = true;
            this.tbTransform.Click += new System.EventHandler(this.tbTransform_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbSourseXML);
            this.groupBox1.Location = new System.Drawing.Point(3, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 301);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходный XML";
            // 
            // tbSourseXML
            // 
            this.tbSourseXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSourseXML.Location = new System.Drawing.Point(3, 16);
            this.tbSourseXML.Multiline = true;
            this.tbSourseXML.Name = "tbSourseXML";
            this.tbSourseXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSourseXML.Size = new System.Drawing.Size(597, 282);
            this.tbSourseXML.TabIndex = 0;
            // 
            // btSourseXMLClear
            // 
            this.btSourseXMLClear.Location = new System.Drawing.Point(113, 3);
            this.btSourseXMLClear.Name = "btSourseXMLClear";
            this.btSourseXMLClear.Size = new System.Drawing.Size(104, 23);
            this.btSourseXMLClear.TabIndex = 1;
            this.btSourseXMLClear.Text = "Очистить";
            this.btSourseXMLClear.UseVisualStyleBackColor = true;
            this.btSourseXMLClear.Click += new System.EventHandler(this.btSourseXMLClear_Click);
            // 
            // btSourseXMLFormat
            // 
            this.btSourseXMLFormat.Location = new System.Drawing.Point(3, 3);
            this.btSourseXMLFormat.Name = "btSourseXMLFormat";
            this.btSourseXMLFormat.Size = new System.Drawing.Size(104, 23);
            this.btSourseXMLFormat.TabIndex = 0;
            this.btSourseXMLFormat.Text = "Форматировать XML";
            this.btSourseXMLFormat.UseVisualStyleBackColor = true;
            this.btSourseXMLFormat.Click += new System.EventHandler(this.btSourseXMLFormat_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbResTransform);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(609, 327);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Результат Xslt преобразования";
            // 
            // tbResTransform
            // 
            this.tbResTransform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbResTransform.Location = new System.Drawing.Point(3, 16);
            this.tbResTransform.Multiline = true;
            this.tbResTransform.Name = "tbResTransform";
            this.tbResTransform.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbResTransform.Size = new System.Drawing.Size(603, 308);
            this.tbResTransform.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel2);
            this.splitContainer3.Size = new System.Drawing.Size(546, 662);
            this.splitContainer3.SplitterDistance = 319;
            this.splitContainer3.TabIndex = 1;
            this.splitContainer3.DoubleClick += new System.EventHandler(this.splitContainer3_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.btXsltTextClear);
            this.panel2.Controls.Add(this.btXsltTextFormat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 319);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbXsltText);
            this.groupBox2.Location = new System.Drawing.Point(3, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 289);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Xslt преобразования";
            // 
            // tbXsltText
            // 
            this.tbXsltText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbXsltText.Location = new System.Drawing.Point(3, 16);
            this.tbXsltText.Multiline = true;
            this.tbXsltText.Name = "tbXsltText";
            this.tbXsltText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbXsltText.Size = new System.Drawing.Size(534, 270);
            this.tbXsltText.TabIndex = 0;
            // 
            // btXsltTextClear
            // 
            this.btXsltTextClear.Location = new System.Drawing.Point(113, 3);
            this.btXsltTextClear.Name = "btXsltTextClear";
            this.btXsltTextClear.Size = new System.Drawing.Size(104, 23);
            this.btXsltTextClear.TabIndex = 1;
            this.btXsltTextClear.Text = "Очистить";
            this.btXsltTextClear.UseVisualStyleBackColor = true;
            this.btXsltTextClear.Click += new System.EventHandler(this.btXsltTextClear_Click);
            // 
            // btXsltTextFormat
            // 
            this.btXsltTextFormat.Location = new System.Drawing.Point(3, 3);
            this.btXsltTextFormat.Name = "btXsltTextFormat";
            this.btXsltTextFormat.Size = new System.Drawing.Size(104, 23);
            this.btXsltTextFormat.TabIndex = 0;
            this.btXsltTextFormat.Text = "Форматировать XML";
            this.btXsltTextFormat.UseVisualStyleBackColor = true;
            this.btXsltTextFormat.Click += new System.EventHandler(this.btXsltTextFormat_Click);
            // 
            // XsltTransform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "XsltTransform";
            this.Size = new System.Drawing.Size(1159, 662);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSourseXML;
        private System.Windows.Forms.Button btSourseXMLClear;
        private System.Windows.Forms.Button btSourseXMLFormat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbXsltText;
        private System.Windows.Forms.Button btXsltTextClear;
        private System.Windows.Forms.Button btXsltTextFormat;
        private System.Windows.Forms.Button tbTransform;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbResTransform;

    }
}
