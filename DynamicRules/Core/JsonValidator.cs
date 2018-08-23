using NJsonSchema;
using NJsonSchema.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DynamicRules.Interfaces;


namespace DynamicRules.Core
{
    public class JsonValidator: IJsonValidator
    {

        public async Task<ValidationResult> Validate(string schema, string jsonData)
        {
            var jsonSchema = await JsonSchema4.FromJsonAsync(schema);
            var errors = jsonSchema.Validate(jsonData);
            return new ValidationResult(errors.Count == 0, new List<ValidationError>(errors));
        }

    }

  
}
