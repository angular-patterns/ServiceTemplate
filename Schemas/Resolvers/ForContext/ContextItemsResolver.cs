using Business;
using Business.Services;
using Entities;
using GraphQL.Types;
using Schemas.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schemas.Resolvers.ForContext
{
    public class ContextItemsResolver : IFieldResolver<Context, ContextItem[]>
    {
        public ContextService ContextService
        {
            get
            {
                return ServiceLocator.ContextService;
            }
        }
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
            return ContextService.GetContextItems(contextId).ToArray();
        }
    }
}
