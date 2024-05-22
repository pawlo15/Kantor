using Kantor.Infrastructure.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kantor.Infrastructure.Configuration
{
    public class UserOperationConfiguration : IEntityTypeConfiguration<UserOperation>
    {
        public void Configure(EntityTypeBuilder<UserOperation> builder)
        {
            builder.ToTable(nameof(UserOperation));

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.HasMany(p => p.History)
                .WithOne(p => p.Operation)
                .HasForeignKey(p => p.OperationId);

        }
    }
}
