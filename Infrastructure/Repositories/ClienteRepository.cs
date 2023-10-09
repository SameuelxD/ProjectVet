using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;


namespace Infrastructure.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
         private readonly VetContext _context;

        public ClienteRepository(VetContext context) : base(context)
        {   
            _context = context;
        }
    }
}
    
