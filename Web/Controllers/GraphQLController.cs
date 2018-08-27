using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using GraphQL;

using GraphQL.Types;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using Schemas;
using Web.Models;

namespace Web.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private RootSchema Schema;
        public GraphQLController(RootSchema schema)
        {
            Schema = schema;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query, ClaimsPrincipal user)
        {

            var result = await Schema.ExecuteQuery(query, user);

            if (result.Errors?.Count > 0)
            {
                foreach (var error in result.Errors)
                {
                      
                }
                
                var errors = new
                {
                    errors = result.Errors,
                    innerErrors = result.Errors.Where(t=>t.InnerException != null).Select(t => t.InnerException).ToList()
                    
                };
                return Ok(errors);
            }

            

            return Ok(result);
        }
    }
}
