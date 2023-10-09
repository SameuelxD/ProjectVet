using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CitaRepository : GenericRepository<Cita>, ICitaRepository
    {
         private readonly VetContext _context;

        public CitaRepository(VetContext context) : base(context)
        {
            _context = context;
        }
    }
}
    
