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
    public class ClienteRepository : IClienteRepository
    {
        private readonly SqlLiteContext _context;

        public ClienteRepository()
        {
            _context = new SqlLiteContext();
        }

        public void Insert(Cliente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Cliente obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(Select(id));
            _context.SaveChanges();
        }

        public IList<Cliente> SelectAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente Select(int id)
        {
            return _context.Clientes.Find(id);
        }

        public IList<Cliente> Select(Expression<Func<Cliente, bool>> expression)
        {
            return _context.Clientes.Where(expression).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
