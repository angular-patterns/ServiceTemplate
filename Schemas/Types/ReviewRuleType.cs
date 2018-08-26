using Business;
using Entities;
using GraphQL.Types;
using Schemas.Resolvers.ForReviewRule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Types
{
    public class ReviewRuleType : ObjectGraphType<ReviewRule>
    {
        public ReviewRuleTypeResolver ReviewRuleTypeResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<ReviewRuleTypeResolver>();                
            }
        }
        public ReviewRuleType()
        {
            Name = "ReviewRule";
            Field("id", d => d.ReviewRuleId, nullable: true);
            Field(d => d.ReviewId, nullable: true);
            Field(d => d.ReviewRuleTypeId, nullable: true);
            Field(d => d.BusinessId, nullable: true);
            Field(d => d.Message, nullable: true);
            Field(d => d.IsSatisfied, nullable: true);
            ReviewRuleTypeResolver.AddField("reviewRuleType", this);

        }
    }
}
