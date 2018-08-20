using System;

using System.Threading.Tasks;

using GraphQL;

using GraphQL.Types;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using Schemas;

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
        [HttpGet]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
          
            var result = await Schema.ExecuteQuery(query, User);

            if (result.Errors?.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong");
              
                //return BadRequest();
            }

            return Ok(result);
        }
    }
}
