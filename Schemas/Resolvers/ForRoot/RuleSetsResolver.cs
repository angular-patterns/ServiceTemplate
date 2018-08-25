using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Entities;
using GraphQL.Types;

namespace Schemas.Resolvers.ForRoot
{
    public class RuleSetsResolver : IFieldResolver
    {
        public QueryArguments GetArguments()
        {
            return new QueryArguments(
                new QueryArgument<IntGraphType>() { Name = "modelId" },
                new QueryArgument<IntGraphType>() { Name = "id" }
            );
        }

        public object Resolve(ResolveFieldContext<object> ctx)
        {
            var list = new List<RuleSet>();
            if (ctx.HasArgument("modelId"))
            {

                var modelId = ctx.GetArgument<int>("modelId");
                var ruleSets = ServiceLocator.Instance.GetService<RuleSetService>().GetByModelId(modelId);
                if (ruleSets != null)
                    list.AddRange(ruleSets);
            }

            if (ctx.HasArgument("id"))
            {
                var ruleSetId = ctx.GetArgument<int>("id");
                var ruleSet = ServiceLocator.Instance.GetService<RuleSetService>().GetById(ruleSetId);
                if (ruleSet != null)
                    list.Add(ruleSet);

            }

            if (list.Count == 0)
            {

                list.AddRange(ServiceLocator.Instance.GetService<RuleSetService>().GetAll());
            }
            return list;

        }

        public IFieldType AddField(string name, ObjectGraphType graphType)
        {
            return graphType.Field<ListGraphType<RuleSetType>>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);

        }

    }
}
