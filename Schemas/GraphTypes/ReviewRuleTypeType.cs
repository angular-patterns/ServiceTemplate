using Business;
using GraphQL.Types;
using Schemas.Resolvers.ForReviewRuleType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.GraphTypes
{
    public class ReviewRuleTypeType : ObjectGraphType<Entities.ReviewRuleType>
    {
        public RuleSetResolver RuleSetResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<RuleSetResolver>();
            }
        }
        public ReviewRuleTypeType()
        {
            Name = "ReviewRuleType";
            Field("id", d => d.ReviewRuleTypeId, nullable: true);
            Field(d => d.RuleSetId, nullable: true);
            Field(d => d.Logic, nullable: true);
            Field(d => d.Message, nullable: true);
            Field(d => d.BusinessId, nullable: true);
            RuleSetResolver.AddField("ruleSet", this);

        }
    }
}
