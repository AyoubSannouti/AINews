using AINews.Application.Contracts;
using AINews.Domain.Entities;
using AINews.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Persistance.Repositories
{
    internal class UserSynchronizationRepository : IUserSynchronizationRepository
    {
        private readonly AINewsDbContext _context;

        public UserSynchronizationRepository(AINewsDbContext context)
        {
            _context = context;
        }

        public async Task SyncUserAsync(string applicationUserId, string email, string firstName, string lastName)
        {
            var existingUser = await _context.User
                .FirstOrDefaultAsync(u => u.Id == applicationUserId);

            if (existingUser == null)
            {
                // Create new domain user
                var user = new User
                {
                    Id = applicationUserId,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                };

                _context.User.Add(user);
            }
            else
            {
                // Update existing domain user
                existingUser.Email = email;
                existingUser.FirstName = firstName;
                existingUser.LastName = lastName;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByApplicationUserIdAsync(string applicationUserId)
        {
            return await _context.User
                .FirstOrDefaultAsync(u => u.Id == applicationUserId);
        }
    }
}
