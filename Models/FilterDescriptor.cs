using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public enum FilterOperator
    {
        IsEqualTo, 
        IsNotEqualTo,
        IsNull,
        IsNotNull,

        // date
        IsAfterOrEqualTo,
        IsAfter,
        IsBeforeOrEqualTo,
        IsBefore,
        
        // string
        Contains, 
        DoesNotContain,
        StartsWith,
        EndsWith, 
        IsEmpty, 
        IsNotEmpty,

        // numeric
        IsGreaterThanOrEqualto,
        IsGreaterThan,
        IsLessThanOrEqualTo,
        IsLessThan

    }

    public class FilterDescriptor
    {
        public string Field { get; set; }

        public FilterOperator Operator { get; set; } 

        public object Value { get; set; }
    }
}
