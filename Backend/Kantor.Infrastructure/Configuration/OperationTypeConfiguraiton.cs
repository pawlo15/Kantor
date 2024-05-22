using Kantor.Infrastructure.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kantor.Infrastructure.Configuration
{
    public class OperationTypeConfiguraiton : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder.ToTable(nameof(OperationType));

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.HasMany(p => p.History)
                .WithOne(p => p.OperationType)
                .HasForeignKey(p => p.OperationTypeId);
        }
    }
}
