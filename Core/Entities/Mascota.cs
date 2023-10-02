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

    [Required]
    public DateTime FechaNacimiento { get; set; }

    [Required]
    public int IdCliente { get; set; }
}
