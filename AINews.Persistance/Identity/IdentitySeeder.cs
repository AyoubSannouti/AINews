using AINews.Application.Features.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Persistance.Identity
{
    public class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider sp, IConfiguration config)
        {
            using var scope = sp.CreateScope();
            var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // 1) Ensure Admin role exists
            if (!await roleMgr.RoleExistsAsync(Roles.Admin))
                await roleMgr.CreateAsync(new IdentityRole(Roles.Admin));

            // 2) Optionally create an initial admin user (from appsettings)
            var adminEmail = config["AdminSeed:Email"];
            var adminPwd = config["AdminSeed:Password"];

            if (!string.IsNullOrWhiteSpace(adminEmail) && !string.IsNullOrWhiteSpace(adminPwd))
            {
                var user = await userMgr.FindByEmailAsync(adminEmail);
                if (user == null)
                {
                    user = new ApplicationUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                    var create = await userMgr.CreateAsync(user, adminPwd);
                    if (!create.Succeeded)
                        throw new Exception("Failed to create seed admin: " + string.Join(", ", create.Errors.Select(e => e.Description)));
                }

                if (!await userMgr.IsInRoleAsync(user, Roles.Admin))
                    await userMgr.AddToRoleAsync(user, Roles.Admin);
            }
        }
    }
}
