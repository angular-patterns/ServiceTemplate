using GraphQL;
using GraphQL.Types;
using Models;
using System;
using System.Threading.Tasks;

namespace Schemas
{
    public class RootSchema : Schema
    {
        public RootSchema(RootQuery query, RootMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }

        public async Task<ExecutionResult> ExecuteQuery(GraphQLQuery query)
        {
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = this;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                if (query.Variables != null)
                {
                    _.Inputs = new Inputs(query.Variables);
                }





            }).ConfigureAwait(false);

            return result;
        }
    }
}
