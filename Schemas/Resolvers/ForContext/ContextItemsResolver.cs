using Business;
using Entities;
using GraphQL.Types;
using Schemas.GraphTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schemas.Resolvers.ForContext
{
    public class ContextItemsResolver : IFieldResolver<Context, ContextItem[]>
    {
        public IFieldType AddField(string name, ObjectGraphType<Context> graphType)
        {
            return graphType.Field<ListGraphType<ContextItemType>>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments();
        }

        public ContextItem[] Resolve(ResolveFieldContext<Context> context)
        {
            var contextId = context.Source.ContextId;
            return ServiceLocator.Instance.GetService<ContextService>().GetContextItems(contextId).ToArray();
        }
    }
}
