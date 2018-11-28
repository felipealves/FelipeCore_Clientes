using FelipeCore.Clientes.Domain.Entities;
using FelipeCore.Clientes.Domain.Interfaces;
using FelipeCore.Clientes.Infra.Data.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FelipeCore.Clientes.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();

        public T Incluir<V>(T obj) where V : AbstractValidator<T>
        {
            Validar(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public T Alterar<V>(T obj) where V : AbstractValidator<T>
        {
            Validar(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public void Remover(int id)
        {
            if (id == 0)
                throw new ArgumentException("ID informado inválido, por favor informe um ID válido.");

            repository.Delete(id);
        }

        public IList<T> ConsultarTodos() => repository.SelectAll();

        public T ConsultarPorId(int id)
        {
            if (id == 0)
                throw new ArgumentException("ID informado inválido, por favor informe um ID válido.");

            return repository.Select(id);
        }

        public IList<T> Consultar(Expression<Func<T, bool>> expression)
        {
            return repository.Select(expression);
        }

        private void Validar(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registro não encontrado!");

            validator.ValidateAndThrow(obj);
        }
    }
}
