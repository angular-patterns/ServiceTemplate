using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicRules.Common;
using DynamicRules.Common.Parser;
using DynamicRules.Core;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Business
{
    public class ReviewRunner 
    {
        public IJsonValidator JsonValidator { get; }
        public IJsonSchemaParser JsonSchemaParser { get; }
        public IRuleEvaluator RuleEvaluator { get; }

        public ReviewRunner(IJsonValidator jsonValidator, IJsonSchemaParser jsonSchemaParser, IRuleEvaluator ruleEvaluator)
        {
            JsonValidator = jsonValidator;
            JsonSchemaParser = jsonSchemaParser;
            RuleEvaluator = ruleEvaluator;
        }


        public ReviewResult Run(JsonSchemaInfo schema,  int ruleSetId, string jsonValue)
        {
            var reviewContext = ServiceLocator.ReviewContextService.GetReviewContext(ruleSetId);
            var reviewTypes = ServiceLocator.RuleSetService.GetReviewTypes(ruleSetId);
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
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                reviewResult.Rules = reviewTypes.ToList().Select(t =>
                {

                    var reviewContextItems = ServiceLocator.ReviewContextService.CreateContext(reviewContext.ContextItems);
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
