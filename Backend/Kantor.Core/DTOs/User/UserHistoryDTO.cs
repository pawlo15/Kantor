namespace Kantor.Core.DTOs.User
{
    public record UserHistoryDTO
    {
        public string Action { get; set; }
        public DateTime Date { get; set; }
    }
}
