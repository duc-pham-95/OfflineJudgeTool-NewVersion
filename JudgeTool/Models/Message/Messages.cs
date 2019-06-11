using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JudgeTool.Models.Message
{
    class Messages
    {
        public static readonly string CompileError = "Compile Error ! Please make sure that the syntax is correct";
        public static readonly string JdkError = "Missing JDK error ! Please make sure that you've installed JDK";
        public static readonly string RunTimeError = "Runtime Error ! Exception occurs while running";
        public static readonly string TimeLimitError = "Time limit exceeded !";

        public static string GetErrorType(string error)
        {
            Regex regC = new Regex("Main.java");
            Regex regC2 = new Regex("Could not find or load main class");
            Regex regE = new Regex("Exception");
            Regex regJ = new Regex("javac");
            if (regE.IsMatch(error))
            {
                return RunTimeError;
            }
            else if (regC.IsMatch(error) || regC2.IsMatch(error))
            {
                return CompileError;
            }
            else if (error[0] == 'T')
            {
                return TimeLimitError;
            }
            else if (regJ.IsMatch(error))
            {
                return JdkError;
            }
            return "Undetected error, please see detail !";
        }
    }
}
