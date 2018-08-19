using Autofac;
using Business.Mutations.Accounts;
using Business.Queries.Products;
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
            builder.RegisterInstance(new DataContext(Options));
            builder.RegisterType<RootSchema>();
            builder.RegisterType<RootQuery>();
            builder.RegisterType<RootMutation>();
            builder.RegisterType<ProductsQuery>();
            builder.RegisterType<CreateProductMutation>();
            builder.RegisterType<DeleteProductMutation>();
        }
    }





}








