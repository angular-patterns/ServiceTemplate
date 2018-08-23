using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ReviewRule
    {
        public int ReviewRuleId { get; set; }

        public int ReviewTypeId { get; set; }

        public int RuleSetId { get; set; }

        public string BusinessId { get; set; }

        public string Message { get; set; }

        public bool IsSatisfied { get; set; }

    }
}
