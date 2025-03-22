using FluentValidation;
using Rommanel.Application.Commands;

namespace Rommanel.Application.Validators
{
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID é obrigatório.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(x => x.CPF_CNPJ)
                .NotEmpty().WithMessage("O CPF/CNPJ é obrigatório.")
                .Matches(@"^\d{11}|\d{14}$").WithMessage("CPF/CNPJ inválido.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("Email inválido.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.");

            RuleFor(x => x.DataNascimento)
                .Must(data => data <= DateTime.Today.AddYears(-18))
                .WithMessage("O cliente deve ter no mínimo 18 anos.");

            RuleFor(x => x.Endereco).SetValidator(new EnderecoValidator());
        }
    }
}
