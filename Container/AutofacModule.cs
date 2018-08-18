using Autofac;
using Business.Mutations.Accounts;
using Business.Queries.Accounts;
using Data;
using Entities;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Schemas;
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
            builder.RegisterType<RootSchema>();
            builder.RegisterType<RootQuery>();
            builder.RegisterType<RootMutation>();
            builder.RegisterType<FilterAccountsQuery>();
            builder.RegisterType<CreateAccountMutation>();
            builder.RegisterType<DeleteAccountMutation>();
        }
    }





}








