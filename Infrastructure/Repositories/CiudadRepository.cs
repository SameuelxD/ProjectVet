using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudadRepository
    {
         private readonly VetContext _context;

        public CiudadRepository(VetContext context) : base(context)
        {
            _context = context;
        }
    }
}
    
