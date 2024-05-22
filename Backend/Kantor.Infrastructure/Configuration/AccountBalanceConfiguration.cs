using Kantor.Infrastructure.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kantor.Infrastructure.Configuration
{
    public class AccountBalanceConfiguration : IEntityTypeConfiguration<AccountBalance>
    {
        public void Configure(EntityTypeBuilder<AccountBalance> builder)
        {
            builder.ToTable(nameof(AccountBalance));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Balance)
                .IsRequired();

            builder.Property(x => x.CurrencyId)
                .IsRequired();

            builder.Property(x => x.AccountId)
                .IsRequired();

            builder.HasOne(x => x.Currency)
                .WithMany(x => x.AccountBalances)
                .HasForeignKey(x => x.CurrencyId);
        }
    }
}
