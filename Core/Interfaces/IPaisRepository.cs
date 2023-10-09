using Core.Entities;

namespace Core.Interfaces
{
    public interface IPaisRepository : IGenericRepository<Pais>
    {
        
    }
}

/* En cada interface vamos a definir metodos que son llamados contratos , que no van a tener definida una funcionalidad y vamos a crear una clase que va a implentar los metodos de una interface */