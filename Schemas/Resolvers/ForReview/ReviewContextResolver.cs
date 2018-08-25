using Business;
using Business.Services;
using Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Resolvers.ForReview
{
    public class ReviewContextResolver : IFieldResolver<Review, ReviewContext>
    {
        public ReviewContextService ReviewContextService
        {
            get
            {
                return ServiceLocator.ReviewContextService;
            }
        }
        public IFieldType AddField(string name, ObjectGraphType<Review> graphType)
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

        public ReviewContext Resolve(ResolveFieldContext<Review> ctx)
        {
            var reviewContextId = ctx.Source.ReviewContextId;
            return ServiceLocator.Instance.GetService<ReviewContextService>().GetById(reviewContextId);

        }
    }
}
