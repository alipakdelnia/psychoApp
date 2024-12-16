using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using psychoApp.Models;

namespace psychoApp.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

<<<<<<< HEAD
        public DbSet<User> Users { get; set; } = null!;

        
=======
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
                entity.Property(u => u.PasswordHash).IsRequired();
            });
        }
>>>>>>> 98d3c957708bcee2e752ba1b932e03fc0f525415
    }
}