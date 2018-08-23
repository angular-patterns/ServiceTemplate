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
            var schemaInfo = ServiceLocator.Instance.GetService<JsonSchemaService>().GetSchemaInfo(ruleSet.ModelId);

            var reviewType = new ReviewType
            {
                RuleSetId = ruleSetId,
                BusinessId = businessId,
                Message = message,
                Logic = logic
            };
            var ruleEvaluator = ServiceLocator.Instance.GetService<IRuleEvaluator>();
            var modelInstance = Activator.CreateInstance(schemaInfo.ModelType);
            //var jsonModel = JsonConvert.SerializeObject(modelInstance, schemaInfo.ModelType, Formatting.Indented, 
            //    new JsonSerializerSettings
            //    {
            //        ObjectCreationHandling = ObjectCreationHandling.Replace,
            //        ConstructorHandling = ConstructorHandling.Default,
                
            //    });

            ruleEvaluator.RunPredicate(schemaInfo.ModelType,modelInstance, logic);
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
