using Autofac;
using NServiceBus;
using Registration;
using System;

namespace Container
{
    public class AutofacModule: Module
    {
        public IEndpointInstance Endpoint { get; }
        public AutofacModule(IEndpointInstance endpoint)
        {
            Endpoint = endpoint;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //var endpoint = new RegistrationEndpoint();
            //endpoint.Create();
            //builder.RegisterInstance(endpoint);
           


            

        }
    }
}
