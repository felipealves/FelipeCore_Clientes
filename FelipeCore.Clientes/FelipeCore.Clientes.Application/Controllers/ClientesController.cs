using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FelipeCore.Clientes.Application.Models;
using FelipeCore.Clientes.Domain.Entities;
using FelipeCore.Clientes.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FelipeCore.Clientes.Application.Controllers
{
    public class ClientesController : Controller
    {
        private BaseService<Cliente> service = new BaseService<Cliente>();

        public IActionResult Index()
        {
            var l = service.ConsultarTodos();
            return View(PopulaViewModel(l.ToList()));
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = service.ConsultarPorId(id.GetValueOrDefault());

            if (cliente == null)
            {
                return NotFound();
            }

            return View(PopulaViewModel(cliente));
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Novo(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var c = new Cliente
                {
                    Nome = clienteViewModel.Nome,
                    Email = clienteViewModel.Email,
                    Telefone = clienteViewModel.Telefone
                };
                
                service.Incluir(c);

                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c = service.ConsultarPorId(id.GetValueOrDefault());
            if (c == null)
            {
                return NotFound();
            }

            var cvm = PopulaViewModel(c);

            return View(cvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var c = service.ConsultarPorId(id);
                    
                    c.Nome = clienteViewModel.Nome;
                    c.Email = clienteViewModel.Email;
                    c.Telefone = clienteViewModel.Telefone;

                    service.Alterar(c);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c = service.ConsultarPorId(id.GetValueOrDefault());

            if (c == null)
            {
                return NotFound();
            }

            var cvm = PopulaViewModel(c);

            return View(cvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int id)
        {
            service.Remover(id);
            return RedirectToAction("Index");
        }

        private List<ClienteViewModel> PopulaViewModel(List<Cliente> clientes)
        {
            var retorno = new List<ClienteViewModel>();
            foreach (var c in clientes)
            {
                retorno.Add(new ClienteViewModel
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Email = c.Email,
                    Telefone = c.Telefone
                });
            }

            return retorno;
        }

        private ClienteViewModel PopulaViewModel(Cliente c)
        {
            return new ClienteViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Telefone = c.Telefone
            };
        }
    }
}