using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            //Aqui se puede configurar las propiedades de la Entidad Pais u tilizando el objeto builder

            builder.ToTable("Pais");

            builder.HasKey(e => e.Id);  //Definicion llave primaria
            builder.Property(e => e.Id);

            builder.Property(p => p.NombrePais).IsRequired().HasMaxLength(50);

        }
    }
}