using FluentValidation;
using Kantor.Core.DTOs.Auth;

namespace Kantor.Core.Validators
{
    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator() 
        {
            RuleFor(x => x.Login)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
