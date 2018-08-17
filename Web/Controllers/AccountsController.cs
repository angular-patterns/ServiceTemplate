using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
       
        public DataContext Context { get; }
        public AccountsController(DataContext context)
        {
            this.Context = context;
        }
        // GET: api/Accounts
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return Context.Accounts.ToList();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}", Name = "Get")]
        public Account Get(int id)
        {
            return Context.Accounts.Find(id);
        }
        
        // POST: api/Accounts
        [HttpPost]
        public void Post([FromBody]Account value)
        {
            Context.Accounts.Add(value);
            Context.SaveChanges();
            
        }
        
        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Account value)
        {
            Context.Accounts.Update(value);
            Context.SaveChanges();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Context.Accounts.Remove(Get(id));
        }
    }
}
