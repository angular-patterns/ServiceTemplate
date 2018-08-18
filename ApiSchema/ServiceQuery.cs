using Business.Queries.Accounts;
using Data;

using Entities;
using GraphQL.Types;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiSchema
{
    public class ServiceQuery : ObjectGraphType
    {
        public ServiceQuery(FilterAccountsQuery query)
        {
            Field<ListGraphType<AccountType>>(
                "accounts",
                description: "Retrieves all accounts with option to filter.",
                arguments: new QueryArguments(new QueryArgument<InputAccountType>() { Name = "where" }),
                resolve: ctx =>
                {
                    var criteria = ctx.GetArgument<FilterCriteria>("where");
                    return query.FilterBy(criteria);
                });
            Field<AccountType>(
                "account",
                description: "Retrieve a single account",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "id of the human" }
                ),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return query.FindById(id);
                });
        }

     
    }

    public class InputAccountType: InputObjectGraphType<FilterCriteria>
    {

        public InputAccountType()
        {
            Field(d => d.Username, nullable: true).Description("The name of the character.");
            Field(d => d.Password, nullable: true).Description("The name of the character.");
         
        }
    }

    public class AccountType : ObjectGraphType<Account>

    {

        public AccountType()

        {
            Name = "Account";
            Field(d => d.AccountId, nullable: true).Description("The id of the character.");
            Field(d => d.Username, nullable: true).Description("The name of the character.");
            Field(d => d.Password, nullable: true).Description("The name of the character.");
            Field(d => d.CreatedBy, nullable: true).Description("The name of the character.");
            Field(d => d.CreatedOn, nullable: true).Description("The name of the character.");



        }

    }

}
