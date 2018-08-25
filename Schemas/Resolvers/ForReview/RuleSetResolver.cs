using Business;
using Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Resolvers.ForReview
{
    public class RuleSetResolver : IFieldResolver<Review, RuleSet>
    {
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
            return ServiceLocator.Instance.GetService<RuleSetService>().GetById(context.Source.RuleSetId);

        }
    }
}
