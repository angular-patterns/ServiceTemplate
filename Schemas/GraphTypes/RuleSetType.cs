using Business;
using Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.GraphTypes
{
    public class RuleSetType : ObjectGraphType<RuleSet>
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

}
