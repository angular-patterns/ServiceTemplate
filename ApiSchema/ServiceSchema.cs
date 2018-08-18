using GraphQL.Types;
using System;

namespace ApiSchema
{
    public class ServiceSchema: Schema
    {
        public ServiceSchema(IObjectGraphType query, ServiceMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
