using api.Models;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Token> Tokens { get; set; }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Institution> Institutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Institution)
                .WithMany(i => i.Accounts)
                .HasForeignKey(a => a.InstitutionId);
        }
    }
}