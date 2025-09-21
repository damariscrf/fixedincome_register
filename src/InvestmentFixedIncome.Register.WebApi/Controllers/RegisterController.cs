using InvestmentFixedIncome.Register.Application.Feature.GetAllFixedIncome.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace InvestmentFixedIncome.Register.WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("investmentfixedincome")]
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
        public async Task<IActionResult> GetAllFixedIncomeAsync(
            CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllFixedIncomeInput(), cancellationToken));
        }
    }
}
