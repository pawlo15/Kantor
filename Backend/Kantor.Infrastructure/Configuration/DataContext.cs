using Kantor.Infrastructure.Entities.Account;
using Kantor.Infrastructure.Entities.Auth;
using Kantor.Infrastructure.Entities.Operations;
using Kantor.Infrastructure.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kantor.Infrastructure.Configuration
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }

        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<UserOperation> Operation { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<OperationHistory> OperationHistories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountBalance> AccountBalances { get; set; }

    }
}
