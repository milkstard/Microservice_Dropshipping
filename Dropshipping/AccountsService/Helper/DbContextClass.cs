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

        public DbSet<Users> Users { get; set; }
    }
}
