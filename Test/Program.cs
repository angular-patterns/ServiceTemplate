using NServiceBus;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpointConfiguration = new EndpointConfiguration("Blue");

            endpointConfiguration.UsePersistence<LearningPersistence>();
            endpointConfiguration.UseTransport<LearningTransport>();
            //endpointConfiguration.EnableCallbacks();
            //endpointConfiguration.MakeInstanceUniquelyAddressable("Registration");
            var endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
