
using Business;
using Data;
using Entities;
using GraphQL.Types;
using Models;
using Schemas.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schemas
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(ServiceLocator serviceLocator)
        {
            Field<ListGraphType<ApplicationType>>("applications",description:"Something", resolve: ctx => {
                return ServiceLocator.DataContext.Applications.ToList();
            });
            
        }

    }



}
