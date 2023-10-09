using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamentoRepository
    {
         private readonly VetContext _context;

        public DepartamentoRepository(VetContext context) : base(context)
        {
            _context = context;
        }
    }
}
    
