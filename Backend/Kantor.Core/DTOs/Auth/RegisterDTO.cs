namespace Kantor.Core.DTOs.Auth
{
    public record RegisterDTO
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
