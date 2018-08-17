using Autofac;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Container
{
    public class AutofacModule: Module
    {
        public DbContextOptions<DataContext> Options { get; }

        public AutofacModule(DbContextOptions<DataContext> options)
        {
            Options = options;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new DataContext(Options));

        }
    }
}
