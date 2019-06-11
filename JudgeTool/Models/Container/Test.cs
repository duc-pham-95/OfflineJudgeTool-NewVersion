using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeTool.Models.Container
{
    public class Test
    {
        public Test(string inputPath, string correctOutputPath, string targetOutputPath)
        {
            InputPath = inputPath;
            CorrectOutputPath = correctOutputPath;
            TargetOutputPath = targetOutputPath;
        }

        public Test()
        {

        }

        public string InputPath { get; set; }
        public string CorrectOutputPath { get; set; }
        public string TargetOutputPath { get; set; }


    }
}
