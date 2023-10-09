namespace API.Dtos
{
    public class CitaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int IdCliente { get; set; }
        public int IdMascota { get; set; }
        public int ServicioId  { get; set; }
    }
}