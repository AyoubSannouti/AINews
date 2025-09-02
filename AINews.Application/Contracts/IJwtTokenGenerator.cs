using AINews.Application.Features.Authentication.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Contracts
{
    public interface IJwtTokenGenerator
    {
        AuthResultDto Generate(string userId, string email, string userName, IEnumerable<string>? roles = null);
    }
}
