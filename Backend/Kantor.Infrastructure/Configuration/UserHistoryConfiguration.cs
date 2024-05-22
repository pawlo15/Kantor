using Kantor.Infrastructure.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kantor.Infrastructure.Configuration
{
    public class UserHistoryConfiguration : IEntityTypeConfiguration<UserHistory>
    {
        public void Configure(EntityTypeBuilder<UserHistory> builder)
        {
            builder.ToTable(nameof(UserHistory));

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Date)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Action)
                .IsRequired();

            builder.Property(p => p.OperationId)
                .IsRequired();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(p => p.History)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Operation)
                .WithMany(p => p.History)
                .HasForeignKey(p => p.OperationId);
        }
    }
}
