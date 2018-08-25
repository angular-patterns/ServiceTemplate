using Business;
using Entities;
using GraphQL.Types;
using Schemas.Resolvers.ForReview;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.GraphTypes
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public RuleSetResolver RuleSetResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<RuleSetResolver>();
            }
        }
        public ReviewRulesResolver ReviewRulesResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<ReviewRulesResolver>();
            }
        }

        public ReviewContextResolver ReviewContextResolver
        {
            get
            {
                return ServiceLocator.Instance.GetService<ReviewContextResolver>();
            }
        }
        public ReviewType()
        {
            Name = "Review";
            Field("id", d => d.ReviewId, nullable: true);
            Field(d => d.RuleSetId, nullable: true);
            Field(d => d.JsonValue, nullable: true);
            Field(d => d.BusinessId, nullable: true);
            Field(d => d.VersionNumber, nullable: true);
            Field(d => d.RevisionNumber, nullable: true);
            Field(d => d.CreatedOn, nullable: true);
            RuleSetResolver.AddField("ruleSet", this);
            ReviewRulesResolver.AddField("reviewRules", this);
            ReviewContextResolver.AddField("reviewContext", this);

        }
    }

}
