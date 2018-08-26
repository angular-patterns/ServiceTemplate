using Business;
using Business.Services;
using Entities;
using GraphQL.Types;
using Schemas.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Resolvers.ForReview
{
    public class RuleSetResolver : IFieldResolver<Review, RuleSet>
    {
        public RuleSetService RuleSetService
        {
            get
            {
                return ServiceLocator.RuleSetService;
            }
        }
        public IFieldType AddField(string name, ObjectGraphType<Review> graphType)
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

        public RuleSet Resolve(ResolveFieldContext<Review> context)
        {
            return RuleSetService.GetById(context.Source.RuleSetId);

        }
    }
}
