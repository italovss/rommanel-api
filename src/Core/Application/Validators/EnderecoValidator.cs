using FluentValidation;
using Rommanel.Domain.Entities;

namespace Rommanel.Application.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(e => e.CEP).NotEmpty();
            RuleFor(e => e.Logradouro).NotEmpty();
            RuleFor(e => e.Numero).NotEmpty();
            RuleFor(e => e.Bairro).NotEmpty();
            RuleFor(e => e.Cidade).NotEmpty();
            RuleFor(e => e.Estado).NotEmpty();
        }
    }
}