using Business;
using Business.Services;
using Entities;
using GraphQL.Types;
using Schemas.Resolvers;
using Schemas.Resolvers.ForReviewContextItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.GraphTypes
{
    public class ReviewContextItemType : ObjectGraphType<ReviewContextItem>
    {
        public ModelResolver ModelResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<ModelResolver>();
            }
        }
        public ReviewContextResolver ReviewContextResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<ReviewContextResolver>();
            }
        }
        public ReviewContextItemType()
        {
            Name = "ReviewContextItem";
            Field("id", d => d.ContextItemId, nullable: true).Description("The id of the character.");
            Field(d => d.ReviewContextId, nullable: true).Description("The name of the character.");
            Field(d => d.JsonValue, nullable: true).Description("The name of the character.");
            Field(d => d.Key, nullable: true).Description("The name of the character.");
            Field(d => d.ModelId, nullable: true).Description("The name of the character.");
            ModelResolver.AddField("model", this);
            ReviewContextResolver.AddField("reviewContext", this);

        }
    }

}
