namespace JudgeTool
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.grbSetting = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTip = new System.Windows.Forms.Label();
            this.lbOutputWarning = new System.Windows.Forms.Label();
            this.btnOutputDir = new System.Windows.Forms.Button();
            this.cbOutputType = new System.Windows.Forms.ComboBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.numericUpDownTimeLimit = new System.Windows.Forms.NumericUpDown();
            this.lbOutputType = new System.Windows.Forms.Label();
            this.lbOutput = new System.Windows.Forms.Label();
            this.lbTimeLimit = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.grbSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // grbSetting
            // 
            this.grbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSetting.Controls.Add(this.label1);
            this.grbSetting.Controls.Add(this.lbTip);
            this.grbSetting.Controls.Add(this.lbOutputWarning);
            this.grbSetting.Controls.Add(this.btnOutputDir);
            this.grbSetting.Controls.Add(this.cbOutputType);
            this.grbSetting.Controls.Add(this.txtOutput);
            this.grbSetting.Controls.Add(this.numericUpDownTimeLimit);
            this.grbSetting.Controls.Add(this.lbOutputType);
            this.grbSetting.Controls.Add(this.lbOutput);
            this.grbSetting.Controls.Add(this.lbTimeLimit);
            this.grbSetting.Location = new System.Drawing.Point(12, 12);
            this.grbSetting.Name = "grbSetting";
            this.grbSetting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grbSetting.Size = new System.Drawing.Size(390, 368);
            this.grbSetting.TabIndex = 1;
            this.grbSetting.TabStop = false;
            this.grbSetting.Text = "Setting Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "(Milliseconds)";
            // 
            // lbTip
            // 
            this.lbTip.AutoSize = true;
            this.lbTip.Location = new System.Drawing.Point(23, 87);
            this.lbTip.Name = "lbTip";
            this.lbTip.Size = new System.Drawing.Size(316, 17);
            this.lbTip.TabIndex = 8;
            this.lbTip.Text = "(1000ms equal to 1s, allows maximum 1 million s)";
            // 
            // lbOutputWarning
            // 
            this.lbOutputWarning.AutoSize = true;
            this.lbOutputWarning.Location = new System.Drawing.Point(23, 205);
            this.lbOutputWarning.Name = "lbOutputWarning";
            this.lbOutputWarning.Size = new System.Drawing.Size(246, 17);
            this.lbOutputWarning.TabIndex = 7;
            this.lbOutputWarning.Text = "(you should choose an empty folder !)";
            // 
            // btnOutputDir
            // 
            this.btnOutputDir.Location = new System.Drawing.Point(286, 234);
            this.btnOutputDir.Name = "btnOutputDir";
            this.btnOutputDir.Size = new System.Drawing.Size(75, 22);
            this.btnOutputDir.TabIndex = 6;
            this.btnOutputDir.Text = "...";
            this.btnOutputDir.UseVisualStyleBackColor = true;
            this.btnOutputDir.Click += new System.EventHandler(this.btnOutputDir_Click);
            // 
            // cbOutputType
            // 
            this.cbOutputType.FormattingEnabled = true;
            this.cbOutputType.Location = new System.Drawing.Point(26, 312);
            this.cbOutputType.Name = "cbOutputType";
            this.cbOutputType.Size = new System.Drawing.Size(136, 24);
            this.cbOutputType.TabIndex = 5;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(26, 234);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(254, 22);
            this.txtOutput.TabIndex = 4;
            // 
            // numericUpDownTimeLimit
            // 
            this.numericUpDownTimeLimit.Location = new System.Drawing.Point(26, 124);
            this.numericUpDownTimeLimit.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownTimeLimit.Name = "numericUpDownTimeLimit";
            this.numericUpDownTimeLimit.Size = new System.Drawing.Size(136, 22);
            this.numericUpDownTimeLimit.TabIndex = 3;
            // 
            // lbOutputType
            // 
            this.lbOutputType.AutoSize = true;
            this.lbOutputType.Location = new System.Drawing.Point(23, 282);
            this.lbOutputType.Name = "lbOutputType";
            this.lbOutputType.Size = new System.Drawing.Size(86, 17);
            this.lbOutputType.TabIndex = 2;
            this.lbOutputType.Text = "Output type:";
            // 
            // lbOutput
            // 
            this.lbOutput.AutoSize = true;
            this.lbOutput.Location = new System.Drawing.Point(23, 179);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(247, 17);
            this.lbOutput.TabIndex = 1;
            this.lbOutput.Text = "Where to get your outputs after finish:";
            // 
            // lbTimeLimit
            // 
            this.lbTimeLimit.AutoSize = true;
            this.lbTimeLimit.Location = new System.Drawing.Point(23, 56);
            this.lbTimeLimit.Name = "lbTimeLimit";
            this.lbTimeLimit.Size = new System.Drawing.Size(202, 17);
            this.lbTimeLimit.TabIndex = 0;
            this.lbTimeLimit.Text = "Time limit for a single testcase:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(298, 396);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(411, 442);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grbSetting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.grbSetting.ResumeLayout(false);
            this.grbSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTip;
        private System.Windows.Forms.Label lbOutputWarning;
        private System.Windows.Forms.Button btnOutputDir;
        private System.Windows.Forms.ComboBox cbOutputType;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeLimit;
        private System.Windows.Forms.Label lbOutputType;
        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.Label lbTimeLimit;
        private System.Windows.Forms.Button btnOK;
    }
}