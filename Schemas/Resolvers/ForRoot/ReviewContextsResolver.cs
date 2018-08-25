using System;
using System.Collections.Generic;
using System.Text;
using Business;
using GraphQL.Types;

namespace Schemas.Resolvers.ForRoot
{
    public class ReviewContextsResolver : IFieldResolver
    {
        public ReviewContextService ReviewContextsService { get; }
        public ReviewContextsResolver(ReviewContextService reviewContextsService)
        {
            ReviewContextsService = reviewContextsService;
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
