using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ReviewRuleTypeService
    {
        public ServiceLocator ServiceLocator { get; }
        public DataContext DataContext { get; }

        public ReviewRuleTypeService(ServiceLocator serviceLocator, DataContext dataContext)
        {
            ServiceLocator = serviceLocator;
            DataContext = dataContext;
        }

        public ReviewRuleType GetById(int id)
        {
            return DataContext.ReviewRuleTypes.Find(id);
        }
    }
}
