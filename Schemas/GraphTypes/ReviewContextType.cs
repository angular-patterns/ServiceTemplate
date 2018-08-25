using Business;
using Entities;
using GraphQL.Types;
using Schemas.Resolvers.ForContextItem;
using Schemas.Resolvers.ForReviewType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.GraphTypes
{
    public class ReviewContextType : ObjectGraphType<ReviewContext>
    {
        public ReviewContextItemsResolver ReviewContextItemsResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<ReviewContextItemsResolver>();
            }
        }
        public Resolvers.ForReviewContext.ContextResolver ContextResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<Resolvers.ForReviewContext.ContextResolver>();
            }
        }
        public ReviewContextType()
        {
            Name = "ReviewContext";
            Field("id", d => d.ReviewContextId, nullable: true).Description("The id of the character.");
            Field(d => d.ContextId, nullable: true).Description("The name of the character.");
            Field(d => d.IsActive, nullable: true).Description("The name of the character.");
            Field(d => d.CreatedOn, nullable: true).Description("The name of the character.");
            ReviewContextItemsResolver.AddField("items", this);
            ContextResolver.AddField("context", this);


        }
    }

}
