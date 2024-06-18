using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
  public class DataContext : IdentityDbContext<User, Role, int>
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<AccountGroup> AccountGroups { get; set; }

    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Role>()
          .HasData(
              new Role { Id = 1, Name = "Member", NormalizedName = "MEMBER" },
              new Role { Id = 2, Name = "Admin", NormalizedName = "ADMIN" }
          );
    }
  }
}