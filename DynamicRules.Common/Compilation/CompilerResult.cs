
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DynamicRules.Common.Compilation
{
    public class CompilerResult
    {
        public bool Success { get; set; }
        public IList<CompilerError> Errors { get; set; }

        public Assembly Assembly { get; set; }

        public CompilerResult()
        {
            Errors = new List<CompilerError>();
        }
        public override string ToString()
        {
            var errors = String.Join("\n", this.Errors.Select(t => t.ToString()).ToArray());
            return $@"
Success: {Success}
Errors: {errors}
            ";
        }
    }
}
