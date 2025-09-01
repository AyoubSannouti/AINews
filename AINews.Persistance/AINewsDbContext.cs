using AINews.Domain.Entities;
using AINews.Persistance.Identity;
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
        public DbSet<User> User { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<EventCategory> EventCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Domain User relationships
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasOne(a => a.Author)
                    .WithMany(u => u.Articles)
                    .HasForeignKey(a => a.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.ArticleCategory)
                    .WithMany()
                    .HasForeignKey(a => a.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.CreatedBy)
                    .WithMany(u => u.Events)
                    .HasForeignKey(e => e.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.EventCategory)
                    .WithMany()
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Domain User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Email).IsUnique();
            });
        }
    }
}
