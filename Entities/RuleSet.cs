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

        public string Code { get; set; }

        public string Name { get; set;  }

        public DateTime CreatedOn { get; set; }

        public virtual Model Model { get; set; }

        public virtual IList<ReviewType> ReviewTypes { get; set; }

        public virtual IList<Review> Reviews { get; set; }
    }
}
