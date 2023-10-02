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

    public ClienteDireccion ClienteDireccion { get; set; } 

    /* Linea Relacional de Cliente Direccion de uno a uno donde cada Cliente tendra un solo dato tipo ClienteDireccion */

    public ICollection<ClienteTelefono> ClientesTelefonos { get; set; }

    /* Linea Relacional de Cliente Telefono de uno a uno donde cada Cliente tendra un solo dato tipo ClienteTelefono */

    public ICollection<Mascota> Mascotas { get; set; }
    /* Linea Relacional de Mascotas de uno a muchos donde cada Cliente tendra un grupo de datos tipo Mascota */

    public ICollection<Cita> Citas { get; set; }
}
