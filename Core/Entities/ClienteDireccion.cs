using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class ClienteDireccion : BaseEntity
{
    [Required]
    public int IdCliente { get; set; }      //Llave Foranea    
    public Cliente Clientes { get; set; } /* Linea Relacional de Cliente de uno a uno donde cada ClienteDireccion tendra un solo dato tipo Cliente */
    public string TipoDeVia { get; set; }
    public int NumeroPri { get; set; }
    public string Letra { get; set; }
    public string Bis { get; set; }
    public string LetraSec { get; set; }
    public string Cardinal { get; set; }
    public int NumeroSec { get; set; }
    public string LetraTer { get; set; }
    public int NumeroTer { get; set; }
    public string CardinalSec { get; set; }
    public string Complemento { get; set; }
    public string CodigoPostal { get; set; } 

    [Required]
    public int IdCiudad { get; set; }

    public Ciudad Ciudades { get; set; }
    /* Linea Relacional de Ciudad de uno a muchos donde cada ClienteDireccion tendra un solo dato tipo Ciudad */
    
}
