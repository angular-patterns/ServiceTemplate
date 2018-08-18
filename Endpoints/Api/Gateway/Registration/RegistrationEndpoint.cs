using Endpoints.Api.Core;
using NServiceBus;
using System;

namespace Endpoints.Api.Gateway.Registration
{
    public class RegistrationEndpoint: IEndpoint
    {
        public  IEndpointInstance Instance { get; set; }

        public string Name {
            get
            {
                return "Registration";
            }
        }
        public void Init()
        {
            var endpointConfiguration = new EndpointConfiguration(Name);

            endpointConfiguration.UsePersistence<LearningPersistence>();
            endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.EnableCallbacks();
            endpointConfiguration.MakeInstanceUniquelyAddressable("Registration");
            var endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
            this.Instance = endpoint;
            


        }
    }
}
