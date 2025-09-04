using AINews.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Authentication.Queries.Me
{
    internal class MeQueryHandler : IRequestHandler<MeQuery, MeDto>
    {
        private readonly IIdentityService _identity;

        public MeQueryHandler(IIdentityService identity) => _identity = identity;

        public Task<MeDto> Handle(MeQuery request, CancellationToken cancellationToken)
            => _identity.GetCurrentUserAsync();
    }
}
