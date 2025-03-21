using FluentValidation;
using Rommanel.Domain.Entities;

namespace Rommanel.Application.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório");

            RuleFor(c => c.CPF_CNPJ)
                .NotEmpty().WithMessage("CPF/CNPJ é obrigatório")
                .Matches(@"^\d{11}|\d{14}$").WithMessage("CPF/CNPJ inválido");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email é obrigatório")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Telefone é obrigatório");

            RuleFor(c => c.DataNascimento)
                .Must(data => data <= DateTime.Today.AddYears(-18))
                .WithMessage("Cliente deve ter no mínimo 18 anos");

            RuleFor(c => c.Endereco).SetValidator(new EnderecoValidator());
        }
    }
}
