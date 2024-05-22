using FluentValidation;
using Kantor.Core.CQRS.Command.Operation;

namespace Kantor.Core.Validators
{
    public class AddResourcesCommandValidator: AbstractValidator<AddResourcesCommand>
    {
        public AddResourcesCommandValidator()
        {
            RuleFor(x => x.Value)
                .GreaterThan(0.0M);
        }
    }
}
