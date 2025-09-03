using AINews.Application.Features.Authentication.Commands.Login;
using AINews.Application.Features.Authentication.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AINews.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command) => Ok(await _mediator.Send(command));

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command) => Ok(await _mediator.Send(command));

    }
}
