namespace JudgeTool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbSourceCode = new System.Windows.Forms.RichTextBox();
            this.cbxLanguage = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtBrowser = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rtbReport = new System.Windows.Forms.RichTextBox();
            this.rbNormalMode = new System.Windows.Forms.RadioButton();
            this.rbComparisonMode = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rtbSourceCode);
            this.groupBox1.Controls.Add(this.cbxLanguage);
            this.groupBox1.Location = new System.Drawing.Point(24, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 328);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Language";
            // 
            // rtbSourceCode
            // 
            this.rtbSourceCode.Location = new System.Drawing.Point(7, 51);
            this.rtbSourceCode.Name = "rtbSourceCode";
            this.rtbSourceCode.Size = new System.Drawing.Size(487, 271);
            this.rtbSourceCode.TabIndex = 0;
            this.rtbSourceCode.Text = "";
            // 
            // cbxLanguage
            // 
            this.cbxLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLanguage.FormattingEnabled = true;
            this.cbxLanguage.Items.AddRange(new object[] {
            "Java"});
            this.cbxLanguage.Location = new System.Drawing.Point(383, 17);
            this.cbxLanguage.Name = "cbxLanguage";
            this.cbxLanguage.Size = new System.Drawing.Size(110, 24);
            this.cbxLanguage.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbInfo);
            this.groupBox2.Location = new System.Drawing.Point(545, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 239);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Running Information";
            // 
            // lbInfo
            // 
            this.lbInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.ItemHeight = 16;
            this.lbInfo.Location = new System.Drawing.Point(6, 21);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(486, 212);
            this.lbInfo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBrowser);
            this.groupBox3.Controls.Add(this.txtBrowser);
            this.groupBox3.Location = new System.Drawing.Point(24, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 58);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowser.Location = new System.Drawing.Point(383, 21);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(92, 23);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtBrowser
            // 
            this.txtBrowser.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBrowser.Location = new System.Drawing.Point(7, 22);
            this.txtBrowser.Name = "txtBrowser";
            this.txtBrowser.ReadOnly = true;
            this.txtBrowser.Size = new System.Drawing.Size(361, 22);
            this.txtBrowser.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnInfo);
            this.groupBox4.Controls.Add(this.btnOutput);
            this.groupBox4.Controls.Add(this.btnResults);
            this.groupBox4.Controls.Add(this.btnSetting);
            this.groupBox4.Controls.Add(this.btnRun);
            this.groupBox4.Location = new System.Drawing.Point(24, 429);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(499, 63);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Controls";
            // 
            // btnInfo
            // 
            this.btnInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfo.Location = new System.Drawing.Point(409, 21);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 36);
            this.btnInfo.TabIndex = 4;
            this.btnInfo.Text = "About";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOutput.Location = new System.Drawing.Point(212, 21);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 36);
            this.btnOutput.TabIndex = 3;
            this.btnOutput.Text = "Outputs";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnResults
            // 
            this.btnResults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResults.Location = new System.Drawing.Point(310, 22);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(75, 35);
            this.btnResults.TabIndex = 2;
            this.btnResults.Text = "Results";
            this.btnResults.UseVisualStyleBackColor = true;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.Location = new System.Drawing.Point(112, 21);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 36);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnRun
            // 
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.Location = new System.Drawing.Point(19, 21);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 35);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rtbReport);
            this.groupBox5.Location = new System.Drawing.Point(545, 258);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(499, 234);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Report";
            // 
            // rtbReport
            // 
            this.rtbReport.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rtbReport.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtbReport.ForeColor = System.Drawing.Color.DarkRed;
            this.rtbReport.Location = new System.Drawing.Point(7, 21);
            this.rtbReport.Name = "rtbReport";
            this.rtbReport.ReadOnly = true;
            this.rtbReport.Size = new System.Drawing.Size(486, 207);
            this.rtbReport.TabIndex = 0;
            this.rtbReport.Text = "";
            // 
            // rbNormalMode
            // 
            this.rbNormalMode.AutoSize = true;
            this.rbNormalMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbNormalMode.Location = new System.Drawing.Point(236, 77);
            this.rbNormalMode.Name = "rbNormalMode";
            this.rbNormalMode.Size = new System.Drawing.Size(113, 21);
            this.rbNormalMode.TabIndex = 5;
            this.rbNormalMode.TabStop = true;
            this.rbNormalMode.Text = "Normal mode";
            this.rbNormalMode.UseVisualStyleBackColor = true;
            // 
            // rbComparisonMode
            // 
            this.rbComparisonMode.AutoSize = true;
            this.rbComparisonMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbComparisonMode.Location = new System.Drawing.Point(380, 77);
            this.rbComparisonMode.Name = "rbComparisonMode";
            this.rbComparisonMode.Size = new System.Drawing.Size(143, 21);
            this.rbComparisonMode.TabIndex = 6;
            this.rbComparisonMode.TabStop = true;
            this.rbComparisonMode.Text = "Comparison mode";
            this.rbComparisonMode.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1066, 519);
            this.Controls.Add(this.rbComparisonMode);
            this.Controls.Add(this.rbNormalMode);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Offline Judge Tool New Version ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbSourceCode;
        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxLanguage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtBrowser;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnRun;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox rtbReport;
        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.RadioButton rbNormalMode;
        private System.Windows.Forms.RadioButton rbComparisonMode;
        private System.Windows.Forms.Button btnInfo;
    }
}

