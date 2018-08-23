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

        public Review Run(int ruleSetId, string jsonValue)
        {

            var ruleSet = ServiceLocator.Instance.GetService<RuleSetService>().GetById(ruleSetId);
            var model = ServiceLocator.Instance.GetService<ModelService>().GetById(ruleSet.ModelId);
            var schemaInfo = ServiceLocator.Instance.GetService<JsonSchemaService>().GetSchemaInfo(ruleSet.ModelId);
            var reviewRunner = ServiceLocator.Instance.GetService<ReviewRunner>();
            var reviewResult = reviewRunner.Run(schemaInfo, ruleSetId, jsonValue);

            var review = new Review()
            {
                RuleSetId = ruleSetId,
                CreatedOn = DateTime.Now,
                JsonValue = jsonValue,
                ReviewRules = reviewResult.Rules
            };
            DataContext.Reviews.Add(review);
            DataContext.SaveChanges();

            return review;
        }

        public Review GetById(int reviewId)
        {
            return DataContext.Reviews.Find(reviewId);
        }

        public IList<Review> GetAll()
        {
            return DataContext.Reviews.ToList();
        }

        public IList<Review> GetByRuleSetId(int ruleSetId)
        {
            return DataContext.Reviews.Where(t => t.RuleSetId == ruleSetId).ToList();
        }

        public IList<ReviewRule> GetRules(int reviewId)
        {
            return DataContext.ReviewRules.Where(t => t.ReviewId == reviewId).ToList();
        }
    }
}
