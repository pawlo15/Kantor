using Kantor.Core.CQRS.Command.User;
using Kantor.Core.CQRS.Query.User;
using Kantor.Core.DTOs.User;
using Kantor.Shared.Settings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kantor.Api.Controllers
{
    [Authorize(Policy = Settings.Policy.LoggedClient)]
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<UserDetailsDTO> GetDetailsAsync()
            => await _mediator.Send(new GetUserDetailsQuery { Id = _id });

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateUserDetailsCommand command)
        {
            command.SetId(_id);
            await _mediator.Send(command);
            return Ok();
        }

        //[HttpGet]
        //[Route("history")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetHistoryAsync()
        //    => await _mediator.Send();
    }
}
