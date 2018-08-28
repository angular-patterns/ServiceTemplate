
using DynamicRules.Common.Compilation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ModelValidationResult 
    {
        public bool Success { get; set; }
        public bool TypeFound { get; set; }
        public bool CompileSucceeded { get; set; }
        public Type ModelType { get; set; }

        public IList<CompilerError> CompileErrors { get; set; }
      
    }
}
