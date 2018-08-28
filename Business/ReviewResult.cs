using DynamicRules.Common.Validation;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ReviewResult
    {
        public bool Success { get; set; }

        public IList<ReviewRule> Rules { get; set; }

        public IList<ValidationError> SchemaErrors { get; set; }
    }
}
