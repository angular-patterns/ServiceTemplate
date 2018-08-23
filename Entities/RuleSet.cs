using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RuleSet
    {
        public int RuleSetId { get; set; }

        public int ModelId { get; set; }

        public string Name { get; set;  }

        public DateTime CreatedOn { get; set; }
    }
}
