using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRules.Common.Validation
{
    //
    // Summary:
    //     A validation error.
    public class ValidationError
    {

        //
        // Summary:
        //     Gets the error kind.
        public ValidationErrorKind Kind { get; set; }
        //
        // Summary:
        //     Gets the property name.
        public string Property { get; set; }
        //
        // Summary:
        //     Gets the property path.
        public string Path { get; set; }
        //
        // Summary:
        //     Indicates whether or not the error contains line information.
        public bool HasLineInfo { get; set; }
        //
        // Summary:
        //     Gets the line number the validation failed on.
        public int LineNumber { get; set; }
        //
        // Summary:
        //     Gets the line position the validation failed on.
        public int LinePosition { get; set; }
       

    }
}
