using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class VetContext : DbContext
{
    public VetContext(DbContextOptions options) : base(options)     //Contructor del Contexto
    { }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }  // Context DbSet para cada Entidad
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<Raza> Razas { get; set; }
    public DbSet<Servicio> Servicios { get; set; }
    public DbSet<ClienteDireccion> ClientesDirecciones { get; set; }
    public DbSet<ClienteTelefono> ClientesTelefonos { get; set; }
    
    public DbSet<Cita> Citas { get; set; }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
