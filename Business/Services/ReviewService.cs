using Data;
using Entities;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
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

        public Review GetReview(int ruleSetId, string businessId, int versionNumber, int revisionNumber)
        {
            return DataContext.Reviews
                .Where(t=> t.RuleSetId == ruleSetId)
                .Where(t => t.BusinessId == businessId)
                .Where(t => t.VersionNumber == versionNumber)
                .Where(t => t.RevisionNumber == revisionNumber).FirstOrDefault();
        }

        public Review Run(int ruleSetId, BusinessModel forModel)
        {
            forModel.VersionNumber = forModel.VersionNumber ?? 1;
            forModel.RevisionNumber = forModel.RevisionNumber ?? 1;
            var ruleSet = ServiceLocator.Instance.GetService<RuleSetService>().GetById(ruleSetId);
            var model = ServiceLocator.Instance.GetService<ModelService>().GetById(ruleSet.ModelId);
            var schemaInfo = ServiceLocator.Instance.GetService<JsonSchemaService>().GetSchemaInfo(ruleSet.ModelId);
            var reviewRunner = ServiceLocator.Instance.GetService<ReviewRunner>();
            var reviewContext = ServiceLocator.Instance.GetService<ReviewContextService>().GetReviewContext(ruleSetId);
            var review = GetReview(ruleSetId, forModel.BusinessId, forModel.VersionNumber.GetValueOrDefault(), forModel.RevisionNumber.GetValueOrDefault());
            if (review == null)
            {
                review = new Review
                {
                    RuleSetId = ruleSetId,
                    BusinessId = forModel.BusinessId,
                    CreatedOn = DateTime.Now,
                    VersionNumber = forModel.VersionNumber.GetValueOrDefault(),
                    RevisionNumber = forModel.RevisionNumber.GetValueOrDefault(),
                    ReviewContextId = reviewContext.ReviewContextId,
                    ReviewRules = new List<ReviewRule>()
                };
                DataContext.Reviews.Add(review);

            }
            else
            {
                var reviewRules = DataContext.ReviewRules.Where(t => t.ReviewId == review.ReviewId).ToList();
                reviewRules.ForEach(t =>
                {
                    DataContext.ReviewRules.Remove(t);
                });
            }

            review.JsonValue = forModel.Json;



            var reviewResult = reviewRunner.Run(schemaInfo, ruleSetId, forModel.Json);
            if (!reviewResult.Success)
            {
                throw new Exception(reviewResult.SchemaErrors.ToString());
            }
            review.ReviewRules = reviewResult.Rules;

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

        public IList<Review> GetReviewsByBusinessId(string businessId)
        {
            return DataContext.Reviews.Where(t => t.BusinessId == businessId).ToList();
        }
    }
}
