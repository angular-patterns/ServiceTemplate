using Business;
using DynamicRules.Common.Compilation;
using GraphQL.Types;
using Models;
using Schemas.Models;
using Schemas.Types;
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
            Field<ReviewContextType>("createReviewContext",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "contextId" }
                ),
                resolve: ctx =>
                {
                    var contextId = ctx.GetArgument<int>("contextId");
                     return ServiceLocator.ReviewContextService.PublishContext(contextId);
                });

            Field<ContextType>("createContext",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "name" }
                ),
                resolve: ctx =>
                {
                    var name = ctx.GetArgument<string>("name");
                    return ServiceLocator.ContextService.Create(name);
                });
            Field<ContextItemType>("addContextItem",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() {  Name="contextId"},
                    new QueryArgument<StringGraphType>() { Name = "key"},
                    new QueryArgument<StringGraphType>() { Name = "json" },
                    new QueryArgument<IntGraphType>() {  Name="modelId"}
                ),
                resolve: ctx =>
                {
                    var contextId = ctx.GetArgument<int>("contextId");
                    var key = ctx.GetArgument<string>("key");
                    var json = ctx.GetArgument<string>("json");
                    var modelId = ctx.GetArgument<int>("modelId");

                    return ServiceLocator.ContextService.AddContextItem(contextId, modelId, key, json);

                    
                });
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
                        var model = ServiceLocator.ModelService.AddModelFromCSharpSource(
                            csharp.AccountId,
                            csharp.CSharpSource,
                            csharp.TypeName);
                        if (model.Status == System.Threading.Tasks.TaskStatus.Faulted)
                        {
                            foreach(var exception in model.Exception.InnerExceptions)
                            {
                                var error = new GraphQL.ExecutionError(exception.Message, exception);
                                error.Data.Add("StackTrace", exception.StackTrace);
                                if (exception is CompilerException)
                                {
                                    var e = (CompilerException)exception;
                                    error.Data.Add("Errors", e.Errors);
                                }
                                ctx.Errors.Add(error);
                            }
                            return null;
                            
                        }
                        return model;
                    }

                    var jsonSchema = ctx.GetArgument<FromJsonSchema>("fromJsonSchema");
                    if (jsonSchema != null)
                    {
                        var model = ServiceLocator.ModelService.AddModelFromJsonSchema(
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
                    new QueryArgument<IntGraphType>() {  Name="contextId"},
                    new QueryArgument<IntGraphType>() { Name = "modelId" },
                    new QueryArgument<StringGraphType>() { Name = "title" },
                    new QueryArgument<StringGraphType>() { Name = "businessId" }
                 ),
                resolve: ctx =>
                {
                    var contextId = ctx.GetArgument<int>("contextId");
                    var modelId = ctx.GetArgument<int>("modelId");
                    var name = ctx.GetArgument<string>("title");
                    var businessId = ctx.GetArgument<string>("businessId");
                    try
                    {
                        return ServiceLocator.RuleSetService.CreateNew(contextId, modelId, name, businessId);
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                    
                });

            Field<ReviewRuleTypeType>(
                name: "addReviewRuleType",
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
              
                    return ServiceLocator.RuleSetService.AddReviewType(
                        ruleSetId,
                        businessId, 
                        message, 
                        logic);
                });

            Field<Types.ReviewType>(
                name: "runReviews",
                arguments: new QueryArguments(
                    new QueryArgument<InputWithRuleSet>() { Name = "withRuleSet" },
                    new QueryArgument<InputForModel>() { Name = "forModel" }
                 ),
                resolve: (ResolveFieldContext<object> ctx) =>
                {

                    var withRuleSet = ctx.GetArgument<WithRuleSet>("withRuleSet");
                    var forModel = ctx.GetArgument<ForModel>("forModel");
                    var ruleSetId = ServiceLocator.RuleSetService
                        .ResolveRuleSet(withRuleSet.BusinessId, withRuleSet.Id).RuleSetId;

                    return ServiceLocator.ReviewService.Run(ruleSetId, new BusinessModel {
                        Json = forModel.Json, 
                        BusinessId = forModel.BusinessId,
                        VersionNumber = forModel.VersionNumber, 
                        RevisionNumber = forModel.RevisionNumber
                    });
                });




        }
    }
}
