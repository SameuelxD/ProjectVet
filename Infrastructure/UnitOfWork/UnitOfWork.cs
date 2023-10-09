using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly VetContext _context;
    private PaisRepository _paises;
    private CiudadRepository _ciudades;
    private DepartamentoRepository _departamentos;
    private ClienteRepository _clientes;
    private MascotaRepository _mascotas;
    private RazaRepository _razas;
    private CitaRepository _citas;
    private ClienteTelefonoRepository _clientestelefono;
    private ClienteDireccionRepository _clientesdireccion;
    private ServicioRepository _servicios;
    
    public IPaisRepository Paises
    {
        get
        {
            if (_paises == null)
            {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }

    public ICiudadRepository Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }

    public IClienteRepository Clientes
    {
        get
        {
            if (_clientes == null)
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }

    public IDepartamentoRepository Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }

    public IMascotaRepository Mascotas
    {
        get
        {
            if (_mascotas == null)
            {
                _mascotas = new MascotaRepository(_context);
            }
            return _mascotas;
        }
    }

    public IRazaRepository Razas
    {
        get
        {
            if (_razas == null)
            {
                _razas = new RazaRepository(_context);
            }
            return _razas;
        }
    }

    public IServicioRepository Servicios
    {
        get
        {
            if (_servicios == null)
            {
                _servicios = new ServicioRepository(_context);
            }
            return _servicios;
        }
    }

    public IClienteTelefonoRepository ClientesTelefono
    {
        get
        {
            if (_clientestelefono == null)
            {
                _clientestelefono = new ClienteTelefonoRepository(_context);
            }
            return _clientestelefono;
        }
    }

    public IClienteDireccionRepository ClientesDireccion
    {
        get
        {
            if (_clientesdireccion == null)
            {
                _clientesdireccion = new ClienteDireccionRepository(_context);
            }
            return _clientesdireccion;
        }
    }
    public ICitaRepository Citas
    {
        get
        {
            if (_citas == null)
            {
                _citas = new CitaRepository(_context);
            }
            return _citas;
        }
    }

    public UnitOfWork(VetContext context)
    {
        _context = context;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
