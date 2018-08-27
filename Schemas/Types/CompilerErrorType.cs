using DynamicRules.Interfaces;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Types
{
    public class CompilerErrorType: ObjectGraphType<CompilerError>
    {
        public CompilerErrorType()
        {
            Name = "CompilerError";
            Field(d => d.Code, nullable: true);
            Field(d => d.Message, nullable: true);
            Field<SourceLocationType>(
                name: "location", 
                resolve: ctx=> ctx.Source.Location);

            Field(d => d.Severity, nullable: true);
            Field(d => d.StackTrace, nullable: true);
        }
    }
}
