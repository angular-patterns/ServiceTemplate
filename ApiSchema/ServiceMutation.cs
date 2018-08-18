﻿using Business.Mutations.Accounts;
using Data;
using Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiSchema
{
    public class ServiceMutation : ObjectGraphType
    {
        public ServiceMutation(CreateAccountMutation createAccount)
        {
            Field<AccountType>("createAccount",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "username", DefaultValue="" }
                    , new QueryArgument<StringGraphType>() { Name = "password", DefaultValue="" }),
                resolve: ctx =>
                {
                    var username = ctx.GetArgument<string>("username");
                    var password = ctx.GetArgument<string>("password");
                    var account = createAccount.Create(username, password);
                    return account;
                });
        }
    }
}
