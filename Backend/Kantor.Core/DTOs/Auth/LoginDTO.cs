namespace Kantor.Core.DTOs.Auth
{
    public record LoginDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
