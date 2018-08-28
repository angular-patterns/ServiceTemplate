using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicRules.Common;
using DynamicRules.Common.Validation;
using NJsonSchema;

namespace DynamicRules.Core
{
    public class JsonValidator: IJsonValidator
    {

        public async Task<ValidationResult> Validate(string schema, string jsonData)
        {
            var jsonSchema = await JsonSchema4.FromJsonAsync(schema);
            var errors = jsonSchema.Validate(jsonData);
            return new ValidationResult(errors.Count == 0, errors.Select(t=> Convert(t)).ToList());
        }

        private ValidationError Convert(NJsonSchema.Validation.ValidationError error)
        {
            return new ValidationError
            {
                HasLineInfo = error.HasLineInfo,
                Kind = Enum.Parse<ValidationErrorKind>(error.Kind.ToString(), true),
                LineNumber = error.LineNumber,
                LinePosition = error.LinePosition,
                Path = error.Path,
                Property = error.Property
            };
        }

    }

  
}
