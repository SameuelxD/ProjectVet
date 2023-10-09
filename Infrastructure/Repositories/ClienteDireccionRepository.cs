using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;


namespace Infrastructure.Repositories
{
    public class ClienteDireccionRepository : GenericRepository<ClienteDireccion>, IClienteDireccionRepository
    {
         private readonly VetContext _context;

        public ClienteDireccionRepository(VetContext context) : base(context)
        {
            _context = context;
        }
    }
}
    
