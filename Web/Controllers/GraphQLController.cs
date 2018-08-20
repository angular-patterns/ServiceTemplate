using System;

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
    [Produces("application/json")]
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private RootSchema Schema;
        public GraphQLController(RootSchema schema)
        {
            Schema = schema;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {

            var result = await Schema.ExecuteQuery(query, User);

            if (result.Errors?.Count > 0)
            {
                //Console.WriteLine(result.Errors.AsDictionary()
                //return BadRequest();
            }

            return Ok(result);
        }
    }
}
