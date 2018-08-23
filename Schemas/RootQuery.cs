using Business;
using Entities;
using GraphQL.Types;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas
{
    public class RootQuery : ObjectGraphType
    {

        public RootQuery(ServiceLocator serviceLocator)
        {
            Field<ListGraphType<ModelType>>(
                name: "models",
                resolve: ctx =>
                {
                    
                    var models = ServiceLocator.Instance.GetService<ModelService>().GetAll();
                    return models;
                });

            Field<ListGraphType<RuleSetType>>(
                name: "ruleSets",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>() { Name= "modelId" }),
                resolve: ctx =>
                {
                    if (ctx.HasArgument("modelId"))
                    {
                        var modelId = ctx.GetArgument<int>("modelId");
                        return ServiceLocator.Instance.GetService<RuleSetService>().GetByModelId(modelId);
                    }
                    else
                    {

                        return ServiceLocator.Instance.GetService<RuleSetService>().GetAll();
                    }
                });
        }

    }



    public class ModelType : ObjectGraphType<Model>
    {

        public ModelType()

        {
            Name = "Model";
            Field("id", d => d.ModelId, nullable: true).Description("The id of the character.");
            Field(d => d.AccountId, nullable: true).Description("The name of the character.");
            Field(d => d.CSharpSource, nullable: true).Description("The name of the character.");
            Field(d => d.JsonSchema, nullable: true).Description("The name of the character.");
            Field(d => d.TypeName, nullable: true).Description("The name of the character.");
            Field(d => d.Namespace, nullable: true).Description("The name of the character.");

        }
    }
    public class RuleSetType: ObjectGraphType<RuleSet>
    {

        public RuleSetType()
        {
            Name = "RuleSet";
            Field("id", d => d.RuleSetId, nullable: true);
            Field(d => d.ModelId, nullable: true);
            Field(d => d.Name, nullable: true);
            Field(d => d.CreatedOn, nullable: true);
            Field<ModelType>("model",
                resolve: ctx =>
                {
                    
                    return ServiceLocator.Instance.GetService<ModelService>().GetById(ctx.Source.ModelId);
                });
        }
    }
}
