
using Entities;
using GraphQL.Types;
using Models;
using Schemas.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<ApplicationType>("applications",description:"Something", resolve: ctx => {
                return new Application();
            });
        }

    }



}
