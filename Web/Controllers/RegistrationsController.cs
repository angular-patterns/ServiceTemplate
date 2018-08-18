using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using Endpoints.Api.Core;
using Endpoints.Messaging.Registration.Commands;
using Endpoints.Messaging.Registration.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;

using Web.Models;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/endpoints/Registrations")]
    public class RegistrationsController : Controller
    {
        private IEndpointFactory endpointFactory;

        public RegistrationsController(IEndpointFactory endpointFactory)
        {
            this.endpointFactory = endpointFactory;
        }

        // POST: api/Registrations
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNewAccount newAccount)
        {
            var sendOptions = new SendOptions();
            sendOptions.SetDestination("Endpoints.Api.Processing.Registration");
            var createdAccount = await endpointFactory.Get("Endpoints.Api.Gateway.Registration").Request<NewAccountCreated>(newAccount, sendOptions);
            return Created($"/api/accounts/{createdAccount.AccountId}", createdAccount);
        }
    }
}
