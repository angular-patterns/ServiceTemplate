using DynamicRules.Interfaces;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Types
{
    public class CompilerResultType: ObjectGraphType<CompilerResult>
    {
        public CompilerResultType()
        {
            Name = "CompilerResult";
            Field(d => d.Success, nullable: true).Description("The name of the character.");
            Field<ListGraphType<CompilerErrorType>>("errors", resolve: ctx=> ctx.Source.Errors);
        }

    }
}
