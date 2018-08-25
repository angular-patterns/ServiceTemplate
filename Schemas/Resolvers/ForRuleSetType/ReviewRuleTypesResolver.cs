using Business;
using Business.Services;
using Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schemas.Resolvers.ForRuleSetType
{
    public class ReviewRuleTypesResolver : IFieldResolver<RuleSet, Entities.ReviewRuleType[]>
    {
        public RuleSetService RuleSetService = ServiceLocator.RuleSetService;
        public IFieldType AddField(string name, ObjectGraphType<RuleSet> graphType)
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

        public Entities.ReviewRuleType[] Resolve(ResolveFieldContext<RuleSet> context)
        {
            return RuleSetService.GetReviewTypes(context.Source.RuleSetId).ToArray();
        }
    }
}
