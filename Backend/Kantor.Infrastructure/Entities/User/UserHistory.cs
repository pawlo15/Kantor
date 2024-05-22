using Kantor.Shared.Abstraction;

namespace Kantor.Infrastructure.Entities.User
{
    public class UserHistory : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Action {  get; set; }
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
        public int OperationId { get; set; }

        public virtual User User { get; set; }
        public virtual UserOperation Operation { get; set; }   
    }
}
