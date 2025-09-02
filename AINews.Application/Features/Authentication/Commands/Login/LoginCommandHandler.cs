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
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResultDto>
    {
        private readonly IIdentityService _identity;
        private readonly IJwtTokenGenerator _jwt;
        public LoginCommandHandler(IIdentityService identity, IJwtTokenGenerator jwt)
        {
            _identity = identity;
            _jwt = jwt;
        }

        public async Task<AuthResultDto> Handle(LoginCommand request, CancellationToken ct)
        {
            var (success, userId, email, userName, errors) =
                await _identity.LoginAsync(request.Email, request.Password);

            if (!success)
                throw new Exception(string.Join(", ", errors));

            return _jwt.Generate(userId, email, userName);
        }
    }
}
