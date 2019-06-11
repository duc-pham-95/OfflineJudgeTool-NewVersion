using JudgeTool.Models.Processes;
using JudgeTool.Models.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JudgeTool
{
    public partial class SettingForm : Form
    {
        string path;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (path != null)
            {
                SystemFolder.CustomOutDir = path;
            }
            if (numericUpDownTimeLimit.Value > 0)
            {
                Java.Timeout = Convert.ToInt32(numericUpDownTimeLimit.Value);
            }
            SystemFile.customFileExtension = cbOutputType.SelectedItem.ToString();
            Dispose();
        }

        private void btnOutputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderChooser = new FolderBrowserDialog();
            if (FolderChooser.ShowDialog() == DialogResult.OK)
            {
                path = FolderChooser.SelectedPath;
                if (path.Length > 0)
                {
                    txtOutput.Text = path;
                    FolderChooser.Dispose();
                }
            }
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            numericUpDownTimeLimit.Value = Java.Timeout;
            txtOutput.Text = SystemFolder.GetOutDir();
            cbOutputType.Items.Add(SystemFile.textFileExtension);
            cbOutputType.Items.Add(SystemFile.outputFileExtension);
            cbOutputType.Items.Add(SystemFile.answerFileExtension);
            if (SystemFile.customFileExtension.Equals(SystemFile.textFileExtension))
                cbOutputType.SelectedIndex = 0;
            else if (SystemFile.customFileExtension.Equals(SystemFile.outputFileExtension))
                cbOutputType.SelectedIndex = 1;
            else if (SystemFile.customFileExtension.Equals(SystemFile.answerFileExtension))
                cbOutputType.SelectedIndex = 2;
            cbOutputType.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
