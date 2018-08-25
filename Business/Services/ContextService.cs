using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class ContextService
    {
  
        public DataContext DataContext { get; }

        public ContextService(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public Context Create(string name)
        {
            var context = new Context()
            {
                Name = name,
                CreatedOn = DateTime.Now
            };
            DataContext.Contexts.Add(context);

            DataContext.SaveChanges();

            return context;
        }

        public ContextItem AddContextItem(int contextId, int modelId, string key, string jsonValue)
        {
            var item = new ContextItem()
            {
                Key = key,
                ContextId = contextId,
                JsonValue = jsonValue,
                ModelId = modelId,
            };

            DataContext.ContextItems.Add(item);

            DataContext.SaveChanges();

            return item;
        }

        public void RemoveContextItem(int contextItemId)
        {
            var item = DataContext.ContextItems.Find(contextItemId);
            if (item != null)
            {
                DataContext.ContextItems.Remove(item);
                DataContext.SaveChanges();
            }

        }

        public IList<ContextItem> GetContextItems(int contextId)
        {
            return DataContext.ContextItems.Where(t => t.ContextId == contextId).ToList();
        }

        public Context GetById(int contextId)
        {
            return DataContext.Contexts.Find(contextId);
        }

        public IList<Context> GetAll()
        {
            return DataContext.Contexts.ToList();
        }
    }
}
