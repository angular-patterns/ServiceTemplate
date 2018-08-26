using Business;
using Business.Services;
using Entities;
using GraphQL.Types;
using Schemas.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Resolvers.ForReviewContextItem
{
    public class ReviewContextResolver : IFieldResolver<ReviewContextItem, ReviewContext>
    {
        public ReviewContextService ReviewContextService = ServiceLocator.ReviewContextService;
        public IFieldType AddField(string name, ObjectGraphType<ReviewContextItem> graphType)
        {
            return graphType.Field<ReviewContextType>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments();
        }

        public ReviewContext Resolve(ResolveFieldContext<ReviewContextItem> context)
        {
            var reviewContextId = context.Source.ReviewContextId;
            return ReviewContextService.GetById(reviewContextId);
        }
    }
}
