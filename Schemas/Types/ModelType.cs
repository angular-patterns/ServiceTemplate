using Business;
using Entities;
using GraphQL.Types;
using Schemas.Resolvers.ForModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Types
{
    public class ModelType : ObjectGraphType<Model>
    {
        public RuleSetsResolver RuleSetsResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<RuleSetsResolver>();
            }
        }
        public ModelType()

        {
            Name = "Model";
            Field("id", d => d.ModelId, nullable: true).Description("The id of the character.");
            Field(d => d.AccountId, nullable: true).Description("The name of the character.");
            Field(d => d.CSharpSource, nullable: true).Description("The name of the character.");
            Field(d => d.JsonSchema, nullable: true).Description("The name of the character.");
            Field(d => d.TypeName, nullable: true).Description("The name of the character.");
            Field(d => d.Namespace, nullable: true).Description("The name of the character.");
            RuleSetsResolver.AddField("ruleSets", this);

        }
    }

}
