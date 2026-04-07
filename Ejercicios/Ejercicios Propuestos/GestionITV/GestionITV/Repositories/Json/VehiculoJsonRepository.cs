using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using GestionITV.Config;
using GestionITV.Models;
using GestionITV.Repositories.Base;
using Serilog;

namespace GestionITV.Repositories.Json;

public class VehiculoJsonRepository : IVehiculoRepository {
    
    private static readonly Lazy<VehiculoJsonRepository> Lazy = new(() => new VehiculoJsonRepository());
    
    private readonly ILogger _logger =  Log.ForContext<VehiculoJsonRepository>();
    
    private readonly Dictionary<string,List<Vehiculo>> _dniPropietarioIndex = new();
    
    private readonly Dictionary<int, Vehiculo> _porId = new();

    private readonly string _filePath;

    private int _idCounter;
    
    
    // Opciones de serializaicion de Json
    // Nota Importante: Configuramos el serializador para que sea legible (WriteIndented)
    // y uso de camelCase en la propiedades (estándar en Json)

    private readonly JsonSerializerOptions _jsonOptions = new() {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };


    /// <summary>
    /// Constructor privado (requerido por Singleton)
    /// Inicializa el repositositorio y carga los datos existentes
    /// </summary>
    private VehiculoJsonRepository() {
        _logger.Debug("Inicializando repositorio JSON");
        // Obtenemos la ruta del archivo desde Configuracion (lee de appsetting.json)
        _filePath = Path.Combine(Configuracion.DataFolder, "vehiculos.json");
        EnsureDirectory();
        Load();
    }
    
    public static VehiculoJsonRepository Instance => Lazy.Value;


    private void EnsureDirectory() {
        var dir = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) {
            _logger.Debug("Creando directorio: {dir}", dir);
            Directory.CreateDirectory(dir);
        }
    }


    private void Load() {
        try {
            if (!File.Exists(_filePath)) {
                _logger.Information("Archivo Json no existe. Repositorio vacío");
                return;
            }
            
            var json = File.ReadAllText(_filePath);
            var vehiculos = JsonSerializer.Deserialize<List<Vehiculo>>(json, _jsonOptions);
            
            if (vehiculos == null) return;

            foreach (var v in vehiculos) {
                _porId[v.Id] = v;

                if (!_dniPropietarioIndex.TryGetValue(v.DniPropietario, out var list)) {
                    list = new List<Vehiculo>();
                    _dniPropietarioIndex[v.DniPropietario] = list;
                }
                list.Add(v);
                
                if (v.Id > _idCounter) _idCounter = v.Id;
            }
            
            _logger.Information("Cargados {count} registros desde Json.", _porId.Count);
        }
        catch (Exception ex) {
            _logger.Error(ex, "Error al cargar el archivo Json");
        }
    }


    private void Save() {
        try {
            var vehiculos = _porId.Values.ToList();
            var json = JsonSerializer.Serialize(vehiculos, _jsonOptions);
            File.WriteAllText(_filePath, json);
            _logger.Debug("Datos guardados en Json. Total:  {count}", vehiculos.Count);
        }
        catch (Exception ex) {
            _logger.Error(ex, "Error al guardar el archivo Json");
            throw;
        }
    }
    
    
    
    public IEnumerable<Vehiculo> GetAll() {
        return _porId.Values;
    }

    public Vehiculo? GetById(int id) {
        return _porId.GetValueOrDefault(id);
    }

    public Vehiculo? Create(Vehiculo entity) {
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
        Save();
        return nuevoVehiculo;
        
    }

    public Vehiculo? Update(int id, Vehiculo entity) {
        if (!_porId.TryGetValue(id, out var vehiculoViejo)) return null;

        if (_dniPropietarioIndex.TryGetValue(entity.DniPropietario, out var listaNueva) && listaNueva.Count >= 3) {
            _logger.Warning("Limite de vehiculos alcanzdo por el propietario...");
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
        }
        else {
            var lista = _dniPropietarioIndex[vehiculoViejo.DniPropietario];
            int indice = lista.FindIndex(x => x.Id == id);
            lista[indice] = vehiculoActualizado;
        }
        Save();
        return vehiculoActualizado;
    }

    public Vehiculo? Delete(int id) {
        if (!_porId.TryGetValue(id, out var vehiculo)) return null;

        var vehiculoEliminado = vehiculo with {
            IsDeleted = true,
            UpdateAt = DateTime.UtcNow
        };
        
        _porId[id] = vehiculoEliminado;

        var lista = _dniPropietarioIndex[vehiculo.DniPropietario];
        int indice  = lista.FindIndex(x => x.Id == id);
        if (indice != -1) {
            lista[indice] = vehiculoEliminado;
        }
        
        Save();
        return vehiculoEliminado;
    }

    public IEnumerable<Vehiculo>? GetByDniPropietario(string dni) {
       if (!_dniPropietarioIndex.TryGetValue(dni, out var listaVehiculo)) return listaVehiculo.Where(v => !v.IsDeleted);
       return Enumerable.Empty<Vehiculo>();
    }

    public bool ExisteDni(string dni) {
        return _dniPropietarioIndex.ContainsKey(dni);
    }

    public bool DeleteAll() {
        _porId.Clear();
        _dniPropietarioIndex.Clear();
        _idCounter = 0;

        if (File.Exists(_filePath)) {
            File.Delete(_filePath);
        }
        
        _logger.Information("Repositorio Json limpiado");
        return true;
    }
}