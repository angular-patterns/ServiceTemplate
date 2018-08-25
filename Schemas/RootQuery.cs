using Business;
using Entities;
using GraphQL.Types;
using Models;
using Schemas.GraphTypes;
using Schemas.Resolvers;
using Schemas.Resolvers.ForRoot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas
{
    public class RootQuery : ObjectGraphType
    {

        public RootQuery(ServiceLocator serviceLocator, 
            ModelsResolver modelsResolver,
            RuleSetsResolver ruleSetsResolver,
            ReviewsResolver reviewsResolver, 
            ContextsResolver contextsResolver,
            ReviewContextsResolver reviewContextsResolver)
        {

            modelsResolver.AddField("models", this);
            ruleSetsResolver.AddField("ruleSets", this);
            reviewsResolver.AddField("reviews", this);
            contextsResolver.AddField("contexts", this);
            reviewContextsResolver.AddField("reviewContexts", this);
        }

    }


    public class ReviewContextItemType : ObjectGraphType<ReviewContextItem>
    {
        public ReviewContextItemType()
        {
            Name = "ReviewContextItem";
            Field("id", d => d.ContextItemId, nullable: true).Description("The id of the character.");
            Field(d => d.ReviewContextId, nullable: true).Description("The name of the character.");
            Field(d => d.JsonValue, nullable: true).Description("The name of the character.");
            Field(d => d.Key, nullable: true).Description("The name of the character.");
            Field(d => d.ModelId, nullable: true).Description("The name of the character.");
            Field<ModelType>(
                name: "model",
                resolve: ctx =>
                {
                    var modelId = ctx.Source.ModelId;
                    return ServiceLocator.ModelService.GetById(modelId);
                });
            Field<ReviewContextType>(
                name: "reviewContext",
                resolve: ctx =>
                {
                    var reviewContextId = ctx.Source.ReviewContextId;
                    return ServiceLocator.ReviewContextService.GetById(reviewContextId);
                });

        }
    }



    public class ModelType : ObjectGraphType<Model>
    {

        public ModelType()

        {
            Name = "Model";
            Field("id", d => d.ModelId, nullable: true).Description("The id of the character.");
            //Field(d => d.AccountId, nullable: true).Description("The name of the character.");
            //Field(d => d.CSharpSource, nullable: true).Description("The name of the character.");
            //Field(d => d.JsonSchema, nullable: true).Description("The name of the character.");
            //Field(d => d.TypeName, nullable: true).Description("The name of the character.");
            //Field(d => d.Namespace, nullable: true).Description("The name of the character.");
            //Field<ListGraphType<RuleSetType>>(
            //    name: "ruleSets",
            //    resolve: ctx =>
            //    {
            //        var modelId = ctx.Source.ModelId;
            //        return ServiceLocator.Instance.GetService<RuleSetService>().GetByModelId(modelId);
            //    });

        }
    }
    public class RuleSetType: ObjectGraphType<RuleSet>
    {

        public RuleSetType()
        {
            Name = "RuleSet";
            Field("id", d => d.RuleSetId, nullable: true);
            Field(d => d.ModelId, nullable: true);
            Field(d => d.Title, nullable: true);
            Field(d => d.BusinessId, nullable: true);
            Field(d => d.CreatedOn, nullable: true);
            Field<ModelType>("model",
                resolve: ctx =>
                {
                    
                    return ServiceLocator.ModelService.GetById(ctx.Source.ModelId);
                });
            Field<ListGraphType<ReviewRuleType>>(
                name: "reviewRuleTypes",
                resolve: ctx =>
                {
                    return ServiceLocator.RuleSetService.GetReviewTypes(ctx.Source.RuleSetId);
                });
        }
    }

    public class ReviewRuleTypeType: ObjectGraphType<Entities.ReviewRuleType>
    {
        public ReviewRuleTypeType()
        {
            Name = "ReviewRuleType";
            Field("id", d => d.ReviewRuleTypeId, nullable: true);
            Field(d => d.RuleSetId, nullable: true);
            Field(d => d.Logic, nullable: true);
            Field(d => d.Message, nullable: true);
            Field(d => d.BusinessId, nullable: true);
            Field<RuleSetType>("ruleSet",
                resolve: ctx =>
                {

                    return ServiceLocator.RuleSetService.GetById(ctx.Source.RuleSetId);
                });

        }
    }

    public class ReviewRuleType: ObjectGraphType<ReviewRule>
    {
        public ReviewRuleType()
        {
            Name = "ReviewRule";
            Field("id", d => d.ReviewRuleId, nullable: true);
            Field(d => d.ReviewId, nullable: true);
            Field(d => d.ReviewRuleTypeId, nullable: true);
            Field<ReviewRuleTypeType>(
                name: "reviewRuleType", 
                resolve: ctx =>
                {
                    return ServiceLocator.ReviewRuleTypeService.GetById(ctx.Source.ReviewRuleTypeId);
                });
            Field(d => d.BusinessId, nullable: true);
            Field(d => d.Message, nullable: true);
            Field(d => d.IsSatisfied, nullable: true);



        }
    }

}
