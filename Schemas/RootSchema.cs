using GraphQL;
using GraphQL.Types;
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

        public async Task<ExecutionResult> ExecuteQuery(string query)
        {
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = this;
                _.Query = query;

            }).ConfigureAwait(false);

            return result;
        }
    }
}
