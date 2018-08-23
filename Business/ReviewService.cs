using Data;
using DynamicRules.Interfaces;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class ReviewService
    {
        public ServiceLocator ServiceLocator { get; }
        public DataContext DataContext { get; }

        public ReviewService(ServiceLocator serviceLocator, DataContext dataContext)
        {
            ServiceLocator = serviceLocator;
            DataContext = dataContext;
        }

        public Review Run(int ruleSetId, string value)
        {
            var schemaValidator = ServiceLocator.Instance.GetService<IJsonValidator>();
            var ruleSet = ServiceLocator.Instance.GetService<RuleSetService>().GetById(ruleSetId);
            var model = ServiceLocator.Instance.GetService<ModelService>().GetById(ruleSet.ModelId);
            var results = schemaValidator.Validate(model.JsonSchema, value).Result;
            if (!results.Success)
            {
                throw new Exception("Failed schema validation" + JsonConvert.SerializeObject(results.Errors));
            }
            else
            {
                var schemaParser = ServiceLocator.Instance.GetService<IJsonSchemaParser>();
                var schemaInfo = schemaParser.FromSchema(model.JsonSchema, model.TypeName, model.Namespace).Result;
                var ruleEvaluator = ServiceLocator.Instance.GetService<IRuleEvaluator>();
                var review = new Review()
                {
                    RuleSetId = ruleSetId,
                    CreatedOn = DateTime.Now,
                    JsonValue = value
                };
                var modelObj = JsonConvert.DeserializeObject(value, schemaInfo.ModelType);

                review.Rules = ruleSet.ReviewTypes.ToList().Select(t =>
                {
                    var result = ruleEvaluator.RunPredicate(schemaInfo.ModelType, modelObj, t.Logic);
                    return new ReviewRule()
                    {
                        RuleSetId = t.RuleSetId,
                        ReviewTypeId = t.ReviewTypeId,
                        BusinessId = t.BusinessId,
                        Message = t.Message,
                        IsSatisfied = result

                    };
                }).ToList();

                DataContext.Reviews.Add(review);
                DataContext.SaveChanges();

                return review;
            }
        }

        public Review GetById(int reviewId)
        {
            return DataContext.Reviews.Find(reviewId);
        }
    }
}
