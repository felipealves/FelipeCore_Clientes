using FelipeCore.Clientes.Domain.Entities;
using FelipeCore.Clientes.Domain.Interfaces;
using FelipeCore.Clientes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FelipeCore.Clientes.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SqlLiteContext context = new SqlLiteContext();

        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(Select(id));
            context.SaveChanges();
        }

        public IList<T> SelectAll()
        {
            return context.Set<T>().ToList();
        }

        public T Select(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IList<T> Select(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression).ToList();
        }
    }
}
