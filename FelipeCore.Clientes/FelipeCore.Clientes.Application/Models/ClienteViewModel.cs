using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FelipeCore.Clientes.Application.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [DisplayName("Telefone (Somente Números)")]
        public string Telefone { get; set; }
    }
}
