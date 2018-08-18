using Autofac;
using Data;
using Entities;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;


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

            builder.RegisterType<MyQuery>().As<IObjectGraphType>();
            builder.RegisterType<MySchema>().As<ISchema>();

            builder.RegisterType<DocumentExecuter>().As<IDocumentExecuter>();
        }
    }

    public class MySchema : Schema

    {
        public MySchema()
        {

        }

    }


    public class AccountType : ObjectGraphType<Account>

    {

        public AccountType()

        {

            Name = "Account";



            Field(d => d.AccountId).Description("The id of the character.");

            Field(d => d.Username, nullable: true).Description("The name of the character.");
            Field(d => d.Password, nullable: true).Description("The name of the character.");
            Field(d => d.CreatedBy, nullable: true).Description("The name of the character.");
            Field(d => d.CreatedOn, nullable: false).Description("The name of the character.");
            Field<AccountType>(
  "account",

  arguments: new QueryArguments(
      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "id of the human" }
  ),
  resolve: context =>
  {
      var id = context.GetArgument<int>("id");
                   return new Account() { AccountId = 1, Username = "blah" };
                  //return c.Accounts.Find(context.GetArgument<int>("id"));
  }//c.Accounts.Find(context.GetArgument<int>("id"))
);


        }

    }


    public class MyQuery : ObjectGraphType
    {
        public MyQuery(DataContext c)
        {
           
            Field<AccountType>(
              "account",

              arguments: new QueryArguments(
                  new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "id of the human" }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument<int>("id");
                  // return new Account() { AccountId = 1, Username = "blah" };
                  return c.Accounts.Find(context.GetArgument<int>("id"));
              }//c.Accounts.Find(context.GetArgument<int>("id"))
            );
        }
    }

}








