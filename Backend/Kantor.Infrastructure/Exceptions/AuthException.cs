namespace Kantor.Infrastructure.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException(string? message) : base(message) { }
    }
}
