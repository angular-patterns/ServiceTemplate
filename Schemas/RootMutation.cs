
using Business;
using Entities;
using GraphQL.Types;
using Schemas.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas
{
    public class RootMutation: ObjectGraphType
    {
        public RootMutation(ServiceLocator serviceLocator)
        {
            Field<ApplicationType>("newApplication", description: "Something", 
                arguments: new QueryArguments(),
                resolve: ctx => {
                    var application = new Application();
                    ServiceLocator.DataContext.Applications.Add(application);
                    ServiceLocator.DataContext.SaveChanges();
                    return application;
                });
        }
    }
}
