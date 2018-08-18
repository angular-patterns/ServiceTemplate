using Autofac;
using Endpoints.Api.Core;
using Endpoints.Api.Gateway.Registration;
using System;

namespace Container
{
    public class AutofacModule: Module
    {
        public AutofacModule()
        {
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegistrationEndpoint>();

            EndpointFactory.Register(builder, t=>
            {
                return new IEndpoint[]
                {
                    t.Resolve<RegistrationEndpoint>()
                };
            });
        }
    }
}
