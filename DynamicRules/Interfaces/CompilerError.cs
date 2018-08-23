using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRules.Interfaces
{
    public class CompilerError
    {

        public string Code { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public string Severity { get; set; }

        public SourceLocation Location { get; set; }

        public override string ToString()
        {
            return $"{Code} {Message}";
        }
    }

}
