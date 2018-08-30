using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class ReviewContext
    {
        public int ReviewContextId { get; set; }

        [ForeignKey("Context")]
        public int ContextId { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual IList<ReviewContextItem> ContextItems { get; set; }

        public bool IsActive { get; set; }
    }
}
