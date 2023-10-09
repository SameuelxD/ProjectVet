using System.ComponentModel.DataAnnotations;

namespace Core.Entities; 
public class Mascota:BaseEntity
{
    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Especie { get; set; }

    [Required]
    public int IdRaza { get; set; }

    public Raza Raza { get; set; }

    [Required]
    public DateTime FechaNacimiento { get; set; }

    [Required]
    public int IdCliente { get; set; }

    public Cliente Clientes { get; set; } /* Linea Relacional de Cliente , de uno a muchos donde cada Mascota tendra un solo dato tipo cliente */

    public ICollection<Cita> Citas { get; set; }
}
