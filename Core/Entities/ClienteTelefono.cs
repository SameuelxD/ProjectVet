using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class ClienteTelefono:BaseEntity
{
    [Required]
    public int IdCliente { get; set; }

    [Required]
    public string Numero { get; set; }
}
