using AINews.Application.Features.Authentication.Commands.Register;
using AINews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Application.Contracts
{
    public interface IUserService
    {
        Task<(User user, string Token)> CreateUserAsync(CreateUserDto createUserDto);
        Task<User?> GetUserByEmailAsync(string email);
        Task<(User? user, string? Token)> AuthenticateAsync(string email, string password);
        Task UpdateLastLoginAsync(string userId);
    }
}