namespace Core.Entities
{
    public class Raza : BaseEntity
    {
        public string NombreRaza { get; set; }
        public ICollection<Mascota> Mascotas { get; set; }
    }
}
