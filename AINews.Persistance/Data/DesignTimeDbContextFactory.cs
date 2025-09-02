using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Persistance.Data
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AINewsDbContext>
    {
        public AINewsDbContext CreateDbContext(string[] args)
        {
        var basePath = Directory.GetCurrentDirectory(); // usually the API project when you run dotnet ef
        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var cs = config.GetConnectionString("DefaultConnection")
                 ?? "Server=.;Database=AINewsDb;Trusted_Connection=True;TrustServerCertificate=True";

        var options = new DbContextOptionsBuilder<AINewsDbContext>()
            .UseSqlServer(cs)
            .Options;

        return new AINewsDbContext(options);
        }
    }
    
}
