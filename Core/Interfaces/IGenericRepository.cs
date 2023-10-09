using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression); //Metodo que permite hacer busqedas atraves de expresiones LinQ
        Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search);   /*Ayuda a segmentar de una u otra manera la cantidad de registros que se genran en una peticion , pagina los registros de manera que sea organizado y controlado , me va a mostrar la pagina actual (pageIndex) y necesito que esa pagina contenga una cantidad de registros (pageSize) y finalmente me va a permitir hacer busquedas (search) sobre ese esquema de paginacion        
        */

        //Metodos para Manejar los regitros en el EndPoint

        void Add(T entity); // Agrega registros
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);  // Elimina Registros
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);  // Actualiza Registros
    }
}

/* Recordar que despues del IGenericRepository debo implementar la interface dentro del repositorio , dentro de Infrastructure/Repositorios , GenericRepository*/