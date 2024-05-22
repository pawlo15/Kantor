using Kantor.Core.DTOs.Account;
using Kantor.Core.DTOs.Operation;

namespace Kantor.Core.DTOs.User
{
    public record UserDetailsDTO
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SecureKey { get; set; }

        public ICollection<AccountBalanceDTO> AccountBalances { get; set; }
        public ICollection<UserHistoryDTO> History { get; set; }
        public ICollection<OperationHistoryDTO> OperationHistory { get; set; }
    }
}
