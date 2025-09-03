using AINews.Domain.Entities;
using AINews.Persistance.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AINews.Persistance.Data
{
    public class AINewsDbContext : IdentityDbContext<ApplicationUser>
    {
        public AINewsDbContext(DbContextOptions<AINewsDbContext> options) : base(options)
        {

        }
        public DbSet<Article> Article { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<EventCategory> EventCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Article
            modelBuilder.Entity<Article>(e =>
            {
                e.ToTable("Article");
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).HasMaxLength(200).IsRequired();
                e.Property(x => x.Content).IsRequired();

                // FK: AuthorId -> AspNetUsers (ApplicationUser)
                e.HasOne<ApplicationUser>()
                 .WithMany()
                 .HasForeignKey(x => x.AuthorId)
                 .HasPrincipalKey(u => u.Id)
                 .OnDelete(DeleteBehavior.Restrict);

                // FK: CategoryId -> ArticleCategory
                e.HasOne(x => x.ArticleCategory)
                 .WithMany(c => c.Articles)
                 .HasForeignKey(x => x.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // Event
            modelBuilder.Entity<Event>(e =>
            {
                e.ToTable("Event");
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).HasMaxLength(200).IsRequired();

                // FK: CreatedById -> AspNetUsers (ApplicationUser)
                e.HasOne<ApplicationUser>()
                 .WithMany()
                 .HasForeignKey(x => x.CreatedById)
                 .HasPrincipalKey(u => u.Id)
                 .OnDelete(DeleteBehavior.Restrict);

                // FK: CategoryId -> EventCategory
                e.HasOne(x => x.EventCategory)
                 .WithMany(c => c.Events)
                 .HasForeignKey(x => x.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // Categories
            modelBuilder.Entity<ArticleCategory>(e =>
            {
                e.ToTable("ArticleCategory");
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<EventCategory>(e =>
            {
                e.ToTable("EventCategory");
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).HasMaxLength(100).IsRequired();
            });
        }
    }
}