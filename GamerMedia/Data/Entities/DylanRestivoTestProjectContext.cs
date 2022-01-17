using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GamerMedia.Data.Entities
{
    public partial class DylanRestivoTestProjectContext : DbContext
    {
        public DylanRestivoTestProjectContext()
        {
        }

        public DylanRestivoTestProjectContext(DbContextOptions<DylanRestivoTestProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(35);

                entity.Property(e => e.LastName).HasMaxLength(35);

                entity.Property(e => e.Username).HasMaxLength(35);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
