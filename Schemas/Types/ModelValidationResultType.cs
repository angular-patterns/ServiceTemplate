using GraphQL.Types;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Types
{
    public class ModelValidationResultType: ObjectGraphType<ModelValidationResult>
    {
        public ModelValidationResultType()
        {
            Name = "ModelValidationResult";
            Field(d => d.Success, nullable: true).Description("The name of the character.");
            Field(d => d.TypeFound, nullable: true).Description("The error message");
            Field(d => d.CompileSucceeded, nullable: true).Description("The error message");

            Field<ListGraphType<CompilerErrorType>>("compileErrors", resolve: ctx => ctx.Source.CompileErrors);
        }
    }
}
