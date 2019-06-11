using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffCalc;
using DifferenceEngine;
using JudgeTool.Models.Container;
using JudgeTool.Models.Message;
using JudgeTool.Models.Processes;
using JudgeTool.Models.Storage;

namespace JudgeTool
{
    public partial class MainForm : Form
    {
        private List<Test> PassedTests;
        private List<Test> FailedTests;
        private List<string> ErrorTests;
        private int FailedCount = 0;
        private int PassedCount = 0;
        private int ErrorCount = 0;
        private int TotalTestCount = 0;
        private int TestedCount = 0;
        private int NotTestedCount = 0;
        private bool isJava = true;

        public MainForm()
        {
            InitializeComponent();  
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PassedTests = new List<Test>();
            FailedTests = new List<Test>();
            ErrorTests = new List<string>();
            cbxLanguage.SelectedIndex = 0;
            SystemFolder.CreateAll();
            rbComparisonMode.Checked = true;
            rbNormalMode.Checked = false;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author : Phạm Hoài Đức\nEmail: duc.pham.set15@eiu.edu.vn\nFree application\nJava only.");
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            Explorer.OpenFolder(SystemFolder.GetOutDir());
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            ListResults listResults = new ListResults(PassedTests, FailedTests, ErrorTests);
            listResults.ShowDialog();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm setting = new SettingForm();
            setting.ShowDialog();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderChooser = new FolderBrowserDialog();
            if (FolderChooser.ShowDialog() == DialogResult.OK)
            {
                string path = FolderChooser.SelectedPath;
                if (!string.IsNullOrEmpty(path))
                {
                    if (!SystemFolder.isDirEmpty(path))
                    {
                        txtBrowser.Text = path;
                        SystemFolder.DataDir = txtBrowser.Text;
                        SystemFolder.ClearTestInDir();
                        SystemFolder.ClearTestOutDir();
                        SystemFile.GetData(txtBrowser.Text);
                        FolderChooser.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("the folder is empty ! no data found !");
                    }
                }
            }
        }
    
