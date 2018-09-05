
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas
{
    public class RootMutation: ObjectGraphType
    {
        public RootMutation()
        {
            Field<StringGraphType>("createSomething", resolve: null);
        }
    }
}
