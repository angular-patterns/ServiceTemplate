using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Business.Services;
using Data;
using Microsoft.EntityFrameworkCore;
using Schemas;

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
            builder.RegisterType<DataContext>().OnPreparing(t => { t.Parameters = new List<Parameter>() { new NamedParameter("options", Options) }; }).InstancePerDependency();
            builder.RegisterType<RootSchema>();
            builder.RegisterType<RootQuery>();
            builder.RegisterType<RootMutation>();

            builder.RegisterType<ReviewViewService>();
            builder.RegisterType<ServiceLocator>();
        }
    }





}








