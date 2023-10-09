using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ServicioRepository : GenericRepository<Servicio>, IServicioRepository
    {
         private readonly VetContext _context;

        public ServicioRepository(VetContext context) : base(context)
        {
            _context = context;
        }
    }
}
    
