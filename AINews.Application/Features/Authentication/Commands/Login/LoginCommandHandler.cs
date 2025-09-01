using AINews.Application.Contracts;
using AINews.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Authentication.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUserService _userService;
        public LoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var (user, token) = await _userService.AuthenticateAsync(request.Email, request.Password);

            if (user == null || token == null)
            {
                return new LoginCommandResponse
                {
                    Success = false,
                    Message = "Invalid email or password"
                };
            }

            // Update last login
            await _userService.UpdateLastLoginAsync(user.Id);

            return new LoginCommandResponse
            {
                Success = true,
                Message = "Login successful",
                Token = token,
                User = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                }
            };
        }
    }
}
