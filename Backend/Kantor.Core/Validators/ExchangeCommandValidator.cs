using FluentValidation;
using Kantor.Core.CQRS.Command.Operation;

namespace Kantor.Core.Validators
{
    public class ExchangeCommandValidator : AbstractValidator<ExchangeCommand>
    {
        public ExchangeCommandValidator()
        {
            RuleFor(x => x.Amount)
                .GreaterThan(0.0M);
        }
    }
}
