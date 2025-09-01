using AINews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Contracts
{
    public interface IUserSynchronizationRepository
    {
        Task SyncUserAsync(string applicationUserId, string email, string firstName, string lastName);
        Task<User?> GetUserByApplicationUserIdAsync(string applicationUserId);
    }
}
