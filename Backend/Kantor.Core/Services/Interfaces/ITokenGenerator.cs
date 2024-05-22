using Kantor.Infrastructure.Entities.User;

namespace Kantor.Core.Services.Interfaces
{
    public interface ITokenGenerator
    {
        Task<string> GenerateAccessToken(User user);
        Task<string> GenerateRefreshToken(User user);

        bool TokenValidity(string token, out Guid? id);
    }
}
