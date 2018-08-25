using Business;
using Entities;
using GraphQL.Types;
using Schemas.GraphTypes;
using Schemas.Resolvers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Resolvers.ForRoot
{
    public class ReviewsResolver : IFieldResolver
    {
        public ReviewService ReviewService { get; }

        public ReviewsResolver(ReviewService reviewService)
        {
            ReviewService = reviewService;
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments(
                new QueryArgument<IntGraphType>() { Name = "id" },
                new QueryArgument<IntGraphType>() { Name = "ruleSetId" },
                new QueryArgument<StringGraphType>() { Name = "businessId" }
            );
        }

        public object Resolve(ResolveFieldContext<object> ctx)
        {
            if (ctx.HasArgument("id"))
            {
                var reviewId = ctx.GetArgument<int>("id");
                var review = ReviewService.GetById(reviewId);
                return new List<Review>() { review };
            }
            else if (ctx.HasArgument("ruleSetId"))
            {
                var ruleSetId = ctx.GetArgument<int>("ruleSetId");
                return ReviewService.GetByRuleSetId(ruleSetId);

            }
            else if (ctx.HasArgument("businessId"))
            {
                var businessId = ctx.GetArgument<string>("businessId");
                return ReviewService.GetReviewsByBusinessId(businessId);

            }
            else
            {

                return ReviewService.GetAll();
            }


        }

        public IFieldType AddField(string name, ObjectGraphType graphType)
        {
            return graphType.Field<ListGraphType<ReviewType>>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);
        }
    }
}
