using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicRules.Core;
using DynamicRules.Interfaces;
using Entities;
using Newtonsoft.Json;

namespace Business
{
    public class ReviewRunner 
    {
        public RuleSetService RuleSetService { get; }
        public IJsonValidator JsonValidator { get; }
        public IJsonSchemaParser JsonSchemaParser { get; }
        public IRuleEvaluator RuleEvaluator { get; }

        public ReviewRunner(RuleSetService ruleSetService, IJsonValidator jsonValidator, IJsonSchemaParser jsonSchemaParser, IRuleEvaluator ruleEvaluator)
        {
            RuleSetService = ruleSetService;
            JsonValidator = jsonValidator;
            JsonSchemaParser = jsonSchemaParser;
            RuleEvaluator = ruleEvaluator;
        }


        public ReviewResult Run(JsonSchemaInfo schema,  int ruleSetId, string jsonValue)
        {
            var reviewContextService = ServiceLocator.Instance.GetService<ReviewContextService>();
            var reviewContext = reviewContextService.GetReviewContext(ruleSetId);
            var reviewTypes = RuleSetService.GetReviewTypes(ruleSetId);
            var schemaResult = JsonValidator.Validate(schema.Schema, jsonValue).Result;
            var reviewResult = new ReviewResult()
            {
                Success = schemaResult.Success,
                Rules = new List<ReviewRule>(),
                SchemaErrors = schemaResult.Errors
            };
            if (schemaResult.Success)
            {
                var modelObj = JsonConvert.DeserializeObject(jsonValue, schema.ModelType, new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                    NullValueHandling = NullValueHandling.Include
                });

                reviewResult.Rules = reviewTypes.ToList().Select(t =>
                {

                    var reviewContextItems = reviewContextService.CreateContext(reviewContext.ContextItems);
                    reviewContextItems.Add(schema.ModelType.Name,  new KeyValuePair<Type,Object>(schema.ModelType, modelObj));
                    
                    var result = RuleEvaluator.RunPredicate(reviewContextItems, t.Logic);
                    return new ReviewRule()
                    {
                        ReviewRuleTypeId = t.ReviewRuleTypeId,
                        BusinessId = t.BusinessId,
                        Message = t.Message,
                        IsSatisfied = result

                    };
                }).ToList();
                reviewResult.Success = true;
            }
            return reviewResult;
        }
    }
}
