using System;

using System.Threading.Tasks;

using GraphQL;

using GraphQL.Types;

using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private ISchema Schema;
        private IObjectGraphType Query;
        public GraphQLController(ISchema schema, IObjectGraphType query)
        {
            Schema = schema;
            Query = query;
            Schema.Query = Query;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = Schema;
                _.Query = query.Query;

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                //Console.WriteLine(result.Errors.AsDictionary()
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
