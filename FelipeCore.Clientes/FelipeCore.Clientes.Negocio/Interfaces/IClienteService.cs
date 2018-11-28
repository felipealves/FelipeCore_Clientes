using FelipeCore.Clientes.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FelipeCore.Clientes.Domain.Interfaces
{
    public interface IClienteService
    {
        Cliente Incluir(Cliente obj);

        Cliente Alterar(Cliente obj);

        void Remover(int id);

        Cliente ConsultarPorId(int id);

        IList<Cliente> ConsultarTodos();

        IList<Cliente> Consultar(Expression<Func<Cliente, bool>> expression);
    }
}
