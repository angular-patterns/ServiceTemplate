using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class ReviewRuleType
    {
        public int ReviewRuleTypeId { get; set; }

        [ForeignKey("RuleSet")]
        public int RuleSetId { get; set; }

        public string Logic { get; set; }

        public string BusinessId { get; set; }

        public string Message { get; set; }

    }
}
