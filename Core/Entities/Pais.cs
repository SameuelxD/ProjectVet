namespace Core.Entities;
public class Pais:BaseEntity
{
    public string NombrePais { get; set; }
    
    public ICollection<Departamento> Departamentos { get; set; }
    /* Linea Relacional de uno a muchos , en este caso un pais para muchos Departamentos , cada Pais tendra un grupo de Departamentos
    
        public ICollection<Departamento> Departamentos { get; set; } 
    
    */
}
