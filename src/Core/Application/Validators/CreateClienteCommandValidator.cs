using FluentValidation;
using Rommanel.Application.Commands;

namespace Rommanel.Application.Validators
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório");

            RuleFor(c => c.CPF_CNPJ)
                .NotEmpty().WithMessage("O CPF/CNPJ é obrigatório")
                .Matches(@"^\d{11}|\d{14}$").WithMessage("CPF/CNPJ inválido");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório");

            RuleFor(c => c.DataNascimento)
                .Must(data => data <= DateTime.Today.AddYears(-18))
                .WithMessage("O cliente deve ter no mínimo 18 anos");

            RuleFor(c => c.Endereco).SetValidator(new EnderecoValidator());
        }
    }
}
