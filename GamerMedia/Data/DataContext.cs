using GamerMedia.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamerMedia.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public string DbPath { get; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Post>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Post>()
            .Property(p => p.UserId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Comment>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Comment>()
            .Property(c => c.PostId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Comment>()
            .Property(c => c.UserId)
            .ValueGeneratedOnAdd();
        }

    }
}
