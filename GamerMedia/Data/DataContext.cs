﻿using GamerMedia.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamerMedia.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public string DbPath { get; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

    }
}
