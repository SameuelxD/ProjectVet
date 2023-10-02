using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Cliente:BaseEntity
{
    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Apellido { get; set; }
    
    [Required]
    public string Email { get; set; }
}
