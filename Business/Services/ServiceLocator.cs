using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class ServiceLocator
    {
        private static IServiceProvider _provider;
        public ServiceLocator(IServiceProvider provider)
        {
            _provider = provider;
        }



        public static T Get<T>()
        {
            return (T) _provider.GetService(typeof(T));
        }


    }
}
