using Business;
using DynamicRules.Interfaces;
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

        public class InputWithRuleSet: InputObjectGraphType<WithRuleSet> {
            public InputWithRuleSet()
            {
                Field(t => t.Id, nullable: true).Description("The rule set id");
                Field(t => t.BusinessId, nullable: true).Description("The rule set code");
            }
        }

        public class InputForModel : InputObjectGraphType<ForModel>
        {
            public InputForModel()
            {
                Field(t => t.Json, nullable: false).Description("The model json");
                Field(t => t.BusinessId, nullable: false).Description("The business Id");
                Field(t => t.VersionNumber, nullable: true).Description("The version number");
                Field(t => t.RevisionNumber, nullable: true).Description("The reversion number");
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
                    new QueryArgument<StringGraphType>() { Name = "title" },
                    new QueryArgument<StringGraphType>() { Name = "businessId" }
                 ),
                resolve: ctx =>
                {
                    var modelId = ctx.GetArgument<int>("modelId");
                    var name = ctx.GetArgument<string>("title");
                    var businessId = ctx.GetArgument<string>("businessId");
                    return ServiceLocator.Instance.GetService<RuleSetService>().CreateNew(modelId, name, businessId);
                });

            Field<ReviewTypeType>(
                name: "addReviewType",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "ruleSetId" },
                    new QueryArgument<StringGraphType>() { Name = "businessId" },
                    new QueryArgument<StringGraphType>() { Name = "message" },
                    new QueryArgument<StringGraphType>() { Name = "logic" }
                 ),
                resolve: ctx =>
                {
                    var ruleSetId = ctx.GetArgument<int>("ruleSetId");
                    var businessId = ctx.GetArgument<string>("businessId");
                    var message = ctx.GetArgument<string>("message");
                    var logic = ctx.GetArgument<string>("logic");
              
                    return ServiceLocator.Instance.GetService<RuleSetService>().AddReviewType(
                        ruleSetId,
                        businessId, 
                        message, 
                        logic);
                });

            Field<ReviewModelType>(
                name: "runReviews",
                arguments: new QueryArguments(
                    new QueryArgument<InputWithRuleSet>() { Name = "withRuleSet" },
                    new QueryArgument<InputForModel>() { Name = "forModel" }
                 ),
                resolve: ctx =>
                {

                    var withRuleSet = ctx.GetArgument<WithRuleSet>("withRuleSet");
                    var forModel = ctx.GetArgument<ForModel>("forModel");
                    var ruleSetId = ServiceLocator.Instance.GetService<RuleSetService>()
                        .ResolveRuleSet(withRuleSet.BusinessId, withRuleSet.Id).RuleSetId;

                    return ServiceLocator.Instance.GetService<ReviewService>().Run(ruleSetId, forModel);
                });


        }
    }
}
