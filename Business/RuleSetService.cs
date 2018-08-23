using Business.Mutations.RuleSets;
using Business.Queries.RuleSets;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class RuleSetService
    {
        public CreateRuleSetMutation CreateRuleSetMutation { get; }
        public RuleSetQuery RuleSetQuery { get; }

        public RuleSetService(CreateRuleSetMutation createRuleSetMutation, RuleSetQuery ruleSetQuery)
        {
            CreateRuleSetMutation = createRuleSetMutation;
            RuleSetQuery = ruleSetQuery;
        }

        public RuleSet CreateNew(int modelId, string name)
        {
            return CreateRuleSetMutation.Create(new RuleSet()
            {
                ModelId = modelId,
                Name = name,
                CreatedOn = DateTime.Now
            });
        }

        public IList<RuleSet> GetByModelId(int modelId)
        {
            return RuleSetQuery.GetByModelId(modelId);
        }

        public IList<RuleSet> GetAll()
        {
            return RuleSetQuery.GetAll();
        }
    }
}
