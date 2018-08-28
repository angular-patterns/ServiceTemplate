using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRules.Common.Compilation
{
    public class CompilerException: Exception 
    {
        public IList<CompilerError> Errors { get; set; }

        public CompilerException(string message, IList<CompilerError> errors): base(message)
        {
            this.Errors = errors;
        }
    }
}
