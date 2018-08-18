
using Endpoints.Messaging.Registration.Commands;
using Endpoints.Messaging.Registration.Messages;
using Newtonsoft.Json;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Api.Processing
{
    public class NewAccountHandler : IHandleMessages<CreateNewAccount>
    {
        static HttpClient client = new HttpClient();
        public Task Handle(CreateNewAccount message, IMessageHandlerContext context)
        {

            Console.WriteLine("Received messages");
            var created = CreateAccountAsync(message).Result;
            return context.Reply(created);
        }


        static async Task<NewAccountCreated> CreateAccountAsync(CreateNewAccount account)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "http://localhost:3697/api/registrations", account);
            response.EnsureSuccessStatusCode();
            string jsonContent = response.Content.ReadAsStringAsync().Result;
            // return URI of the created resource.
            return JsonConvert.DeserializeObject<NewAccountCreated>(jsonContent);
        }
    }
}
