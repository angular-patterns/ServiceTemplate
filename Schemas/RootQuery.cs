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
                arguments: new QueryArguments(new QueryArgument<IntGraphType>() { Name = "id" }),
                resolve: ctx =>
                {
                    if (ctx.HasArgument("id"))
                    {
                        var modelId = ctx.GetArgument<int>("id");
                        var model = ServiceLocator.Instance.GetService<ModelService>().GetById(modelId);
                        return new List<Model>() { model };
                    }
                    else
                    {
                        var models = ServiceLocator.Instance.GetService<ModelService>().GetAll();
                        return models;
                    }
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
            Field<ListGraphType<ReviewModelType>>(
                name: "reviews",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" },
                    new QueryArgument<IntGraphType>() { Name = "ruleSetId" }
                    ),
                resolve: ctx =>
                {
                    if (ctx.HasArgument("id"))
                    {
                        var reviewId = ctx.GetArgument<int>("id");
                        var review = ServiceLocator.Instance.GetService<ReviewService>().GetById(reviewId);
                        return new List<Review>() { review };
                    }
                    else if (ctx.HasArgument("ruleSetId"))
                    {
                        var ruleSetId = ctx.GetArgument<int>("ruleSetId");
                        return ServiceLocator.Instance.GetService<ReviewService>().GetByRuleSetId(ruleSetId);

                    }
                    else
                    {

                        return ServiceLocator.Instance.GetService<ReviewService>().GetAll();
                    }

                }
                );
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
            Field<ListGraphType<RuleSetType>>(
                name: "ruleSets",
                resolve: ctx =>
                {
                    var modelId = ctx.Source.ModelId;
                    return ServiceLocator.Instance.GetService<RuleSetService>().GetByModelId(modelId);
                });

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
            Field<ListGraphType<ReviewTypeType>>(
                name: "reviewTypes",
                resolve: ctx =>
                {
                    return ServiceLocator.Instance.GetService<RuleSetService>().GetReviewTypes(ctx.Source.RuleSetId);
                });
        }
    }

    public class ReviewTypeType: ObjectGraphType<ReviewType>
    {
        public ReviewTypeType()
        {
            Name = "ReviewType";
            Field("id", d => d.ReviewTypeId, nullable: true);
            Field(d => d.RuleSetId, nullable: true);
            Field(d => d.Logic, nullable: true);
            Field(d => d.Message, nullable: true);
            Field(d => d.BusinessId, nullable: true);
            Field<RuleSetType>("ruleSet",
                resolve: ctx =>
                {

                    return ServiceLocator.Instance.GetService<RuleSetService>().GetById(ctx.Source.RuleSetId);
                });

        }
    }

    public class ReviewRuleType: ObjectGraphType<ReviewRule>
    {
        public ReviewRuleType()
        {
            Name = "ReviewRule";
            Field("id", d => d.ReviewRuleId, nullable: true);
            Field(d => d.ReviewTypeId, nullable: true);
            Field<ReviewTypeType>(
                name: "reviewType", 
                resolve: ctx =>
                {
                    return ServiceLocator.Instance.GetService<ReviewTypeService>().GetById(ctx.Source.ReviewTypeId);
                });
            Field(d => d.BusinessId, nullable: true);
            Field(d => d.Message, nullable: true);
            Field(d => d.RuleSetId, nullable: true);
            Field(d => d.IsSatisfied, nullable: true);
            Field<RuleSetType>("ruleSet",
            resolve: ctx =>
            {

                return ServiceLocator.Instance.GetService<RuleSetService>().GetById(ctx.Source.RuleSetId);
            });



        }
    }

    public class ReviewModelType : ObjectGraphType<Review>
    {
        public ReviewModelType()
        {
            Name = "Review";
            Field("id", d => d.ReviewId, nullable: true);
            Field(d => d.RuleSetId, nullable: true);
            Field<RuleSetType>("ruleSet",
                resolve: ctx =>
                {

                    return ServiceLocator.Instance.GetService<RuleSetService>().GetById(ctx.Source.RuleSetId);
                });
            Field(d => d.JsonValue, nullable: true);
            Field(d => d.CreatedOn, nullable: true);
            Field<ListGraphType<ReviewRuleType>>(
                name: "rules",
                resolve: ctx =>
                {
                    return ServiceLocator.Instance.GetService<ReviewService>().GetById(ctx.Source.ReviewId).Rules;
                });


        }
    }
}
