using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class ClienteTelefono:BaseEntity
{
    [Required]
    public int IdCliente { get; set; }

    public Cliente Clientes { get; set; } /* Linea Relacional de Cliente de uno a uno donde cada ClienteTelfono tendra un solo dato tipo Cliente */
    [Required]
    public string Numero { get; set; }
}
