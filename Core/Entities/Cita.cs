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
    public Cliente Cliente { get; set; }

    [Required]
    public int IdMascota { get; set; }

    public Mascota Mascota { get; set; }
    
    [Required]
    public int ServicioId { get; set; }
    public Servicio Servicio { get; set; }

}
