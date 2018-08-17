using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using Messages.Messages;
using Messages.Replies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Registration;
using Web.Models;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/endpoints/Registrations")]
    public class RegistrationsController : Controller
    {
        public RegistrationsController()
        {

        }

        // POST: api/Registrations
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNewAccount newAccount)
        {
            var sendOptions = new SendOptions();
            sendOptions.SetDestination("Blue");
            var createdAccount = await Startup.Endpoint.Request<NewAccountCreated>(newAccount, sendOptions);
            return Created($"/api/accounts/{createdAccount.AccountId}", createdAccount);
        }
    }
}
