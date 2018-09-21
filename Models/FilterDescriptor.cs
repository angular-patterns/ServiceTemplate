using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public enum FilterOperator
    {
        EQ, //IsEqualTo, 
        NEQ, //IsNotEqualTo,
        ISNULL, //IsNull,
        ISNOTNULL, //IsNotNull,

        // date
        ISAFTEROREQUALTO, //IsAfterOrEqualTo,
        ISAFTER, //IsAfter,
        ISBEFOREOREQUALTO, //IsBeforeOrEqualTo,
        ISBEFORE, //IsBefore,
        
        // string
        CONTAINS, //Contains, 
        DOESNOTCONTAIN, //DoesNotContain,
        STARTSWITH, //StartsWith,
        ENDSWITH, //EndsWith, 
        ISEMPTY, //IsEmpty, 
        ISNOTEMPTY, //IsNotEmpty,

        // numeric
        ISGREATERTHANOREQUALTO, // IsGreaterThanOrEqualto,
        ISGREATERTHAN, //IsGreaterThan,
        ISLESSTHANOREQUALTO, //IsLessThanOrEqualTo,
        ISLESSTHAN //IsLessThan

    }

    public class FilterDescriptor
    {
        public string Field { get; set; }

        public FilterOperator Operator { get; set; } 

        public object Value { get; set; }
    }
}
