using Kantor.Infrastructure.Entities.Operations;
using Kantor.Infrastructure.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kantor.Infrastructure.Configuration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable(nameof(Currency));

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Code)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired();

            builder.HasMany(p => p.History)
                .WithOne(p => p.Currency)
                .HasForeignKey(p => p.CurrencyId);

            builder.HasMany(p => p.AccountBalances)
                .WithOne(p => p.Currency)
                .HasForeignKey(p => p.CurrencyId);
        }
    }
}
