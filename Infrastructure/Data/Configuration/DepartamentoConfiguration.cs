using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            // Aqui puedes configurar las porpiedades de la Entidad Deparatmento , utilizando el objeto builder
            builder.ToTable("Departamento");

            builder.HasKey(e => e.Id);  //Definicion llave primaria
            builder.Property(e => e.Id);

            builder.Property(p => p.NombreDepartamento).IsRequired().HasMaxLength(50);

            builder.HasOne(p => p.Paises).WithMany(p => p.Departamentos).HasForeignKey(p => p.IdPais);

        }
    }
}