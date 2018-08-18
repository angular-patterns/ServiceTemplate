using Business.Mutations.Accounts;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas
{
    public class RootMutation: ObjectGraphType
    {
        public RootMutation(CreateAccountMutation createAccount, DeleteAccountMutation deleteAccount)
        {
            Field<AccountType>("createAccount",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "username", DefaultValue = "" }
                    , new QueryArgument<StringGraphType>() { Name = "password", DefaultValue = "" }),
                resolve: ctx =>
                {
                    var username = ctx.GetArgument<string>("username");
                    var password = ctx.GetArgument<string>("password");
                    var account = createAccount.Create(username, password);
                    return account;
                });

            Field<BooleanGraphType>("deleteAccount",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }
                ),
                resolve: ctx =>
                {
                    var accountId = ctx.GetArgument<int>("id");
                    deleteAccount.Delete(accountId);
                    return true;
                });

        }
    }
}
