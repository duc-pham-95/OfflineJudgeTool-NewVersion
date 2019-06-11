using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JudgeTool.Models.Storage
{
    class SystemFolder
    {
        private static readonly string RootDir = Directory.GetCurrentDirectory();
        private static readonly string BaseDir = @"\BASE";
        private static readonly string MainDir = @"\MAIN";
        private static readonly string OutDir = @"\OUT";
        private static readonly string TestInDir = @"\TESTIN";
        private static readonly string TestOutDir = @"\TESTOUT";
        public static string CustomOutDir { get; set; }
        public static string DataDir { get; set; }

        //create directory
        public static void CreateMainDir()
        {
            Directory.CreateDirectory(RootDir + BaseDir + MainDir);
        }
        public static void CreateOutDir()
        {
            Directory.CreateDirectory(RootDir + BaseDir + OutDir);
        }
        public static void CreateTestInDir()
        {
            Directory.CreateDirectory(RootDir + BaseDir + TestInDir);
        }
        public static void CreateTestOutDir()
        {
            Directory.CreateDirectory(RootDir + BaseDir + TestOutDir);
        }
        public static void CreateAll()
        {
            CreateMainDir();
            CreateOutDir();
            CreateTestInDir();
            CreateTestOutDir();
        }
        //delete directory
        public static void DeleteMainDir()
        {
            Directory.Delete(RootDir + BaseDir + MainDir, true);
        }
        public static void DeleteOutDir()
        {
            Directory.Delete(RootDir + BaseDir + OutDir, true);
        }
        public static void DeleteTestOutDir()
        {
            Directory.Delete(RootDir + BaseDir + TestOutDir, true);
        }
        public static void DeleteTestInDir()
        {
            Directory.Delete(RootDir + BaseDir + TestInDir, true);
        }
        public static void DeleteAll()
        {
            DeleteMainDir();
            DeleteOutDir();
            DeleteTestInDir();
            DeleteTestOutDir();
        }
        //clear directory
        public static void ClearMainDir()
        {
            DirectoryInfo dir = new DirectoryInfo(GetMainDir());
            foreach (FileInfo file in dir.GetFiles())
            {
                File.SetAttributes(file.FullName, FileAttributes.Normal);
                File.Delete(file.FullName);
            }
        }
        public static void ClearOutDir()
        {
            if (Directory.Exists(GetOutDir()))
            {
                DirectoryInfo dir = new DirectoryInfo(GetOutDir());
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }
            }
        }
        public static void ClearTestOutDir()
        {
            if (Directory.Exists(RootDir + BaseDir + TestOutDir))
            {
                DirectoryInfo dir = new DirectoryInfo(RootDir + BaseDir + TestOutDir);
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }
            }
        }
        public static void ClearTestInDir()
        {
            if (Directory.Exists(RootDir + BaseDir + TestInDir))
            {
                DirectoryInfo dir = new DirectoryInfo(RootDir + BaseDir + TestInDir);
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }
            }
        }
        public static void ClearCustomDir()
        {
            if (CustomOutDir != null)
            {
                DirectoryInfo dir = new DirectoryInfo(CustomOutDir);
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }
            }
        }
        public static void ClearAll()
        {
            ClearMainDir();
            ClearOutDir();
            ClearCustomDir();
        }
        //get directory
        public static string GetMainDir()
        {
            return RootDir + BaseDir + MainDir;
        }
        public static string GetOutDir()
        {
            if (CustomOutDir == null)
                return RootDir + BaseDir + OutDir;
            return CustomOutDir;
        }
        public static string GetTestInDir()
        {
            return RootDir + BaseDir + TestInDir;
        }
        public static string GetTestOutDir()
        {
            return RootDir + BaseDir + TestOutDir;
        }
        //check directory
        public static Boolean isDirEmpty(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(@path);
            if (dir.GetFiles().Length > 0)
            {
                return false;
            }
            return true;
        }
        //check Dir C#
        public static string GetPathNetFramework()
        {

            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Microsoft.NET\Framework64\"))
            {
                DirectoryInfo dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Microsoft.NET\Framework64\");
                Regex reg = new Regex(@"^v(?<version>\d)");
                string path = "";
                int maxVer = 0;
                foreach (DirectoryInfo subdir in dir.GetDirectories())
                {
                    if (reg.IsMatch(subdir.Name))
                    {
                        foreach (Match version in reg.Matches(subdir.Name))
                        {
                            int ver = int.Parse(version.Groups["version"].ToString());
                            if (ver == 4)
                            {
                                return subdir.FullName;
                            }
                            if (ver >= maxVer)
                            {
                                maxVer = ver;
                                path = subdir.FullName;
                            }
                        }
                    }
                }
                if (maxVer != 0)
                    return path;
            }
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Microsoft.NET\Framework\"))
            {
                DirectoryInfo dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Microsoft.NET\Framework\");
                Regex reg = new Regex(@"^v(?<version>\d)");
                string path = "";
                int maxVer = 0;
                foreach (DirectoryInfo subdir in dir.GetDirectories())
                {
                    if (reg.IsMatch(subdir.Name))
                    {
                        foreach (Match version in reg.Matches(subdir.Name))
                        {
                            int ver = int.Parse(version.Groups["version"].ToString());
                            if (ver == 4)
                            {
                                return subdir.FullName;
                            }
                            if (ver >= maxVer)
                            {
                                maxVer = ver;
                                path = subdir.FullName;
                            }
                        }
                    }
                }
                if (maxVer == 0)
                    return "None";
                return path;
            }
            return "None";
        }
    }
}
