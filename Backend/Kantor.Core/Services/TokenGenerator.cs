using Kantor.Core.Services.Interfaces;
using Kantor.Infrastructure.Entities.User;
using Kantor.Infrastructure.Enums;
using Kantor.Shared.Policy;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Kantor.Core.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        private static string ACCESS_TOKEN = "ACCESS";
        private static string REFRESH_TOKEN = "REFRESH";
        private readonly string _token;

        public TokenGenerator(IConfiguration configuration) 
        {
            _token = configuration.GetSection("AppSettings:Token").Value;
        }

        public async Task<string> GenerateAccessToken(User user)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_token));

            List<Claim> claims = new List<Claim>
            {
                new (ClaimTypes.System, ACCESS_TOKEN),
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Name, user.Name),
                new (ClaimTypes.Role, RoleEnum.Client.ToString()),
            };

            //if (user.UserRoles != default)
            //{
            //    foreach (var item in user.UserRoles)
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, item.Role.Name.ToString()));
            //    }
            //}

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            SecurityToken token = handler.CreateToken(descriptor);

            return handler.WriteToken(token);
        }

        public async Task<string> GenerateRefreshToken(User user)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_token));

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.System, REFRESH_TOKEN),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1).AddMinutes(15),
                SigningCredentials = credentials
            };

            SecurityToken token = handler.CreateToken(descriptor);

            return handler.WriteToken(token);
        }

        public bool TokenValidity(string token, out Guid? id)
        {
            id = null;

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken == null)
                return false;

            if(jsonToken.Claims.Any(c => c.Type == ClaimTypes.System && c.Value == REFRESH_TOKEN))
                if (jsonToken.ValidTo > DateTime.Now)
                {
                    id = Guid.Parse(jsonToken.Claims.FirstOrDefault(c => c.Type == "nameid").Value);
                    return true;
                }
            return false;
        }
    }
}
