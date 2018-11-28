using FelipeCore.Clientes.Domain.Entities;
using FelipeCore.Clientes.Service.Services;
using FluentValidation;
using System;
using System.Linq;

namespace FelipeCore.Clientes.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Não foi possível encontrar a classe de cliente.");
                    });

            string msgNomeObrigatorio = "É obrigatório o preenchimento do 'Nome'.";
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(msgNomeObrigatorio)
                .NotNull().WithMessage(msgNomeObrigatorio);

            string msgTelefoneObrigatorio = "É obrigatório o preenchimento do 'Telefone'.";
            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage(msgTelefoneObrigatorio)
                .NotNull().WithMessage(msgTelefoneObrigatorio);

            string msgEmailObrigatorio = "É obrigatório o preenchimento do 'E-Mail'.";
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage(msgEmailObrigatorio)
                .NotNull().WithMessage(msgEmailObrigatorio)
                .EmailAddress().WithMessage("Formato do 'E-Mail' informado é inválido.")
                .Must(UniqueEmail).WithMessage("O 'E-Mail' informado já existe.");
        }

        private bool UniqueEmail(Cliente cliente, string email)
        {
            BaseService<Cliente> service = new BaseService<Cliente>();
            bool existeCliente = service.Consultar(x => x.Email.ToLower() == email.ToLower() && x.Id != cliente.Id).Any();
            return !existeCliente;
        }
    }
}
