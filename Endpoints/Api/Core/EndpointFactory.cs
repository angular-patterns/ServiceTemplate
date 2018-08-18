using Autofac;
using Autofac.Core;
using Autofac.Features.AttributeFilters;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Endpoints.Api.Core
{
    public class EndpointFactory : IEndpointFactory
    {
        private IList<IEndpoint> Endpoints { get; }
        public EndpointFactory()
        {
            this.Endpoints = new List<IEndpoint>();
        }

        public void Register(IEndpoint endpoint)
        {
            this.Endpoints.Add(endpoint);
        }

        public IEndpointInstance Get(string name)
        {
            return this.Endpoints.First(t => t.Name == name).Instance;
        }

        public void Init()
        {
            foreach (var endpoint in this.Endpoints)
            {
                endpoint.Init();
            }
        }
        public static void Register(ContainerBuilder builder, Func<IComponentContext, IEndpoint[]> endpoints)
        {
            builder.RegisterType<EndpointFactory>().As<IEndpointFactory>().OnActivated(t=>
            {
                var factory = (t.Instance as EndpointFactory);
                foreach (var endpoint in endpoints(t.Context))
                {
                    factory.Register(endpoint);
                }
                factory.Init();
            });


        }

    }
}
