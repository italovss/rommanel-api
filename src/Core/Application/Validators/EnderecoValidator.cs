using FluentValidation;
using Rommanel.Domain.Entities;

namespace Rommanel.Application.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(e => e.CEP)
                .NotEmpty().WithMessage("O CEP é obrigatório.");

            RuleFor(e => e.Logradouro)
                .NotEmpty().WithMessage("O logradouro é obrigatório.");

            RuleFor(e => e.Numero)
                .NotEmpty().WithMessage("O número é obrigatório.");

            RuleFor(e => e.Bairro)
                .NotEmpty().WithMessage("O bairro é obrigatório.");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("A cidade é obrigatória.");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("O estado é obrigatório.");
        }
    }
}