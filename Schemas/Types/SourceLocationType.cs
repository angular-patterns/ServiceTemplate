using DynamicRules.Common.Compilation;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Types
{
    public class SourceLocationType : ObjectGraphType<SourceLocation>
    {
        public SourceLocationType() {
            Name = "SourceLocation";
            Field(d => d.IsInSource, nullable: true);
            Field(d => d.Start, nullable: true);
            Field(d => d.End, nullable: true);
            Field(d => d.Fragment, nullable: true);
        }
    }
}
