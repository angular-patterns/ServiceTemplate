using Business;
using Business.Services;
using Entities;
using GraphQL.Types;
using Schemas.GraphTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Resolvers.ForContextItem
{
    public class ContextResolver : IFieldResolver<ContextItem, Context>
    {
        public ContextService ContextService
        {
            get
            {
                return ServiceLocator.ContextService;
            }
        }

        public IFieldType AddField(string name, ObjectGraphType<ContextItem> graphType)
        {
            return graphType.Field<ContextType>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);

        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments();
        }

        public Context Resolve(ResolveFieldContext<ContextItem> context)
        {
            var contextId = context.Source.ContextId;
            return ContextService.GetById(contextId);
        }
    }
}
