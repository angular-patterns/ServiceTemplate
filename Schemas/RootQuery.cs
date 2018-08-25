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
