using DynamicRules.Core;
using NJsonSchema.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRules.Interfaces
{
    public interface IJsonValidator
    {
        Task<ValidationResult> Validate(string schema, string jsonData);
    }

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
