using System;

namespace FelipeCore.Clientes.Application.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
