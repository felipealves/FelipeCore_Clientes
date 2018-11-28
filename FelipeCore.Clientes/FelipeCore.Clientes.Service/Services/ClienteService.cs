using FelipeCore.Clientes.Domain.Entities;
using FelipeCore.Clientes.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FelipeCore.Clientes.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IValidator<Cliente> _clienteValidator;

        public ClienteService(IClienteRepository repository, IValidator<Cliente> clienteValidator)
        {
            _repository = repository;
            _clienteValidator = clienteValidator;
        }

        public Cliente Incluir(Cliente obj)
        {
            Validar(obj);

            _repository.Insert(obj);
            return obj;
        }

        public Cliente Alterar(Cliente obj)
        {
            Validar(obj);

            _repository.Update(obj);
            return obj;
        }

        public void Remover(int id)
        {
            if (id == 0)
                throw new ArgumentException("ID informado inválido, por favor informe um ID válido.");

            _repository.Delete(id);
        }

        public IList<Cliente> ConsultarTodos() => _repository.SelectAll();

        public Cliente ConsultarPorId(int id)
        {
            if (id == 0)
                throw new ArgumentException("ID informado inválido, por favor informe um ID válido.");

            return _repository.Select(id);
        }

        public IList<Cliente> Consultar(Expression<Func<Cliente, bool>> expression)
        {
            return _repository.Select(expression);
        }

        private void Validar(Cliente obj)
        {
            if (obj == null)
                throw new Exception("Registro não encontrado!");

            _clienteValidator.ValidateAndThrow(obj);
        }
    }
}
