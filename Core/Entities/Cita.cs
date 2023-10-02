using System.ComponentModel.DataAnnotations;

namespace Core.Entities; 
public class Cita:BaseEntity
{
    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public TimeSpan Hora { get; set; }

    [Required]
    public int IdCliente { get; set; }

    [Required]
    public int IdMascota { get; set; }

    [Required]
    public string Servicios { get; set; }
}
