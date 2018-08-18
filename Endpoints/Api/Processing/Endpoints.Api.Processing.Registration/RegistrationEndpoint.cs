﻿
using Endpoints.Api.Core;
using NServiceBus;
using System;

namespace Endpoints.Api.Processing.Registration
{
    public class RegistrationEndpoint: IEndpoint
    {
        public  IEndpointInstance Instance { get; set; }

        public string Name {
            get
            {
                return "Endpoints.Api.Processing.Registration";
            }
        }
        public void Init()
        {
            var endpointConfiguration = new EndpointConfiguration(Name);

            endpointConfiguration.UsePersistence<LearningPersistence>();
            endpointConfiguration.UseTransport<LearningTransport>();
            var endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
            this.Instance = endpoint;
            


        }
    }
}
