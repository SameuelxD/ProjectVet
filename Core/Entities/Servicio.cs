using System.ComponentModel.DataAnnotations;

namespace Core.Entities; 
public class Servicio:BaseEntity
{
    [Required]
    public string Nombre { get; set; }

    [Required]
    public double Precio { get; set; }
    
    public ICollection<Cita> Citas { get; set; }
}
