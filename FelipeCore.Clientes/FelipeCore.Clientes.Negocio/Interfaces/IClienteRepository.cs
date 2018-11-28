using FelipeCore.Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FelipeCore.Clientes.Domain.Interfaces
{
    public interface IClienteRepository
    {
        void Insert(Cliente obj);

        void Update(Cliente obj);

        void Delete(int id);

        Cliente Select(int id);

        IList<Cliente> SelectAll();

        IList<Cliente> Select(Expression<Func<Cliente, bool>> expression);
    }
}
