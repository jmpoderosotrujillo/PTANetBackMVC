using Microsoft.AspNetCore.Mvc;
using PTA.BL.Clients;
using PTA.BL.Contracts;
using PTA.BL.Dtos;
using PTA.BL.Services;
using PTA.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace PTA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MarketPartiesController(IEsettHttpClient esettHttpClient) : ControllerBase
    {
        private readonly IEsettHttpClient _esettHttpClient = esettHttpClient;

        [HttpGet("GetExternalDistributionSystemOperators"), SwaggerOperation(
            Summary = "Get a list with all Distribution System Operators from Esett API",
            Description = "Get a list with all Distribution System Operators",
            OperationId = "GetExternalDistributionSystemOperators",
            Tags = ["MarketParties"])]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<DistributionSystemOperatorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetExternalDistributionSystemOperators()
        {
            var distributionSystemOperators = await _esettHttpClient.GetDistributionSystemOperatorsAsync();

            return distributionSystemOperators is null ? NotFound() : Ok(distributionSystemOperators);
        }
    }
}