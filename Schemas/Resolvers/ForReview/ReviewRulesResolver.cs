using Business;
using Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schemas.Resolvers.ForReview
{
    public class ReviewRulesResolver : IFieldResolver<Review, ReviewRule[]>
    {
        public IFieldType AddField(string name, ObjectGraphType<Review> graphType)
        {
            return graphType.Field<ListGraphType<ReviewRuleType>>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments();
        }

        public ReviewRule[] Resolve(ResolveFieldContext<Review> ctx)
        {
            return ServiceLocator.Instance.GetService<ReviewService>().GetRules(ctx.Source.ReviewId).ToArray();
        }
    }
}
