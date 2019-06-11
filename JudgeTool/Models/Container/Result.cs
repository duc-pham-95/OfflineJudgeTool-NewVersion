using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeTool.Models.Container
{
    public class Result
    {
        public StringBuilder output { get; set; }
        public StringBuilder error { get; set; }

        public Result(StringBuilder output, StringBuilder error)
        {
            this.output = output;
            this.error = error;
        }
    }
}
