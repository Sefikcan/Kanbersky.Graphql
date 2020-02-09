using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Kanbersky.Graphql.Business.GraphHelpers;
using Microsoft.AspNetCore.Mvc;

namespace Kanbersky.Graphql.Api.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        #region fields

        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        #endregion

        #region ctor

        public GraphController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        #endregion

        #region methods

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var executionOptions = new ExecutionOptions { Schema = _schema, Query = query.Query };

            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion
    }
}