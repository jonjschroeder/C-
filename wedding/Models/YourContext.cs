using wedding.Models;
using Microsoft.EntityFrameworkCore;
 
namespace wedding.Models
{
    
    public class YourContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public YourContext(DbContextOptions<YourContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
    }
}