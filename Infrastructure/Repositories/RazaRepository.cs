using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RazaRepository : GenericRepository<Raza>, IRazaRepository
    {
         private readonly VetContext _context;

        public RazaRepository(VetContext context) : base(context)
        {
            _context = context;
        }
    }
}
    
