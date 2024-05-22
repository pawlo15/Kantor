using Kantor.Infrastructure.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kantor.Infrastructure.Configuration
{
    public class OperationHistoryConfiguration : IEntityTypeConfiguration<OperationHistory>
    {
        public void Configure(EntityTypeBuilder<OperationHistory> builder)
        {
            builder.ToTable(nameof(OperationHistory));

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Date)
                .IsRequired();

            builder.Property(p => p.Value)
                .IsRequired();

            builder.Property(p => p.ExchangeRate)
                .IsRequired();

            builder.Property(p => p.TotalValue)
                .IsRequired();
        }
    }
}
