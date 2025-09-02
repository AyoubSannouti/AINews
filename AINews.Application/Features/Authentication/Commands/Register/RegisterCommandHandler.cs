using AINews.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResultDto>
    {
        private readonly IIdentityService _identity;
        private readonly IJwtTokenGenerator _jwt;

        public RegisterCommandHandler(IIdentityService identity, IJwtTokenGenerator jwt)
        {
            _identity = identity;
            _jwt = jwt;
        }

        public async Task<AuthResultDto> Handle(RegisterCommand request, CancellationToken ct)
        {
            var (success, userId, email, userName, errors) =
                await _identity.RegisterAsync(request.Email, request.Password);

            if (!success)
                throw new Exception(string.Join(", ", errors));

            return _jwt.Generate(userId, email, userName);
        }

    }

}
