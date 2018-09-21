using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class QueryState
    {
        public int Skip { get; set; }

        public int Take { get; set; }

        public SortDescriptor[] Sort { get; set; }

        public GroupDescriptor[] Group { get; set; }

        public FilterState Filter { get; set; }
       
    }
}
