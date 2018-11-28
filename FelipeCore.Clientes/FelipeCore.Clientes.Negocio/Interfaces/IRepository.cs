using FelipeCore.Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FelipeCore.Clientes.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);

        void Update(T obj);

        void Delete(int id);

        T Select(int id);

        IList<T> SelectAll();

        IList<T> Select(Expression<Func<T, bool>> expression);
    }
}
