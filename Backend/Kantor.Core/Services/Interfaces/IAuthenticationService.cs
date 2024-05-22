using Kantor.Core.DTOs.Auth;

namespace Kantor.Core.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<TokenDTO> Login(LoginDTO data);
        Task Register(RegisterDTO data);
        Task<TokenDTO> RefreshToken(string token);
    }
}
