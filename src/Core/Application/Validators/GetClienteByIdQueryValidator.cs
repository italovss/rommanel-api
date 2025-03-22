using FluentValidation;
using Rommanel.Application.Queries;

namespace Rommanel.Application.Validators
{
    public class GetClienteByIdQueryValidator : AbstractValidator<GetClienteByIdQuery>
    {
        public GetClienteByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID do cliente é obrigatório.");
        }
    }
}
