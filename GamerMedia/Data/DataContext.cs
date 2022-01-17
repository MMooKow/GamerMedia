using Microsoft.EntityFrameworkCore;

namespace GamerMedia.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
