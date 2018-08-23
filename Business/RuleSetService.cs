using Business.Mutations.RuleSets;
using Business.Queries.RuleSets;
using Data;
using DynamicRules.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class RuleSetService
    {
        public CreateRuleSetMutation CreateRuleSetMutation { get; }
        public RuleSetQuery RuleSetQuery { get; }
        public DataContext DataContext { get; }

        public RuleSetService(CreateRuleSetMutation createRuleSetMutation, RuleSetQuery ruleSetQuery, DataContext dataContext)
        {
            CreateRuleSetMutation = createRuleSetMutation;
            RuleSetQuery = ruleSetQuery;
            DataContext = dataContext;
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

        public RuleSet GetById(int ruleSetId)
        {
            return DataContext.RuleSets.Find(ruleSetId);
        }

        public ReviewType AddReviewType(int ruleSetId, string businessId, string message, string logic)
        {
            var ruleSet = DataContext.RuleSets.Find(ruleSetId);

            var reviewType = new ReviewType
            {
                RuleSetId = ruleSetId,
                BusinessId = businessId,
                Message = message,
                Logic = logic
            };


            var model = ruleSet.Model;
            var schemaParser = ServiceLocator.Instance.GetService<IJsonSchemaParser>();
            var schemaInfo = schemaParser.FromSchema(model.JsonSchema, model.TypeName, model.Namespace).Result;
            var ruleEvaluator = ServiceLocator.Instance.GetService<IRuleEvaluator>();
            ruleEvaluator.RunPredicate(schemaInfo.ModelType, Activator.CreateInstance(schemaInfo.ModelType), logic);
            DataContext.ReviewTypes.Add(reviewType);
            DataContext.SaveChanges();
            return reviewType;
        }

        public IList<ReviewType> GetReviewTypes(int ruleSetId)
        {
            return DataContext.ReviewTypes.Where(t => t.RuleSetId == ruleSetId).ToList();
        }
    }
}
