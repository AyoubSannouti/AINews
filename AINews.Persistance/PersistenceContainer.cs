using AINews.Application.Contracts;
using AINews.Persistance.Identity;
using AINews.Persistance.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AINews.Persistance
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AINewsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IArticleRepository), typeof(ArticleRepository));
            services.AddScoped(typeof(IEventRepository), typeof(EventRepository));

            // Add Identity Services
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AINewsDbContext>()
            .AddDefaultTokenProviders();

            // Register internal TokenService (no interface)
            services.AddScoped<TokenService>();

            // Register Application Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserSynchronizationRepository, UserSynchronizationRepository>();

            return services;
        }
    }
}
