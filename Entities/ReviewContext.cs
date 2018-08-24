using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ReviewContext
    {
        public int ReviewContextId { get; set; }

        public int ContextId { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual IList<ReviewContextItem> ContextItems { get; set; }

        public bool IsActive { get; set; }
    }
}
