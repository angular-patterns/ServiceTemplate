using Business;
using Entities;
using GraphQL.Types;
using Schemas.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schemas.Resolvers.ForReviewType
{
    public class ReviewContextItemsResolver : IFieldResolver<ReviewContext, ReviewContextItem[]>
    {
        public IFieldType AddField(string name, ObjectGraphType<ReviewContext> graphType)
        {
            return graphType.Field<ListGraphType<ReviewContextItemType>>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments();
        }

        public ReviewContextItem[] Resolve(ResolveFieldContext<ReviewContext> context)
        {
            var contextId = context.Source.ReviewContextId;
            return ServiceLocator.ReviewContextService.GetContextItems(contextId).ToArray();
        }
    }
}
