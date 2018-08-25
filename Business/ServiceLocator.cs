using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ServiceLocator
    {
        private IServiceProvider serviceProvider { get; set; }
        public static ServiceLocator Injector
        {
            get; set;
        }

        public static DataContext DataContext {
            get;
            set;
        }

        public ServiceLocator(DataContext dataContext, IServiceProvider serviceProvider)
        {
            Injector = this;
            DataContext = dataContext;
            this.serviceProvider = serviceProvider;
            
        }

        public T Get<T>()
        {
            return (T) serviceProvider.GetService(typeof(T));
        }
    }
}
