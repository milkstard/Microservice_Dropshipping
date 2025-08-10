using AccountsService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountsService.Helper
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration configuration;

        public DbContextClass(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasIndex(u => u.Email)
                .IsUnique();

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserSalt> UserSalts { get; set; }
        public DbSet<UserTypes> UserTypes { get; set; }
    }
}
