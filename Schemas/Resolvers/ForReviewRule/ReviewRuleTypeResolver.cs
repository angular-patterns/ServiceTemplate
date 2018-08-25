using Business;
using Business.Services;
using Entities;
using GraphQL.Types;
using Schemas.GraphTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Resolvers.ForReviewRule
{
    public class ReviewRuleTypeResolver : IFieldResolver<ReviewRule, Entities.ReviewRuleType>
    {
        public ReviewRuleTypeService ReviewRuleTypeService = ServiceLocator.ReviewRuleTypeService;
        public IFieldType AddField(string name, ObjectGraphType<ReviewRule> graphType)
        {
            return graphType.Field<ReviewRuleTypeType>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments();
        }

        public Entities.ReviewRuleType Resolve(ResolveFieldContext<ReviewRule> context)
        {
            return ReviewRuleTypeService.GetById(context.Source.ReviewRuleTypeId);
        }
    }
}
