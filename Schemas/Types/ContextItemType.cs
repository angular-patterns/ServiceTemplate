using Business;
using Entities;
using GraphQL.Types;
using Schemas.Resolvers.ForContextItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Types
{
    public class ContextItemType : ObjectGraphType<ContextItem>
    {
        public ModelResolver ModelResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<ModelResolver>();
            }
        }
        public ContextResolver ContextResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<ContextResolver>();
            }
        }
        public ContextItemType()
        {
            Name = "ContextItem";
            Field("id", d => d.ContextItemId, nullable: true).Description("The id of the character.");
            Field(d => d.ContextId, nullable: true).Description("The name of the character.");
            Field(d => d.JsonValue, nullable: true).Description("The name of the character.");
            Field(d => d.Key, nullable: true).Description("The name of the character.");
            Field(d => d.ModelId, nullable: true).Description("The name of the character.");
            ModelResolver.AddField("model", this);
            ContextResolver.AddField("context", this); 

        }
    }
}
