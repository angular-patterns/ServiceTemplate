using Business;
using Business.Services;
using Entities;
using GraphQL.Types;
using Schemas.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Resolvers.ForReviewRuleType
{
    public class RuleSetResolver : IFieldResolver<Entities.ReviewRuleType, RuleSet>
    {
        public RuleSetService RuleSetService = ServiceLocator.RuleSetService;
        public IFieldType AddField(string name, ObjectGraphType<Entities.ReviewRuleType> graphType)
        {
            return graphType.Field<RuleSetType>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments();
        }

        public RuleSet Resolve(ResolveFieldContext<Entities.ReviewRuleType> context)
        {
            return RuleSetService.GetById(context.Source.RuleSetId);
        }
    }
}
