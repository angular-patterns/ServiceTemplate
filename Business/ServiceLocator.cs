using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance 
            {
                get; set;
            }
        public IServiceProvider Provider { get; }
        public ServiceLocator(IServiceProvider provider)
        {
            Provider = provider;
            Instance = this;
        }


        public T GetService<T>()
        {
            return (T)Provider.GetService(typeof(T));
        }
    }
}
