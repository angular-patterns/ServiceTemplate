using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Business.Services;
using GraphQL.Types;
using Schemas.Types;

namespace Schemas.Resolvers.ForRoot
{
    public class ContextsResolver : IFieldResolver
    {
        public ContextService ContextService
        {
            get
            {
                return ServiceLocator.ContextService;
            }
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