        private void btnRun_Click(object sender, EventArgs e)
        {
            ResetInfomation();
            SystemFolder.ClearAll();
            if (isReady())
            {
                DisableBtn();
                isJava = cbxLanguage.SelectedIndex == 0 ? true : false;
                WriteToFileCode(GetRawSourceCode());
                backgroundWorker.RunWorkerAsync();
            }
        }
      
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (isJava)
            {
                if (rbComparisonMode.Checked)
                    excuteUsingJavaWithJudging();
                else
                    excuteUsingJavaWithoutJudging();
            }
                
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (rbComparisonMode.Checked)
            {
                Invoke((MethodInvoker)delegate
                {
                    lbInfo.Items.Insert(0, "Completed !");
                    if (TestedCount > 0)
                    {
                        lbInfo.Items.Insert(0, "SỐ TEST GẶP LỖI: " + ErrorCount);
                        lbInfo.Items.Insert(0, "SỐ TEST SAI: " + FailedCount);
                        lbInfo.Items.Insert(0, "SỐ TEST ĐÚNG: " + PassedCount);
                        lbInfo.Items.Insert(0, "SỐ TEST CHƯA CHẠY: " + NotTestedCount);
                        lbInfo.Items.Insert(0, "SỐ TEST ĐÃ CHẠY : " + TestedCount);
                        lbInfo.Items.Insert(0, "TỔNG SỐ TEST : " + TotalTestCount);
                    }
                });
                if (TestedCount > 0)
                {
                    if (PassedCount == TotalTestCount)
                    {
                        MessageBox.Show("Passed all the test !");
                    }
                    DialogResult dialogResult = MessageBox.Show("Click to see the results in detail.");
                    if (dialogResult == DialogResult.OK)
                    {
                        ListResults listResults = new ListResults(PassedTests, FailedTests, ErrorTests);
                        listResults.ShowDialog();
                    }
                }
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    lbInfo.Items.Insert(0, "Completed !");
                    if (TestedCount > 0)
                    {
                        lbInfo.Items.Insert(0, "SỐ TEST GẶP LỖI: " + ErrorCount);
                        lbInfo.Items.Insert(0, "SỐ TEST CHƯA CHẠY: " + NotTestedCount);
                        lbInfo.Items.Insert(0, "SỐ TEST ĐÃ CHẠY : " + TestedCount);
                        lbInfo.Items.Insert(0, "TỔNG SỐ TEST : " + TotalTestCount);
                    }
                });
                if (TestedCount > 0)
                {
                    MessageBox.Show("Click to see your outputs !");
                    Explorer.OpenFolder(SystemFolder.GetOutDir());
                }
            }
            EnableBtn();
        }

        private void excuteUsingJavaWithJudging()
        {
            Invoke((MethodInvoker)delegate
            {
                lbInfo.Items.Insert(0,"Compiling the code...");
            });
            string error = Java.Compile(SystemFile.GetJavaFilePath());
            if (!string.IsNullOrEmpty(error))
            {
                Invoke((MethodInvoker)delegate
                {
                    lbInfo.Items.Insert(0,Messages.GetErrorType(error));
                    rtbReport.Text = error;
                });
            }   
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    lbInfo.Items.Insert(0, "Compiled Successfully !.");
                });
                string[] inputFilePaths = SystemFile.GetInputFilePaths(SystemFolder.GetTestInDir());
                string[] outputFilePaths = SystemFile.GetOutputFilePaths(SystemFolder.GetTestInDir());
                DirectoryInfo correctOutputDir = new DirectoryInfo(SystemFolder.GetTestOutDir());
                FileInfo[] correctOutputFiles = correctOutputDir.GetFiles();
                int i = 1;
                foreach (string inputFilePath in inputFilePaths)
                {
                    string fileInputContent = SystemFile.GetFileContentText(inputFilePath);
                    Invoke((MethodInvoker)delegate
                    {
                        lbInfo.Items.Insert(0, "Running test " + i + "...");
                    });
                    Result result = Java.Run(fileInputContent);
                    if (result.error.Length > 0)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            lbInfo.Items.Insert(0, Messages.GetErrorType(result.error.ToString()) + " at test " + i );
                            rtbReport.Text = result.error.ToString();
                        });
                        ErrorTests.Add(inputFilePath);
                        ErrorCount++;
                        i++;
                        continue;
                    }                                    
                    File.WriteAllText(outputFilePaths[i - 1], result.output.ToString().TrimEnd('\n').TrimEnd('\r'));
                    if(CompareFile(outputFilePaths[i - 1], correctOutputFiles[i - 1].FullName))
                    {
                        PassedCount++;
                        PassedTests.Add(new Test(inputFilePath, correctOutputFiles[i - 1].FullName, outputFilePaths[i - 1]));
                    }
                    else
                    {
                        FailedCount++;
                        FailedTests.Add(new Test(inputFilePath, correctOutputFiles[i - 1].FullName, outputFilePaths[i - 1]));
                    }
                    i++;
                }
                TotalTestCount = inputFilePaths.Length;
                TestedCount = PassedCount + FailedCount + ErrorCount;
                NotTestedCount = TotalTestCount - TestedCount;
            }
        }

        private void excuteUsingJavaWithoutJudging()
        {
            Invoke((MethodInvoker)delegate
            {
                lbInfo.Items.Insert(0, "Compiling the code...");
            });
            string error = Java.Compile(SystemFile.GetJavaFilePath());
            if (!string.IsNullOrEmpty(error))
            {
                Invoke((MethodInvoker)delegate
                {
                    lbInfo.Items.Insert(0,Messages.GetErrorType(error));
                    rtbReport.Text = error;
                });
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    lbInfo.Items.Insert(0, "Compiled Successfully !.");
                });
                string[] inputFilePaths = SystemFile.GetInputFilePaths(SystemFolder.GetTestInDir());
                string[] outputFilePaths = SystemFile.GetOutputFilePaths(SystemFolder.GetTestInDir());
                int i = 1;
                foreach (string inputFilePath in inputFilePaths)
                {
                    string fileInputContent = SystemFile.GetFileContentText(inputFilePath);
                    Invoke((MethodInvoker)delegate
                    {
                        lbInfo.Items.Insert(0, "Running test " + i + "...");
                    });
                    Result result = Java.Run(fileInputContent);
                    if (result.error.Length > 0)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            lbInfo.Items.Insert(0, Messages.GetErrorType(result.error.ToString()) + " at test " + i);
                            rtbReport.Text = result.error.ToString();
                        });
                        ErrorTests.Add(inputFilePath);
                        ErrorCount++;
                        i++;
                        continue;
                    }
                    File.WriteAllText(outputFilePaths[i - 1], result.output.ToString().TrimEnd('\n').TrimEnd('\r'));
                    i++;
                    TestedCount++;
                }
                TotalTestCount = inputFilePaths.Length;
                TestedCount += ErrorCount;
                NotTestedCount = TotalTestCount - TestedCount;
            }
        }

        private void ResetInfomation()
        {
            ErrorTests.Clear();
            PassedTests.Clear();
            FailedTests.Clear();
            lbInfo.Items.Clear();
            rtbReport.Text = "";
            TotalTestCount = 0;
            PassedCount = 0;
            FailedCount = 0;
            TestedCount = 0;
            NotTestedCount = 0;
            ErrorCount = 0;
        }

        private void DisableBtn()
        {
            btnBrowser.Enabled = false;
            btnSetting.Enabled = false;
            btnRun.Enabled = false;
            btnOutput.Enabled = false;
            btnResults.Enabled = false;
            btnInfo.Enabled = false;
        }

        private void EnableBtn()
        {
            btnBrowser.Enabled = true;
            btnSetting.Enabled = true;
            btnRun.Enabled = true;
            btnOutput.Enabled = true;
            btnResults.Enabled = true;
            btnInfo.Enabled = true;
        }

        private bool isReady()
        {
            if (rbComparisonMode.Checked)
            {
                return isSourceCodeExisted() && isLanguageSelected() && isTestDataPathExisted() && isDataValid() && isDataInComparisonModeValid();
            }
            else
            {
                return isSourceCodeExisted() && isLanguageSelected() && isTestDataPathExisted() && isDataValid();
            }
            
        }

        private Boolean isSourceCodeExisted()
        {
            if (rtbSourceCode.Lines.Length == 0)
            {
                MessageBox.Show("Source code is empty, please insert !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbSourceCode.Focus();
                return false;
            }
            return true;
        }

        private Boolean isLanguageSelected()
        {
            if (cbxLanguage.SelectedItem == null)
            {
                MessageBox.Show("please select language !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxLanguage.Focus();
                return false;
            }
            return true;
        }

        private Boolean isTestDataPathExisted()
        {
            if (SystemFolder.DataDir == null)
            {
                MessageBox.Show("Testdata directory must be given before running code !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnBrowser.Focus();
                return false;
            }
            return true;
        }

        private Boolean isDataValid()
        {
            if(NumberOfInputFiles() > 0)
            {
                return true;
            }
            MessageBox.Show("no input files found !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private Boolean isDataInComparisonModeValid()
        {
            if(NumberOfInputFiles() == NumberOfOutputFiles())
            {
                return true;
            }
            MessageBox.Show("numbers of input files and output files need to be equal in comparison mode !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private bool CompareFile(string filePath1, string filePath2)
        {
            return File.ReadAllLines(filePath1).SequenceEqual(
                File.ReadAllLines(filePath2));
        }

        private void WriteToFileCode(string[] text)
        {
            if (isJava)
                SystemFile.WriteTextToFile(SystemFile.GetJavaFilePath(), text);
            else
                SystemFile.WriteTextToFile(SystemFile.GetCSharpFilePath(), text);
        }

        private string[] GetRawSourceCode()
        {
            int n = rtbSourceCode.Lines.Length;
            string[] text = new string[n];
            for (int i = 0; i < n; i++)
            {
                text[i] = rtbSourceCode.Lines[i];
            }
            return text;
        }

        private int NumberOfInputFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(SystemFolder.GetTestInDir());
            return directoryInfo.GetFiles().Length;
        }

        private int NumberOfOutputFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(SystemFolder.GetTestOutDir());
            return directoryInfo.GetFiles().Length;
        }

        
    }
}
