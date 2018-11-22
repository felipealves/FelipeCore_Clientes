using FelipeCore.Clientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FelipeCore.Clientes.Infra.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnName("Nome");

            builder.Property(c => c.Email)
                .HasColumnName("Email");

            builder.Property(c => c.Telefone)
                .HasColumnName("Telefone");
        }
    }
}
