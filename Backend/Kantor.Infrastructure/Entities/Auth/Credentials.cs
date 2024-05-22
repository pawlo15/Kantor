using Kantor.Shared.Abstraction;

namespace Kantor.Infrastructure.Entities.Auth
{
    public class Credentials : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual User.User User { get; set; }
    }
}
