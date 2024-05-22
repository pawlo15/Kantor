using Kantor.Infrastructure.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kantor.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Email)
                .IsRequired();

            builder.Property(p => p.Login)
                .IsRequired();

            builder.Property(p => p.SecureKey)
                .IsRequired();

            builder.HasOne(p => p.Credentials)
                .WithOne(p => p.User);

            builder.HasMany(p => p.History)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.OperationHistory)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Account)
                .WithOne(p => p.User);
        }
    }
}
