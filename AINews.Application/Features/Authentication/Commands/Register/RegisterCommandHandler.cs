using AINews.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
    {
        private readonly IUserService _userService;

        public RegisterCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var createUserDto = new CreateUserDto
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Password = request.Password
                };

                var (domainUser, token) = await _userService.CreateUserAsync(createUserDto);

                return new RegisterCommandResponse
                {
                    Success = true,
                    Message = "User registered successfully",
                    Token = token
                };
            }
            catch (InvalidOperationException ex)
            {
                return new RegisterCommandResponse
                {
                    Success = false,
                    Message = "Registration failed",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }

}
