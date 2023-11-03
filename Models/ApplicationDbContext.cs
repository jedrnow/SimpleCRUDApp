using Microsoft.EntityFrameworkCore;

namespace SimpleCRUDApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; private set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }

}
