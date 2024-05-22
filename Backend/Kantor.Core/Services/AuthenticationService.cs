using Kantor.Core.DTOs.Auth;
using Kantor.Core.Services.Interfaces;
using Kantor.Infrastructure.Configuration;
using Kantor.Infrastructure.Entities.Auth;
using Kantor.Infrastructure.Entities.User;
using Kantor.Infrastructure.Enums;
using Kantor.Infrastructure.Exceptions;
using Kantor.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kantor.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DataContext _context;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Random _random;
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public AuthenticationService(DataContext dataContext, ITokenGenerator tokenGenerator, IUnitOfWork unitOfWork)
        {
            _context = dataContext;
            _tokenGenerator = tokenGenerator;
            _unitOfWork = unitOfWork;
            _random = new Random();
        }

        public async Task<TokenDTO> Login(LoginDTO data)
        {
            var user = await _context.User.Include(u => u.Credentials).FirstOrDefaultAsync(x => x.Login == data.Login.ToLower());

            if (user == null || !Veryfication(data.Password, user.Credentials.PasswordHash, user.Credentials.PasswordSalt))
                throw new AuthException("");

            return new TokenDTO
            {
                AccessToken = await _tokenGenerator.GenerateAccessToken(user),
                RefreshToken = await _tokenGenerator.GenerateRefreshToken(user)
            };
        }

        public async Task<TokenDTO> RefreshToken(string token)
        {
            if (!_tokenGenerator.TokenValidity(token, out Guid? id))
                throw new Exception("Token jest nieprawidłowy");

            var user = await _context.User.Include(u => u.Credentials).FirstOrDefaultAsync(x => x.Id == id);

            return new TokenDTO
            {
                AccessToken = await _tokenGenerator.GenerateAccessToken(user),
                RefreshToken = await _tokenGenerator.GenerateRefreshToken(user)
            };
        }

        public async Task Register(RegisterDTO data)
        {
            if (await _unitOfWork.UserRepository.LoginExist(data.Login.ToLower()))
                throw new Exception("Istnieje taki użytkownik"); // zmienić wyjątek

            CreatePassword(data.Password, out byte[] passHash, out byte[] passSalt);

            User user = new User {
                Login = data.Login,
                Email = data.Email,
                Name = data.Name,
                Credentials = new Credentials {
                    PasswordHash = passHash,
                    PasswordSalt = passSalt
                },
                SecureKey = SecureKeyGenerator(),
                History = [ 
                    new UserHistory { 
                        Date = DateTime.UtcNow,
                        OperationId = (int)UserOperationEnum.Registration,
                        Action = UserOperationEnum.Registration.ToString()
                        },
                    new UserHistory {
                        Date = DateTime.UtcNow,
                        OperationId= (int)UserOperationEnum.SecureKeyGeneration,
                        Action = UserOperationEnum.SecureKeyGeneration.ToString()
                    }
                ],
                Account = new()
            };

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        private void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmacsha512 = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmacsha512.Key;
                passwordHash = hmacsha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool Veryfication(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmacsha512 = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var hash = hmacsha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return hash.SequenceEqual(passwordHash);
            }
        }

        private string SecureKeyGenerator()
           => new string(Enumerable.Repeat(Chars, 8)
                    .Select(k => k[_random.Next(k.Length)]).ToArray());
        
    }
}
