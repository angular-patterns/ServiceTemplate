using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRules.Common.Compilation
{
    public class SourceLocation
    {
        public bool IsInSource { get; set; }
        public int Start { get; set; }

        public int End { get; set; }
        public string Fragment { get; set; }
    }
}
