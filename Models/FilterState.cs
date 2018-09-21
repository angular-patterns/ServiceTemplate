using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public enum FilterLogic
    {
        And,
        Or
    }
    public class FilterState
    {
        public FilterLogic Logic { get; set; }
        public IList<FilterDescriptor> Filters { get; set; }
    }
}
