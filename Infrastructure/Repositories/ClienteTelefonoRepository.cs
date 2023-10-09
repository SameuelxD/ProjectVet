using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;


namespace Infrastructure.Repositories
{
    public class ClienteTelefonoRepository : GenericRepository<ClienteTelefono>, IClienteTelefonoRepository
    {
         private readonly VetContext _context;

        public ClienteTelefonoRepository(VetContext context) : base(context)
        {
            _context = context;
        }
    }
}
    
