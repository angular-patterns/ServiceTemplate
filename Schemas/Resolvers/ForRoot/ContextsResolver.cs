using System;
using System.Collections.Generic;
using System.Text;
using Business;
using GraphQL.Types;
using Schemas.GraphTypes;

namespace Schemas.Resolvers.ForRoot
{
    public class ContextsResolver : IFieldResolver
    {
        public ContextService ContextService { get; }
        public ContextsResolver(ContextService contextService)
        {
            ContextService = contextService;
        }


        public IFieldType AddField(string name, ObjectGraphType graphType)
        {
            return graphType.Field<ListGraphType<ContextType>>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments();
        }

        public object Resolve(ResolveFieldContext<object> context)
        {
            return ContextService.GetAll();
        }
    }
}
