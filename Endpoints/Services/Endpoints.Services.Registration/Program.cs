using Endpoints.Api.Processing.Registration;
using System;

namespace Endpoints.Services.Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            var registrationEndpoint = new RegistrationEndpoint();
            registrationEndpoint.Init();

            Console.ReadLine();
        }
    }
}
