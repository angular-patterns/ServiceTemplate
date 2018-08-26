using Business;
using Entities;
using GraphQL.Types;
using Schemas.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Resolvers.ForReviewContext
{
    public class ContextResolver : IFieldResolver<ReviewContext, Context>
    {
        public IFieldType AddField(string name, ObjectGraphType<ReviewContext> graphType)
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

        public Context Resolve(ResolveFieldContext<ReviewContext> context)
        {
            var contextId = context.Source.ContextId;
            return ServiceLocator.ContextService.GetById(contextId);
        }
    }
}
