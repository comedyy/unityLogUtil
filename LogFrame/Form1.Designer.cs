namespace LogFrame
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            isStop = true;
            StopSocketThread();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonListen = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.checkBoxCommon = new System.Windows.Forms.CheckBox();
            this.checkBoxWarning = new System.Windows.Forms.CheckBox();
            this.checkBoxError = new System.Windows.Forms.CheckBox();
            this.checkBoxException = new System.Windows.Forms.CheckBox();
            this.labelCommonCount = new System.Windows.Forms.Label();
            this.labelWarningCount = new System.Windows.Forms.Label();
            this.labelErrorCount = new System.Windows.Forms.Label();
            this.labelExceptionCount = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.buttonCategory = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxUp = new System.Windows.Forms.CheckBox();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.checkBoxWhole = new System.Windows.Forms.CheckBox();
            this.buttonWriteFile = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.81481F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.18519F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(743, 513);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 78);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(737, 432);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.759538F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.945648F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.03902F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.386736F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.11619F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.11619F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.251463F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.25645F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.109429F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.109429F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.90991F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxPort, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonListen, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonPause, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxCommon, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxWarning, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxError, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxException, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelCommonCount, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelWarningCount, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelErrorCount, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelExceptionCount, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.richTextBox2, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonCategory, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonClear, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.button1, 8, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxUp, 9, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxFind, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxWhole, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonWriteFile, 10, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxFilePath, 10, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(728, 69);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPort.Location = new System.Drawing.Point(44, 6);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(66, 21);
            this.textBoxPort.TabIndex = 2;
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(116, 3);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(74, 23);
            this.buttonListen.TabIndex = 4;
            this.buttonListen.Text = "重新监听";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(116, 37);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(74, 23);
            this.buttonPause.TabIndex = 5;
            this.buttonPause.Text = "暂停接收";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // checkBoxCommon
            // 
            this.checkBoxCommon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxCommon.AutoSize = true;
            this.checkBoxCommon.Location = new System.Drawing.Point(203, 9);
            this.checkBoxCommon.Name = "checkBoxCommon";
            this.checkBoxCommon.Size = new System.Drawing.Size(55, 16);
            this.checkBoxCommon.TabIndex = 7;
            this.checkBoxCommon.Text = "普通";
            this.checkBoxCommon.UseVisualStyleBackColor = true;
            this.checkBoxCommon.CheckedChanged += new System.EventHandler(this.checkBoxCommon_CheckedChanged);
            // 
            // checkBoxWarning
            // 
            this.checkBoxWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxWarning.AutoSize = true;
            this.checkBoxWarning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxWarning.Location = new System.Drawing.Point(264, 9);
            this.checkBoxWarning.Name = "checkBoxWarning";
            this.checkBoxWarning.Size = new System.Drawing.Size(53, 16);
            this.checkBoxWarning.TabIndex = 9;
            this.checkBoxWarning.Text = "警告";
            this.checkBoxWarning.UseVisualStyleBackColor = true;
            this.checkBoxWarning.CheckedChanged += new System.EventHandler(this.checkBoxWarning_CheckedChanged);
            // 
            // checkBoxError
            // 
            this.checkBoxError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxError.AutoSize = true;
            this.checkBoxError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxError.Location = new System.Drawing.Point(323, 9);
            this.checkBoxError.Name = "checkBoxError";
            this.checkBoxError.Size = new System.Drawing.Size(53, 16);
            this.checkBoxError.TabIndex = 8;
            this.checkBoxError.Text = "错误";
            this.checkBoxError.UseVisualStyleBackColor = true;
            this.checkBoxError.CheckedChanged += new System.EventHandler(this.checkBoxError_CheckedChanged);
            // 
            // checkBoxException
            // 
            this.checkBoxException.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxException.AutoSize = true;
            this.checkBoxException.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxException.Location = new System.Drawing.Point(382, 9);
            this.checkBoxException.Name = "checkBoxException";
            this.checkBoxException.Size = new System.Drawing.Size(54, 16);
            this.checkBoxException.TabIndex = 10;
            this.checkBoxException.Text = "异常";
            this.checkBoxException.UseVisualStyleBackColor = true;
            this.checkBoxException.CheckedChanged += new System.EventHandler(this.checkBoxException_CheckedChanged);
            // 
            // labelCommonCount
            // 
            this.labelCommonCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCommonCount.AutoSize = true;
            this.labelCommonCount.Location = new System.Drawing.Point(203, 45);
            this.labelCommonCount.Name = "labelCommonCount";
            this.labelCommonCount.Size = new System.Drawing.Size(55, 12);
            this.labelCommonCount.TabIndex = 11;
            this.labelCommonCount.Text = "0";
            // 
            // labelWarningCount
            // 
            this.labelWarningCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWarningCount.AutoSize = true;
            this.labelWarningCount.Location = new System.Drawing.Point(264, 45);
            this.labelWarningCount.Name = "labelWarningCount";
            this.labelWarningCount.Size = new System.Drawing.Size(53, 12);
            this.labelWarningCount.TabIndex = 12;
            this.labelWarningCount.Text = "0";
            // 
            // labelErrorCount
            // 
            this.labelErrorCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelErrorCount.AutoSize = true;
            this.labelErrorCount.Location = new System.Drawing.Point(323, 45);
            this.labelErrorCount.Name = "labelErrorCount";
            this.labelErrorCount.Size = new System.Drawing.Size(53, 12);
            this.labelErrorCount.TabIndex = 13;
            this.labelErrorCount.Text = "0";
            // 
            // labelExceptionCount
            // 
            this.labelExceptionCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelExceptionCount.AutoSize = true;
            this.labelExceptionCount.Location = new System.Drawing.Point(382, 45);
            this.labelExceptionCount.Name = "labelExceptionCount";
            this.labelExceptionCount.Size = new System.Drawing.Size(54, 12);
            this.labelExceptionCount.TabIndex = 14;
            this.labelExceptionCount.Text = "0";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(442, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(90, 28);
            this.richTextBox2.TabIndex = 15;
            this.richTextBox2.Text = "";
            // 
            // buttonCategory
            // 
            this.buttonCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCategory.Location = new System.Drawing.Point(442, 40);
            this.buttonCategory.Name = "buttonCategory";
            this.buttonCategory.Size = new System.Drawing.Size(90, 23);
            this.buttonCategory.TabIndex = 16;
            this.buttonCategory.Text = "筛选类型";
            this.buttonCategory.UseVisualStyleBackColor = true;
            this.buttonCategory.Click += new System.EventHandler(this.buttonCategory_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(44, 40);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(66, 23);
            this.buttonClear.TabIndex = 17;
            this.buttonClear.Text = "清空日志";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(538, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "查找";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxUp
            // 
            this.checkBoxUp.AutoSize = true;
            this.checkBoxUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxUp.Location = new System.Drawing.Point(597, 37);
            this.checkBoxUp.Name = "checkBoxUp";
            this.checkBoxUp.Size = new System.Drawing.Size(53, 29);
            this.checkBoxUp.TabIndex = 19;
            this.checkBoxUp.Text = "向上";
            this.checkBoxUp.UseVisualStyleBackColor = true;
            // 
            // textBoxFind
            // 
            this.textBoxFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFind.Location = new System.Drawing.Point(538, 6);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(53, 21);
            this.textBoxFind.TabIndex = 20;
            // 
            // checkBoxWhole
            // 
            this.checkBoxWhole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxWhole.AutoSize = true;
            this.checkBoxWhole.Location = new System.Drawing.Point(597, 9);
            this.checkBoxWhole.Name = "checkBoxWhole";
            this.checkBoxWhole.Size = new System.Drawing.Size(53, 16);
            this.checkBoxWhole.TabIndex = 21;
            this.checkBoxWhole.Text = "整词";
            this.checkBoxWhole.UseVisualStyleBackColor = true;
            // 
            // buttonWriteFile
            // 
            this.buttonWriteFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWriteFile.Location = new System.Drawing.Point(656, 40);
            this.buttonWriteFile.Name = "buttonWriteFile";
            this.buttonWriteFile.Size = new System.Drawing.Size(69, 23);
            this.buttonWriteFile.TabIndex = 22;
            this.buttonWriteFile.Text = "写文件";
            this.buttonWriteFile.UseVisualStyleBackColor = true;
            this.buttonWriteFile.Click += new System.EventHandler(this.buttonWriteFile_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilePath.Location = new System.Drawing.Point(656, 6);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(69, 21);
            this.textBoxFilePath.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 513);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.CheckBox checkBoxCommon;
        private System.Windows.Forms.CheckBox checkBoxError;
        private System.Windows.Forms.CheckBox checkBoxWarning;
        private System.Windows.Forms.CheckBox checkBoxException;
        private System.Windows.Forms.Label labelCommonCount;
        private System.Windows.Forms.Label labelWarningCount;
        private System.Windows.Forms.Label labelErrorCount;
        private System.Windows.Forms.Label labelExceptionCount;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button buttonCategory;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxUp;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.CheckBox checkBoxWhole;
        private System.Windows.Forms.Button buttonWriteFile;
        private System.Windows.Forms.TextBox textBoxFilePath;



    }
}

