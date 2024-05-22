using Kantor.Infrastructure.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kantor.Infrastructure.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));

            builder.HasKey(x => x.Id);

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.HasMany(p => p.AccountBalances)
                .WithOne(p => p.Account)
                .HasForeignKey(p => p.AccountId);

            builder.HasOne(p => p.User)
                .WithOne(p => p.Account);
        }
    }
}
