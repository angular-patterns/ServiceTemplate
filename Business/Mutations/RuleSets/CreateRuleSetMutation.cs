using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mutations.RuleSets
{
    public class CreateRuleSetMutation: GraphBase
    {
        public CreateRuleSetMutation(DataContext context) : base(context)
        {

        }

        public RuleSet Create(RuleSet ruleSet)
        {
            Context.RuleSets.Add(ruleSet);
            Context.SaveChanges();
            return ruleSet;
        }

    }
}
