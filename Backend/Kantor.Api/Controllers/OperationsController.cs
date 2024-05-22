using Kantor.Core.CQRS.Command.Operation;
using Kantor.Core.CQRS.Query.Operation;
using Kantor.Shared.Settings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kantor.Api.Controllers
{
    [Authorize(Policy = Settings.Policy.LoggedClient)]
    [ApiController]
    [Route("[controller]")]
    public class OperationsController : BaseController
    {
        private readonly IMediator _mediator;

        public OperationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("currency")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GetCurrenciesQuery.Result> GetCurrencies()
            => await _mediator.Send(new GetCurrenciesQuery());

        [HttpPost]
        [Route("resources")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> AddResources([FromBody] AddResourcesCommand command)
        {
            command.SetId(_id);
            await _mediator.Send(command);
            return Accepted();
        }

        [HttpPost]
        [Route("exchange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Exchange([FromBody] ExchangeCommand command)
        {
            command.SetId(_id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
