using NServiceBus;
using System;

namespace Registration
{
    public class RegistrationEndpoint
    {
        public  IEndpointInstance Instance { get; set; }
        public IEndpointInstance Create()
        {
            var endpointConfiguration = new EndpointConfiguration("Registration");

            endpointConfiguration.UsePersistence<LearningPersistence>();
            endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.EnableCallbacks();
            endpointConfiguration.MakeInstanceUniquelyAddressable("Registration");
            var endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
            this.Instance = endpoint;
            return endpoint;



        }
    }
}
