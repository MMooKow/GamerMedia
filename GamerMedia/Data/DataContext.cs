using GamerMedia.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamerMedia.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        { 
        }

        
    }
}
