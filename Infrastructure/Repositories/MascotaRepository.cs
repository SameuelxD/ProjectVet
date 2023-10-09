using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;


namespace Infrastructure.Repositories
{
    public class MascotaRepository : GenericRepository<Mascota>, IMascotaRepository
    {
         private readonly VetContext _context;

        public MascotaRepository(VetContext context) : base(context)
        {
            _context = context;
        }
    }
}
    
