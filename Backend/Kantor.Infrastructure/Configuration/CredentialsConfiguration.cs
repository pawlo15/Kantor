using Kantor.Infrastructure.Entities.Auth;
using Kantor.Infrastructure.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kantor.Infrastructure.Configuration
{
    public class CredentialsConfiguration : IEntityTypeConfiguration<Credentials>
    {
        public void Configure(EntityTypeBuilder<Credentials> builder)
        {
            builder.ToTable(nameof(Credentials));

            builder.HasKey(x => x.Id);

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.PasswordSalt)
                .IsRequired();

            builder.Property(p => p.PasswordHash)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithOne(p => p.Credentials);
        }
    }
}
