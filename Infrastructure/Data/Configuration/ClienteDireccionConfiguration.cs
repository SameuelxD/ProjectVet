using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ClienteDireccionConfiguration:IEntityTypeConfiguration<ClienteDireccion>
    {
        public void Configure(EntityTypeBuilder<ClienteDireccion> builder)
        {
            builder.ToTable("ClienteDireccion");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.TipoDeVia).IsRequired().HasMaxLength(10);
            builder.Property(p => p.NumeroPri).IsRequired().HasMaxLength(10);              
            builder.Property(p => p.Letra).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Complemento).IsRequired().HasMaxLength(50);
            builder.Property(p => p.CodigoPostal).IsRequired().HasMaxLength(10);

            builder.HasOne(a => a.Clientes).WithOne(b => b.ClienteDireccion).HasForeignKey<ClienteDireccion>(b => b.IdCliente);

            builder.HasOne(p => p.Ciudades).WithOne(p => p.ClienteDireccion).HasForeignKey<ClienteDireccion>(p => p.IdCiudad);
              
        }
    }
}