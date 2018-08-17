using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Registrations")]
    public class RegistrationsController : Controller
    {
        public DataContext Context { get; }
        public RegistrationsController(DataContext context)
        {
            this.Context = context;
        }

        // POST: api/Registrations
        [HttpPost]
        public IActionResult Post([FromBody] NewAccount newAccount)
        {
            var account = new Entities.Account()
            {
                Username = newAccount.Username,
                Password = newAccount.Password,
                CreatedBy = "Guest",
                CreatedOn = DateTime.Now
            };
            Context.Accounts.Add(account);
            Context.SaveChanges();
           
            return Created($"/api/accounts/{account.AccountId}", account);
        }
    }
}
