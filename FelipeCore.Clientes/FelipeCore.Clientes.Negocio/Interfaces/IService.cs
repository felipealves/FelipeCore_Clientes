using FelipeCore.Clientes.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace FelipeCore.Clientes.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Incluir(T obj);

        T Alterar(T obj);

        void Remover(int id);

        T ConsultarPorId(int id);

        IList<T> ConsultarTodos();
    }
}
