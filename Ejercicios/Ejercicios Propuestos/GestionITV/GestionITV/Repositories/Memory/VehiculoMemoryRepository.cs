using System.Runtime.InteropServices.JavaScript;
using GestionITV.Models;
using GestionITV.Repositories.Base;
using Serilog;

namespace GestionITV.Repositories.Memory;

public class VehiculoMemoryRepository : IVehiculoRepository{
    private static readonly Lazy<VehiculoMemoryRepository> Lazy = new Lazy<VehiculoMemoryRepository>(() => new VehiculoMemoryRepository());
    private  readonly ILogger _logger = Log.ForContext<VehiculoMemoryRepository>();

    private readonly Dictionary<string,List<Vehiculo>> _dniPropietarioIndex = new();
    
    private readonly Dictionary<int, Vehiculo> _porId = new();

    private int _idCounter;
    
    private VehiculoMemoryRepository() { }
    
    public static VehiculoMemoryRepository Instance = Lazy.Value;
    
    
    /// <inheritdoc cref="IVehiculosRepository.GetAll"/>
    public IEnumerable<Vehiculo> GetAll() {
        _logger.Debug("Obteniendo todos los vehiculos");
        return _porId.Values.Where(v => !v.IsDeleted);
    }

    /// <inheritdoc cref="ICrudRepository{TKey, TEntity}.GetById"/>
    public Vehiculo? GetById(int id) {
        _logger.Debug($"Obteniendo vehiculo con id {id}");
        return _porId.GetValueOrDefault(id);
    }

    /// <inheritdoc cref="ICrudRepository{int, Vehiculo}.Create"/>
    public Vehiculo? Create(Vehiculo entity) {
        _logger.Debug($"Creando nuevo vehiculo {entity}", entity);
        if (_dniPropietarioIndex.TryGetValue(entity.DniPropietario, out var listaActual)) {
            if (listaActual.Count >= 3) {
                return null;
            }
        }

        var nuevoVehiculo = entity with {
            Id = ++_idCounter,
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            IsDeleted = false
        };
        
        _porId[nuevoVehiculo.Id] = nuevoVehiculo;
        if (listaActual is null) {
            listaActual = new List<Vehiculo>();
            _dniPropietarioIndex[nuevoVehiculo.DniPropietario] = listaActual;
        }
        listaActual.Add(nuevoVehiculo);
        
        return nuevoVehiculo;
    }

    public Vehiculo? Update(int id, Vehiculo entity) {
        _logger.Debug("Modificando vehiculo con id {Id} con datos {Vehiculo}",id, entity);
        
        if (!_porId.TryGetValue(id, out var vehiculoViejo)) return null;

        if (_dniPropietarioIndex.TryGetValue(entity.DniPropietario, out var listaNueva) && listaNueva.Count >= 3) {
            _logger.Warning("Limite de vehiculos alcanzado por el propietario...");
            return null;
        }

        var vehiculoActualizado = entity with {
            Id = id,
            CreateAt = vehiculoViejo.CreateAt,
            UpdateAt = DateTime.UtcNow,
            IsDeleted = false
        };
        
        _porId[id] = vehiculoActualizado;

        if (vehiculoViejo.DniPropietario != vehiculoActualizado.DniPropietario) {
            _dniPropietarioIndex[vehiculoViejo.DniPropietario].Remove(vehiculoViejo);

            if (!_dniPropietarioIndex.TryGetValue(vehiculoActualizado.DniPropietario, out var listaNuevaDueño)) {
                listaNuevaDueño = new List<Vehiculo>();
                _dniPropietarioIndex[vehiculoActualizado.DniPropietario] = listaNuevaDueño;
            }
            listaNuevaDueño.Add(vehiculoActualizado);
        } else {
            var lista = _dniPropietarioIndex[vehiculoViejo.DniPropietario];
            int indice = lista.FindIndex(x => x.Id == id);
            lista[indice] = vehiculoActualizado;
        }
        return vehiculoActualizado;
    }

    public Vehiculo? Delete(int id) {
        _logger.Debug("Eliminando de vehiculo con  id {Id}", id);

        if (!_porId.TryGetValue(id, out var vehiculo)) return null;

        var vehiculoEliminado = vehiculo with {
            IsDeleted = true,
            UpdateAt = DateTime.UtcNow
        };
        
        _porId[id] = vehiculoEliminado;

        var lista = _dniPropietarioIndex[vehiculo.DniPropietario];
        int indice = lista.FindIndex(x => x.Id == id);
        if (indice != -1) {
            lista[indice] = vehiculoEliminado;
        }
        return vehiculoEliminado;
    }

    public IEnumerable<Vehiculo>? GetByDniPropietario(string dni) {
        _logger.Debug("Buscando vehiculos activos para el DNI {dni}", dni);
        if (_dniPropietarioIndex.TryGetValue(dni, out var listaVehiculo)) return listaVehiculo.Where(x => !x.IsDeleted);
        return Enumerable.Empty<Vehiculo>();
    }
    
    /// <inheritdoc cref="IVehiculoRepository.ExisteDni"/>
    public bool ExisteDni(string dni) {
        return _dniPropietarioIndex.ContainsKey(dni);
    }

    public bool DeleteAll() {
        _logger.Warning("Eliminando permanentemente todos los vehiculos");
        _porId.Clear();
        _dniPropietarioIndex.Clear();
        _idCounter = 0;
        return true;
    }
}