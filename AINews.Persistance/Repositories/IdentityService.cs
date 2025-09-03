using AINews.Application.Contracts;
using AINews.Persistance.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Persistance.Repositories
{
    internal class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(UserManager<ApplicationUser> userManager,
                       SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(bool, string, string, string, IEnumerable<string>)> RegisterAsync(string email, string password)
        {
            var user = new ApplicationUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            return (result.Succeeded,
                    user.Id,
                    user.Email ?? string.Empty,
                    user.UserName ?? string.Empty,
                    result.Errors.Select(e => e.Description));
        }

        public async Task<(bool, string, string, string, IEnumerable<string>)> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return (false, "", "", "", new[] { "Invalid credentials" });

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
                return (false, "", "", "", new[] { "Invalid credentials" });

            return (true,
                    user.Id,
                    user.Email ?? string.Empty,
                    user.UserName ?? string.Empty,
                    Array.Empty<string>());
        }
    }
}
