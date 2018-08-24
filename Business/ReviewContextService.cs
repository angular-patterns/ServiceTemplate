using Data;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class ReviewContextService
    {

        public DataContext DataContext { get; }

        public ReviewContextService(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public ReviewContext PublishContext(int contextId)
        {
            var context = DataContext.Contexts.Find(contextId);
            var contextItems = DataContext.ContextItems.Where(t => t.ContextId == contextId);

            var reviewContexts = DataContext.ReviewContexts.Where(t => t.ContextId == contextId);

            reviewContexts.ToList().ForEach(t =>
            {
                t.IsActive = false;
            });

            var reviewContext = new ReviewContext()
            {
                ContextId = context.ContextId,
                CreatedOn = DateTime.Now,
                IsActive = true,
            };

            var reviewContextItems = contextItems.ToList().Select(t =>
            {
                return new ReviewContextItem()
                {
                    ReviewContextId = reviewContext.ReviewContextId,
                    ModelId = t.ModelId,
                    JsonValue = t.JsonValue
                };
            }).ToList();

            reviewContext.ContextItems = reviewContextItems;
            DataContext.ReviewContexts.Add(reviewContext);
            DataContext.SaveChanges();
            return reviewContext;

        }

        public ReviewContext GetReviewContext(int ruleSetId)
        {
            var ruleSet = DataContext.RuleSets.Find(ruleSetId);
            var reviewContext = DataContext.ReviewContexts.Where(t => t.ContextId == ruleSet.ContextId).FirstOrDefault();

            return reviewContext;

        }

        public IDictionary<Type, Object> CreateContext(IList<ReviewContextItem> contextItems)
        {
            var dictionary = new Dictionary<Type, Object>();
            var jsonSchemaService = ServiceLocator.Instance.GetService<JsonSchemaService>();
            foreach (var item in contextItems)
            {
                var schemaInfo = jsonSchemaService.GetSchemaInfo(item.ModelId);
                var obj = JsonConvert.DeserializeObject(item.JsonValue, schemaInfo.ModelType);
                dictionary.Add(schemaInfo.ModelType, obj);

            }
            return dictionary;
        }

        public IList<ReviewContextItem> GetContextItems(int reviewContextId)
        {
            return DataContext.ReviewContextItems.Where(t => t.ReviewContextId == reviewContextId).ToList();
        }

        public ReviewContext GetById(int reviewContextId)
        {
            return DataContext.ReviewContexts.Find(reviewContextId);
        }

        public IList<ReviewContext> GetAll()
        {
            return DataContext.ReviewContexts.ToList();
        }
    }
}
