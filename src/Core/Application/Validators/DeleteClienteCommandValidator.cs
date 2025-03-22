using FluentValidation;
using Rommanel.Application.Commands;

namespace Rommanel.Application.Validators
{
    public class DeleteClienteCommandValidator : AbstractValidator<DeleteClienteCommand>
    {
        public DeleteClienteCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID do cliente é obrigatório.");
        }
    }
}
