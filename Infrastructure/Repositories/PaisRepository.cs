using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PaisRepository : GenericRepository<Pais>, IPaisRepository
    {
        private readonly VetContext _context;
        public PaisRepository(VetContext context) : base(context)
        {
            _context = context;
        }

        //Metodo para obtener todos los paise , metodo sobrescrito
        public override async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises.Include(p => p.Departamentos).ThenInclude(c => c.Ciudades).ToListAsync();
        }   /* Lo que estamos miticando es que cuando enliste los paises me incluya los departamentos y dentro de los departamentos me incluya las ciudades que pertencen a ese departamento , aqui obtenemos paises ,departamentos y las ciudades que estan asociadas a cada departamento */

        public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Paises as IQueryable<Pais>;
            if(!string.IsNullOrEmpty(search))
            {
                query=query.Where(p => p.NombrePais.ToLower().Contains(search));
            }
            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query.Include(u => u.Departamentos).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return (totalRegistros , registros);
        }
    }
}
/* Para el reposiorio de Pais , PaisRepository , una vez declarado sus metodos , reutilizado y sobrescribido tenderemos que generar su controlador , PaisController */

/* Para nuestros controladores van a tener la misma ruta y van a heredar del controlador base , vamos a crear una clase que me permita heredar estos dos elementos de clase ,    */