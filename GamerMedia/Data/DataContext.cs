using GamerMedia.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamerMedia.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public string DbPath { get; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

    }
}
