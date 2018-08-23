﻿using Business;
using Entities;
using GraphQL.Types;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas
{
    public class RootMutation: ObjectGraphType
    {
        public class InputCSharpGraphType: InputObjectGraphType<FromCSharpSource>
        {
            public InputCSharpGraphType()
            {
                Field(t => t.AccountId, nullable: false).Description("The account Id");
                Field(t => t.CSharpSource, nullable: false).Description("The CSharp Source");
                Field(t => t.TypeName, nullable: false).Description("The Type Name");
            }
        }

        public class InputJsonSchemaGraphType : InputObjectGraphType<FromJsonSchema>
        {
            public InputJsonSchemaGraphType()
            {
                Field(t => t.AccountId, nullable: false).Description("The account Id");
                Field(t => t.JsonSchema, nullable: false).Description("The CSharp Source");
                Field(t => t.TypeName, nullable: false).Description("The Type Name");
                Field(t => t.Namespace, nullable: false).Description("The namespace");
            }
        }

        public RootMutation(ServiceLocator serviceLocator)
        {
            Field<ModelType>("createModel",
                arguments: new QueryArguments(
                    new QueryArgument<InputCSharpGraphType>() { Name = "fromCSharp" },
                    new QueryArgument<InputJsonSchemaGraphType>() { Name = "fromJsonSchema" }
                 ),
                resolve: ctx =>
                {
                    var csharp = ctx.GetArgument<FromCSharpSource>("fromCSharp");
                    if (csharp != null)
                    {
                         var model = ServiceLocator.Instance.GetService<ModelService>().AddModelFromCSharpSource(
                             csharp.AccountId, 
                             csharp.CSharpSource, 
                             csharp.TypeName);
                        return model;
                    }

                    var jsonSchema = ctx.GetArgument<FromJsonSchema>("fromJsonSchema");
                    if (jsonSchema != null)
                    {
                        var model = ServiceLocator.Instance.GetService<ModelService>().AddModelFromJsonSchema(
                            jsonSchema.AccountId, 
                            jsonSchema.JsonSchema, 
                            jsonSchema.TypeName, 
                            jsonSchema.Namespace);
                        return model;

                    }
                    return null;
                    
                });

            Field<RuleSetType>(
                name: "createRuleSet",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "modelId" },
                    new QueryArgument<StringGraphType>() { Name = "name" }
                 ),
                resolve: ctx =>
                {
                    var modelId = ctx.GetArgument<int>("modelId");
                    var name = ctx.GetArgument<string>("name");

                    return ServiceLocator.Instance.GetService<RuleSetService>().CreateNew(modelId, name);
                });

        }
    }
}
