using Kantor.Core.DTOs.Auth;
using Kantor.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kantor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthenticationService _service;

        public AuthController(IAuthenticationService service) 
        { 
            _service = service ?? throw new NullReferenceException(nameof(service));
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<TokenDTO> Login([FromBody] LoginDTO data) 
            => await _service.Login(data);
        
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] RegisterDTO data)
        {
            await _service.Register(data);
            return Created();
        }

        [HttpPost]
        [Route("refresh-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<TokenDTO> RefreshToken(string token)
            => await _service.RefreshToken(token);
    }
}
