using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetAll.Models;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeGetById.Models;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeStockUpdate.Models;
using InvestmentFixedIncome.Register.Application.Feature.FixedIncomeTaxUpdate.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("register")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> FixedIncomeGetAllAsync(
            CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new FixedIncomeGetAllInput(), cancellationToken));
        }

        [HttpGet("{fixedIncomeId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> FixedIncomeGetByIdAsync(
            [FromRoute] int fixedIncomeId,
            CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new FixedIncomeGetByIdInput(fixedIncomeId), cancellationToken));
        }


        [HttpPatch]
        [Route("tax/{fixedIncomeId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> FixedIncomeTaxUpdateAsync(
            int fixedIncomeId,
            [FromBody] FixedIncomeTaxUpdateInput request,
            CancellationToken cancellationToken)
        {
            request.SetFixedIncomeId(fixedIncomeId);

            if (!request.Isvalid)
            {
                return BadRequest();
            }
            var command = await _mediator.Send(request, cancellationToken);
            if (!command)
            {
                return StatusCode(500);
            }
            return StatusCode(200);
        }

        [HttpPatch]
        [Route("stock/{fixedIncomeId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> FixedIncomeStockUpdateAsync(
            int fixedIncomeId,
            [FromBody] FixedIncomeStockUpdateInput request,
            CancellationToken cancellationToken)
        {
            request.SetFixedIncomeId(fixedIncomeId);

            if (!request.Isvalid)
            {
                return BadRequest();
            }
            var command = await _mediator.Send(request, cancellationToken);
            if (!command)
            {
                return StatusCode(500);
            }
            return StatusCode(200);
        }
    }
}
