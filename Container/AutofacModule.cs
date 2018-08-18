using ApiSchema;
using Autofac;
using Business.Mutations.Accounts;
using Business.Queries.Accounts;
using Data;
using Entities;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Container
{

    public class AutofacModule : Module
    {
        public DbContextOptions<DataContext> Options { get; }

        public AutofacModule(DbContextOptions<DataContext> options)
        {
            Options = options;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new DataContext(Options));
            builder.RegisterType<DocumentExecuter>().As<IDocumentExecuter>();
            builder.RegisterType<ServiceSchema>().As<ISchema>();
            builder.RegisterType<ServiceQuery>().As<IObjectGraphType>();
            builder.RegisterType<ServiceMutation>();
            builder.RegisterType<FilterAccountsQuery>();
            builder.RegisterType<CreateAccountMutation>();
        }
    }





}








