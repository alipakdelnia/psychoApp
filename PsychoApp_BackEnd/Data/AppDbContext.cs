using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using psychoApp.Models;

namespace psychoApp.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        
    }
}