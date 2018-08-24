using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Context
    {
        public int ContextId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public virtual IList<ContextItem> ContextItems { get; set; }

        public bool IsActive { get; set; }

    }
}
