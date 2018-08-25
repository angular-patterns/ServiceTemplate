using Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.GraphTypes
{
    public class ModelType : ObjectGraphType<Model>
    {

        public ModelType()

        {
            Name = "Model";
            Field("id", d => d.ModelId, nullable: true).Description("The id of the character.");
            //Field(d => d.AccountId, nullable: true).Description("The name of the character.");
            //Field(d => d.CSharpSource, nullable: true).Description("The name of the character.");
            //Field(d => d.JsonSchema, nullable: true).Description("The name of the character.");
            //Field(d => d.TypeName, nullable: true).Description("The name of the character.");
            //Field(d => d.Namespace, nullable: true).Description("The name of the character.");
            //Field<ListGraphType<RuleSetType>>(
            //    name: "ruleSets",
            //    resolve: ctx =>
            //    {
            //        var modelId = ctx.Source.ModelId;
            //        return ServiceLocator.Instance.GetService<RuleSetService>().GetByModelId(modelId);
            //    });

        }
    }

}
