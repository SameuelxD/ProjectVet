using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IPaisRepository Paises { get; }
        ICiudadRepository Ciudades { get; }
        ICitaRepository Citas { get; }
        IClienteRepository Clientes { get; }
        IDepartamentoRepository Departamentos { get; }
        IMascotaRepository Mascotas { get; }
        IRazaRepository Razas { get; }
        IServicioRepository Servicios { get; }
        IClienteTelefonoRepository ClientesTelefono { get; }
        IClienteDireccionRepository ClientesDireccion { get; }
        Task<int> SaveAsync();
    }
}