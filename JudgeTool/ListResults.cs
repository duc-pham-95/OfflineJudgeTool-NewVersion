using DiffCalc;
using DifferenceEngine;
using JudgeTool.Models.Container;
using JudgeTool.Models.Processes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JudgeTool
{
    public partial class ListResults : Form
    {
        private DiffEngineLevel _level;
        private List<string> ErrorInputPaths;
        private List<Test> PassedTests;
        private List<Test> FailedTests;
        public ListResults(List<Test> passTests, List<Test> failedTests, List<string> errorInputPaths)
        {
            this.PassedTests = passTests;
            this.FailedTests = failedTests;
            this.ErrorInputPaths = errorInputPaths;
            InitializeComponent();
        }

        private void ListResults_Load(object sender, EventArgs e)
        {
            _level = DiffEngineLevel.Medium;
            Regex reg = new Regex(@"\d+.\w+");
            foreach(Test test in FailedTests) {
                Button buttonInput = new Button();
                buttonInput.Text = reg.Match(test.InputPath).Value;
                buttonInput.BackColor = Color.DarkRed;
                buttonInput.ForeColor = Color.White;
                buttonInput.Click += (s, args) => ClickInputButtonEvent(s, args, test.InputPath);
                flowLayoutPanel.Controls.Add(buttonInput);

                Button buttonDiff = new Button();
                buttonDiff.Text = "Diff.";
                buttonDiff.Click += (s, args) => ClickDiffButtonEvent(s, args, test.TargetOutputPath, test.CorrectOutputPath);
                flowLayoutPanel.Controls.Add(buttonDiff);
            }
            foreach(Test test in PassedTests)
            {
                Button buttonInput = new Button();
                buttonInput.Text = reg.Match(test.InputPath).Value;
                buttonInput.BackColor = Color.Green;
                buttonInput.ForeColor = Color.White;
                buttonInput.Click += (s, args) => ClickInputButtonEvent(s, args, test.InputPath);
                flowLayoutPanel.Controls.Add(buttonInput);

                Button buttonDiff = new Button();
                buttonDiff.Text = "Diff.";
                buttonDiff.Click += (s, args) => ClickDiffButtonEvent(s, args, test.TargetOutputPath, test.CorrectOutputPath);
                flowLayoutPanel.Controls.Add(buttonDiff);
            }
            foreach(string errorPath in ErrorInputPaths)
            {
                Button buttonErrorInput = new Button();
                buttonErrorInput.Text = reg.Match(errorPath).Value;
                buttonErrorInput.BackColor = Color.Gold;
                buttonErrorInput.ForeColor = Color.Black;
                buttonErrorInput.Click += (s, args) => ClickInputButtonEvent(s, args, errorPath);
                flowLayoutPanel.Controls.Add(buttonErrorInput);
            }
        }

        private void ClickInputButtonEvent(object sender, EventArgs e, string input)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(OpenFile));
            thread.Start(input);
        }

        private void ClickDiffButtonEvent(object sender, EventArgs e, string target, string correct)
        {
            if (rbFast.Checked)
            {
                _level = DiffEngineLevel.FastImperfect;
            }
            else if (rbMedium.Checked)
            {
                _level = DiffEngineLevel.Medium;
            }
            else
            {
                _level = DiffEngineLevel.SlowPerfect;
            }
            TextDiff(target, correct);
        }

        private bool ValidFile(string fname)
        {
            if (fname != string.Empty)
            {
                if (File.Exists(fname))
                {
                    return true;
                }
            }
            return false;
        }

        private void TextDiff(string sFile, string dFile)
        {
            this.Cursor = Cursors.WaitCursor;

            DiffList_TextFile sLF = null;
            DiffList_TextFile dLF = null;
            try
            {
                sLF = new DiffList_TextFile(sFile);
                dLF = new DiffList_TextFile(dFile);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "File Error");
                return;
            }

            try
            {
                double time = 0;
                DiffEngine de = new DiffEngine();
                time = de.ProcessDiff(sLF, dLF, _level);

                ArrayList rep = de.DiffReport();

                Results dlg = new Results(sLF, dLF, rep, time);
                dlg.ShowDialog();
                dlg.Dispose();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                string tmp = string.Format("{0}{1}{1}***STACK***{1}{2}",
                    ex.Message,
                    Environment.NewLine,
                    ex.StackTrace);
                MessageBox.Show(tmp, "Compare Error");
                return;
            }
            this.Cursor = Cursors.Default;
        }

        private void OpenFile(object input)
        {
            Explorer.OpenFile((string)input);
        }
    }
}
