using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Features.Authentication.Queries.Me
{
    public record MeQuery : IRequest<MeDto>;
}
