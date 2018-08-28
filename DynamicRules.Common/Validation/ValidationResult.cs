

using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRules.Common.Validation
{
    public class ValidationResult
    {
        public bool Success { get; set; }

        public List<ValidationError> Errors { get; set; }

        public ValidationResult(bool success, List<ValidationError> errors)
        {
            this.Success = success;
            this.Errors = errors;
        }
    }
}
