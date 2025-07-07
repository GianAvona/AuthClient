using MediatR;
using Microsoft.AspNetCore.Mvc;
using AuthClient.Application.Commands;

namespace AuthClient.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// POST /api/auth/register
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterClientCommand cmd)
        {
            await _mediator.Send(cmd);
            return CreatedAtAction(nameof(Register), null);
        }

        /// <summary>
        /// POST /api/auth/login
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginClientQuery qry)
        {
            var token = await _mediator.Send(qry);
            return Ok(new { access_token = token });
        }
    }
}
