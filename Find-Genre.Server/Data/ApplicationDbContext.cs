using Find_Genre.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Find_Genre.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Genre> Genres { get; set; }
        
    }
}
