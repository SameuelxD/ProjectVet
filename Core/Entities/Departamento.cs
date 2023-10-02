namespace Core.Entities;
public class Departamento : BaseEntity
{
    public string NombreDepartamento { get; set; }
    public int IdPais { get; set; }
    public Pais Pais { get; set; }

    /* Linea Relacional de Pais de uno a muchos donde cada departamento tendra un solo dato tipo Pais */

    public ICollection<Ciudad> Ciudades { get; set; }

    /* Linea Relacional uno a muchos donde cada Departamento tendra un grupo de ciudades 
        
        public ICollection<Ciudad> Ciudades { get; set; }    
   
    */
}
