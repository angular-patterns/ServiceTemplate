﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Review
    {
        public int ReviewId { get; set; }

        [ForeignKey("RuleSet")]
        public int RuleSetId { get; set; }
        public string JsonValue { get; set; }

        public string Code { get; set; }

        public int VersionNumber { get; set; }

        public int RevisionNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        
        public virtual RuleSet RuleSet { get; set; }
        public virtual IList<ReviewRule> ReviewRules { get; set; }
    }
}
