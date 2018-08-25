using Business;
using Entities;
using GraphQL.Types;
using Schemas.Resolvers.ForContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.GraphTypes
{
    public class ContextType : ObjectGraphType<Context>
    {
        public ContextItemsResolver ContextItemsResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<ContextItemsResolver>();
            }
        }
        public ContextType()
        {
            Name = "Context";
            Field("id", d => d.ContextId, nullable: true).Description("The id of the character.");
            Field(d => d.IsActive, nullable: true).Description("The name of the character.");
            Field(d => d.CreatedOn, nullable: true).Description("The name of the character.");
            ContextItemsResolver.AddField("items", this);


        }
    }


}
