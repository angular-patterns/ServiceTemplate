using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class ReviewRule
    {
        public int ReviewRuleId { get; set; }

        [ForeignKey("Review")]
        public int ReviewId { get; set; }

        [ForeignKey("ReviewRuleType")]
        public int ReviewRuleTypeId { get; set; }

        public string BusinessId { get; set; }

        public string Message { get; set; }

        public bool IsSatisfied { get; set; }

        public virtual ReviewRuleType ReviewType { get; set; }

    }
}
