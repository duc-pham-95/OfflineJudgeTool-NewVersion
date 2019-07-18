using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeTool.Models.Storage
{
    class SystemFile
    {
        public static readonly string pathFormat = @"\";
        public static readonly string targetFileName = "Main";
        public static readonly string textFileExtension = ".txt";
        public static string answerFileExtension = ".ans";
        public static string outputFileExtension = ".out";
        public static string customFileExtension = ".txt";
        public static readonly string javaFileExtension = ".java";
        public static readonly string csharpFileExtension = ".cs";

        public static string GetJavaFilePath()
        {
            return SystemFolder.GetMainDir() + pathFormat + targetFileName + javaFileExtension;
        }

        public static string GetCSharpFilePath()
        {
            return SystemFolder.GetMainDir() + pathFormat + targetFileName + csharpFileExtension;
        }

        public static void WriteTextToFile(string path, string[] text)
        {
            File.WriteAllLines(path, text);
        }

        public static void GetData(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(SystemFolder.DataDir);
            foreach (FileInfo file in dir.GetFiles())
            {
                
                if (file.Extension.Equals(".in"))
                {
                    
                    file.CopyTo(SystemFolder.GetTestInDir() + @"\" + file.Name);
                }
                if (file.Extension.Equals(".out") || file.Extension.Equals(".ans"))
                {
                    string text = File.ReadAllText(file.FullName);
                    File.WriteAllText(SystemFolder.GetTestOutDir() + @"\" + file.Name, text.TrimEnd('\n').TrimEnd('\r'));
                    //file.CopyTo(SystemFolder.GetTestOutDir() + @"\" + file.Name);
                }
            }
        }

        public static string[] GetFileContent(string path)
        {
            return File.ReadAllLines(path);
        }

        public static string GetFileContentText(string path)
        {
            return File.ReadAllText(path);
        }

        public static string[] GetInputFilePaths(string path)
        {

            DirectoryInfo dir = new DirectoryInfo(path);
            string[] filePaths = new string[dir.GetFiles().Length];
            int i = 0;
            foreach (FileInfo File in dir.GetFiles())
            {
                string name = path + @"\" + File.Name;
                filePaths[i++] = name;
            }
            return filePaths;
        }

        public static string[] GetOutputFilePaths(string path)
        {
            string extenstion = customFileExtension != null ? customFileExtension : textFileExtension;
            DirectoryInfo dir = new DirectoryInfo(path);
            string[] filePaths = new string[dir.GetFiles().Length];
            int i = 0;
            foreach (FileInfo file in dir.GetFiles())
            {
                int index = file.Name.LastIndexOf('.');
                string temp = file.Name.Substring(0, index);
                string name = SystemFolder.GetOutDir() + @"\" + temp + extenstion;
                filePaths[i++] = name;
            }
            return filePaths;
        }

        public static string[] GetRunJavaCommands(string Path)
        {
            string OutType = textFileExtension;
            if (customFileExtension.Equals(outputFileExtension))
            {
                OutType = outputFileExtension;
            }
            if (customFileExtension.Equals(answerFileExtension))
            {
                OutType = answerFileExtension;
            }
            DirectoryInfo Dir = new DirectoryInfo(Path);
            string[] Commands = new string[Dir.GetFiles().Length];
            int i = 0;
            foreach (FileInfo File in Dir.GetFiles())
            {
                int Index = File.Name.LastIndexOf('.');
                string Temp = File.Name.Substring(0, Index);
                string Command = "java Main < " + '"' + Path + @"\" + File.Name + '"' + " > " + '"' + SystemFolder.GetOutDir() + @"\" + Temp + OutType + '"';
                Commands[i++] = Command;
            }
            return Commands;
        }

        public static string[] GetRunCSharpCommands(string Path)
        {
            string OutType = textFileExtension;
            if (customFileExtension.Equals(outputFileExtension))
            {
                OutType = outputFileExtension;
            }
            if (customFileExtension.Equals(answerFileExtension))
            {
                OutType = answerFileExtension;
            }
            DirectoryInfo Dir = new DirectoryInfo(Path);
            string[] Commands = new string[Dir.GetFiles().Length];
            int i = 0;
            foreach (FileInfo File in Dir.GetFiles())
            {
                int Index = File.Name.LastIndexOf('.');
                string Temp = File.Name.Substring(0, Index);
                string Command = "Main < " + '"' + Path + @"\" + File.Name + '"' + " > " + '"' + SystemFolder.GetOutDir() + @"\" + Temp + OutType + '"';
                Commands[i++] = Command;
            }
            return Commands;
        }

        public static Boolean IsFileEmpty(string Path)
        {
            if (new FileInfo(Path).Length > 0)
            {
                return false;
            }
            return true;
        }
    }
}
