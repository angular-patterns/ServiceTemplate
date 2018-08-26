using Business;
using Entities;
using GraphQL.Types;
using Schemas.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schemas.Resolvers.ForModel
{
    public class RuleSetsResolver : IFieldResolver<Model, RuleSet[]>
    {
        public IFieldType AddField(string name, ObjectGraphType<Model> graphType)
        {
            return graphType.Field<ListGraphType<RuleSetType>>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments();
        }

        public RuleSet[] Resolve(ResolveFieldContext<Model> context)
        {
            return ServiceLocator.RuleSetService.GetByModelId(context.Source.ModelId).ToArray();
        }
    }
}
