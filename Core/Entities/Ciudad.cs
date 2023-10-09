namespace Core.Entities;
public class Ciudad : BaseEntity
{
    public string NombreCiudad { get; set; }
    public int IdDepartamento { get; set; }
    public Departamento Departamentos { get; set; }
    public ClienteDireccion ClienteDireccion { get; set; }

    /* Linea Relacional de Departamento de uno a muchos donde cada Ciudad tendra un solo dato tipo Departamento */

}
