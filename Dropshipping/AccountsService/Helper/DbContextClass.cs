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
            //modelBuilder.Entity<Users>()
            //    .HasIndex(u => u.Email)
            //    .IsUnique();

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(u => u.Email)
                .IsUnique();

                entity.HasOne(u => u.UserType)
                      .WithMany(t => t.Users)
                      .HasForeignKey(u => u.UserTypeFK);

                entity.Property(u => u.UserTypeFK)
                      .HasColumnName("UserType_FK");

                entity.HasOne(u => u.UserSalt)
                      .WithOne(t => t.User)
                      .HasForeignKey<Users>(u => u.UserSaltId);

                entity.Property(u => u.UserSaltId)
                      .HasColumnName("UserSaltID_FK");
            });
                
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserSalt> UserSalts { get; set; }
        public DbSet<UserTypes> UserTypes { get; set; }
    }
}
