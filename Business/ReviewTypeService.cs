using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ReviewTypeService
    {
        public ServiceLocator ServiceLocator { get; }
        public DataContext DataContext { get; }

        public ReviewTypeService(ServiceLocator serviceLocator, DataContext dataContext)
        {
            ServiceLocator = serviceLocator;
            DataContext = dataContext;
        }

        public ReviewType GetById(int id)
        {
            return DataContext.ReviewTypes.Find(id);
        }
    }
}
