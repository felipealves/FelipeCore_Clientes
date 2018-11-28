using FelipeCore.Clientes.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FelipeCore.Clientes.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Incluir<V>(T obj) where V : AbstractValidator<T>;

        T Alterar<V>(T obj) where V : AbstractValidator<T>;

        void Remover(int id);

        T ConsultarPorId(int id);

        IList<T> ConsultarTodos();

        IList<T> Consultar(Expression<Func<T, bool>> expression);
    }
}
