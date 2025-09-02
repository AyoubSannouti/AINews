using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Contracts
{
    public interface IIdentityService
    {
        Task<(bool Success, string UserId, string Email, string UserName, IEnumerable<string> Errors)>
           RegisterAsync(string email, string password);

        Task<(bool Success, string UserId, string Email, string UserName, IEnumerable<string> Errors)>
            LoginAsync(string email, string password);
    }
}
