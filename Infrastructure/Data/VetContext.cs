using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class VetContext : DbContext
{
    public VetContext(DbContextOptions options) : base(options)     //Contructor del Contexto
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly())
    }
}
