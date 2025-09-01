using AINews.Application.Contracts;
using AINews.Application.Features.Authentication.Commands.Register;
using AINews.Domain.Entities;
using AINews.Persistance.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Persistance.Repositories
{
    internal class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserSynchronizationRepository _syncService;
        private readonly TokenService _tokenService;

        public UserService(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    IUserSynchronizationRepository syncService,
    TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _syncService = syncService;
            _tokenService = tokenService;
        }

        public async Task<(User user, string Token)> CreateUserAsync(CreateUserDto createUserDto)
        {
            var applicationUser = new ApplicationUser
            {
                Email = createUserDto.Email,
                UserName = createUserDto.Email,
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(applicationUser, createUserDto.Password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"User creation failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            // Generate token
            var token = await _tokenService.GenerateTokenAsync(applicationUser);

            // Sync to domain user
            await _syncService.SyncUserAsync(applicationUser.Id, createUserDto.Email, createUserDto.FirstName, createUserDto.LastName);

            var user = await _syncService.GetUserByApplicationUserIdAsync(applicationUser.Id);
            if (user == null)
                throw new InvalidOperationException("Failed to create domain user");

            return (user, token);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);
            if (applicationUser == null) return null;

            return await _syncService.GetUserByApplicationUserIdAsync(applicationUser.Id);
        }

        public async Task<(User? user, string? Token)> AuthenticateAsync(string email, string password)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);
            if (applicationUser == null) return (null, null);

            var result = await _signInManager.CheckPasswordSignInAsync(applicationUser, password, false);
            if (!result.Succeeded) return (null, null);

            // Generate token
            var token = await _tokenService.GenerateTokenAsync(applicationUser);

            // Get user
            var user = await _syncService.GetUserByApplicationUserIdAsync(applicationUser.Id);

            return (user, token);
        }

        public async Task UpdateLastLoginAsync(string userId)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId);
            if (applicationUser != null)
            {
                applicationUser.LastLoginAt = DateTime.UtcNow;
                await _userManager.UpdateAsync(applicationUser);
            }

            // Sync to domain user
            var user = await _syncService.GetUserByApplicationUserIdAsync(userId);
            if (user != null)
            {
                user.LastLoginAt = DateTime.UtcNow;
                // This would be handled by your domain user repository if needed
            }
        }

    }
}
