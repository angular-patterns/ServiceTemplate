using Business.Mutations.RuleSets;
using Business.Queries.RuleSets;
using Data;
using DynamicRules.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
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

        public RuleSet ResolveRuleSet(string businessId, int? ruleSetId)
        {
            IQueryable<RuleSet> ruleSets = DataContext.RuleSets;
            if (ruleSetId != null)
            {
                ruleSets = ruleSets.Where(t => t.RuleSetId == ruleSetId);
            }
            if (businessId != null)
            {
                ruleSets = ruleSets.Where(t=>t.BusinessId == businessId);
            }

            return ruleSets.First();
        }

        public RuleSet CreateNew(int contextId, int modelId, string name, string businessId)
        {
            var ruleSetContextService = ServiceLocator.Instance.GetService<ContextService>();
           
            var ruleSet = CreateRuleSetMutation.Create(new RuleSet()
            {
                ModelId = modelId,
                BusinessId = businessId,
                Title = name,
                ContextId = contextId,
                CreatedOn = DateTime.Now
            });

            return ruleSet;

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

        public ReviewRuleType AddReviewType(int ruleSetId, string businessId, string message, string logic)
        {
            var ruleSet = DataContext.RuleSets.Find(ruleSetId);
            var schemaInfo = ServiceLocator.Instance.GetService<JsonSchemaService>().GetSchemaInfo(ruleSet.ModelId);
            var reviewContextService = ServiceLocator.Instance.GetService<ReviewContextService>();
            var reviewContext = reviewContextService.GetReviewContext(ruleSetId);


            var reviewType = new ReviewRuleType
            {
                RuleSetId = ruleSetId,
                BusinessId = businessId,
                Message = message,
                Logic = logic
            };
            var ruleEvaluator = ServiceLocator.Instance.GetService<IRuleEvaluator>();
            var modelInstance = Activator.CreateInstance(schemaInfo.ModelType);

            var reviewContextItems = reviewContextService.CreateContext(reviewContext.ContextItems);
            reviewContextItems.Add(schemaInfo.ModelType.Name, new KeyValuePair<Type, Object>(schemaInfo.ModelType, modelInstance));

            ruleEvaluator.RunPredicate(reviewContextItems, logic);
            DataContext.ReviewRuleTypes.Add(reviewType);
            DataContext.SaveChanges();
            return reviewType;
        }

        public IList<ReviewRuleType> GetReviewTypes(int ruleSetId)
        {
            return DataContext.ReviewRuleTypes.Where(t => t.RuleSetId == ruleSetId).ToList();
        }
    }
}
