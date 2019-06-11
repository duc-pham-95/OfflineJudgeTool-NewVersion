using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeTool.Models.Processes
{
    class Explorer
    {
        public static void OpenFolder(string path)
        {
            Process process = new Process();
            ProcessStartInfo StartInfo = new ProcessStartInfo();
            StartInfo.FileName = "explorer.exe";
            StartInfo.Arguments = path;
            process.StartInfo = StartInfo;
            process.Start();//chay process
        }
        public static void OpenFile(string path)
        {
            Process process = new Process();
            ProcessStartInfo StartInfo = new ProcessStartInfo();
            StartInfo.FileName = path;
            process.StartInfo = StartInfo;
            process.Start();
        }
    }
}
