using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using JudgeTool.Models.Storage;
using System.IO;
using System.Threading;
using JudgeTool.Models.Container;

namespace JudgeTool.Models.Processes
{
    public static class Java
    {
        private static readonly string Carries = @"/C ";
        private static readonly string CompileCommand = "javac ";
        public static string StartupPath { get; set; }
        public static int Timeout = 5000;

        public static string Compile(string javafilePath)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = Carries + CompileCommand + '"' + javafilePath + '"';
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo = startInfo;
            process.Start();
            return process.StandardError.ReadToEnd();
        }

        public static Result Run(string input)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "java.exe";
            startInfo.Arguments = @"-cp "+'"'+SystemFolder.GetMainDir()+'"'+" "+"Main";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            process.StartInfo = startInfo;
            
            StringBuilder output = new StringBuilder();
            StringBuilder error = new StringBuilder();
            
            using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
            using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
            {
                process.OutputDataReceived += (sender, e) => {
                    if (string.IsNullOrEmpty(e.Data))
                    {
                        try
                        {
                            outputWaitHandle.Set();
                        }
                        catch(ObjectDisposedException ode)
                        {

                        }
                        
                    }
                    else
                    {
                        output.AppendLine(e.Data);
                    }
                };
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (string.IsNullOrEmpty(e.Data))
                    {
                        try {
                            errorWaitHandle.Set();
                        }
                        catch(ObjectDisposedException ode)
                        {

                        }
                    }
                    else
                    {
                        error.AppendLine(e.Data);
                    }
                };

                process.Start();

                StreamWriter streamWriter = process.StandardInput;
                streamWriter.WriteLine(input);
                streamWriter.Close();
                
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                if (process.WaitForExit(Timeout) && outputWaitHandle.WaitOne(Timeout) && errorWaitHandle.WaitOne(Timeout))
                {
                    process.Close();
                }
                else
                {
                    if (!process.HasExited)
                    {
                        process.Kill();
                        foreach (var child in Process.GetProcessesByName("java"))
                        {
                            if (!child.HasExited)
                            {
                                child.Kill();
                            }
                        }
                    }
                    error.AppendLine("Time limit exceeded !.");
                }
            }
            return new Result(output, error);
        }
    }
}
