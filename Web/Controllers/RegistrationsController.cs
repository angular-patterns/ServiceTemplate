using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Post([FromBody] NewUser newUser)
        {
            Context.Users.Add(new Entities.User()
            {
                Account = new Entities.Account()
                {
                    Username = newUser.Username,
                    Password = newUser.Password
                }
            });
            Context.SaveChanges();
        }
    }
}
