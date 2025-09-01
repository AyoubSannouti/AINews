using AINews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Persistance
{
    public class AINewsDbContext : DbContext
    {
        public AINewsDbContext(DbContextOptions<AINewsDbContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categoryGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var articleGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            modelBuilder.Entity<ArticleCategory>().HasData(new ArticleCategory
            {
                Id = categoryGuid,
                Name = "Technology"
            });

            modelBuilder.Entity<Article>().HasData(new Article
            {
                Id = articleGuid,
                Title = "Morocco to Develop AI Model to Simplify Government Services",
                Content = "Rabat — Morocco plans to create an artificial intelligence (AI) model that will make government content easier to understand and handle citizen complaints through chatbots, the country’s digital transition minister Amal El Fallah Seghrouchni announced on Monday.\r\n\r\nSeghrouchni outlined details during the question session at the House of Representatives, detailing that the AI project is part of several initiatives her department has launched.\r\n\r\nShe revealed that the ministry is also working on a digital administration law, specifically including provisions related to AI, focusing on data protection and system security.",
                ImageUrl = "https://www.moroccoworldnews.com/wp-content/uploads/2025/07/Morocco-to-Develop-AI-Model-to-Simplify-Government-Services.webp",
                CategoryId = categoryGuid
            });

        }
    }
}
