using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Business.Services;
using GraphQL.Types;
using Schemas.GraphTypes;

namespace Schemas.Resolvers.ForRoot
{
    public class ReviewContextsResolver : IFieldResolver
    {
        public ReviewContextService ReviewContextsService
        {
            get
            {
                return ServiceLocator.ReviewContextService;
            }
        }


        public IFieldType AddField(string name, ObjectGraphType graphType)
        {
            return graphType.Field<ListGraphType<ReviewContextType>>(
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
            return ReviewContextsService.GetAll();

        }
    }
}
