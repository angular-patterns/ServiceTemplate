using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int RuleSetId { get; set; }
        public string JsonValue { get; set; }

        public DateTime CreatedOn { get; set; }


        public virtual IList<ReviewRule> Rules { get; set; }
    }
}
