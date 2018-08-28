using DynamicRules.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRules.Common
{
    public interface IJsonValidator
    {
        Task<ValidationResult> Validate(string schema, string jsonData);
    }

}
