using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class RuleSet
    {
        public int RuleSetId { get; set; }

        [ForeignKey("Model")]
        public int ModelId { get; set; }

        [ForeignKey("Context")]
        public int ContextId { get; set; }

        public string BusinessId { get; set; }

        public string Title { get; set;  }

        public DateTime CreatedOn { get; set; }

        public virtual Model Model { get; set; }

        public virtual IList<ReviewType> ReviewTypes { get; set; }

        public virtual IList<Review> Reviews { get; set; }
    }
}
