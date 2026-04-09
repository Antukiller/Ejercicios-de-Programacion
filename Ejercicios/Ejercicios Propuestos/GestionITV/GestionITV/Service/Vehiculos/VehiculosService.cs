using GestionITV.Cache;
using GestionITV.Config;
using GestionITV.Enum;
using GestionITV.Exceptions;
using GestionITV.Models;
using GestionITV.Repositories.Base;
using GestionITV.Service.Backup;
using GestionITV.Storage.Common;
using GestionITV.Validator.Common;
using Serilog;

namespace GestionITV.Service.Vehiculos;

public class VehiculosService(
    IVehiculoRepository repository,
    IStorage<Vehiculo> storage,
    IValidador<Vehiculo> validador,
    ICache<int, Vehiculo> cache,
    IBackupService backupService
) : IVehiculoService {
    private readonly ILogger _logger = Log.ForContext<VehiculosService>();
    private readonly IBackupService _backupService = backupService;


    public int TotalVehiculos => repository.GetAll().Count();
    
    
    public IEnumerable<Vehiculo> GetAll() {
        _logger.Information("Obteniendo todas las personas.");
        return repository.GetAll();
    }

    public IEnumerable<Vehiculo> GetAllOrderBy(TipoOrdenamiento orden = TipoOrdenamiento.DniPropietario, Predicate<Vehiculo>? filtro = null) {
        _logger.Information("Obteniendo todos vehículos ordenados por {orden} con filtro: {filtro}.", orden, filtro != null ? "si" : "no");

        var lista = filtro == null
            ? repository.GetAll()
            : repository.GetAll().Where(p => filtro(p));

        var comparadores = new Dictionary<TipoOrdenamiento, Func<IOrderedEnumerable<Vehiculo>>> {
            { TipoOrdenamiento.Id, () => lista.OrderBy(v => v.Id) },
            { TipoOrdenamiento.Matricula, () => lista.OrderBy(v => v.Matricula) },
            { TipoOrdenamiento.Marca, () => lista.OrderBy(v => v.Marca) },
            { TipoOrdenamiento.Modelo, () => lista.OrderBy(v => v.Modelo) },
            { TipoOrdenamiento.Cilindrada, () => lista.OrderBy(v => v.Cilindrada) },
            { TipoOrdenamiento.Motor, () => lista.OrderBy(v => v.Motor) },
            { TipoOrdenamiento.DniPropietario, () => lista.OrderBy(v => v.DniPropietario) },
        };
        return comparadores.TryGetValue(orden, out var comparador)
            ? comparador()
            : lista.OrderBy(v => v.Id);
    }

    public Vehiculo GetById(int id) {
        _logger.Information("Obteniendo vehículo con ID {id}", id);
        //LRU: Busacamos en la cache antes de buscar en la base de datos
        var cached = cache.Get(id);
        if (cached != null) {
            // Si está en la caché, lo devolvemos directamente 
            return cached;
        }
        // Si no está en la caché, buscamos en la base de datos. Si no existe, lanzamos excepción.
        var vehiculo = repository.GetById(id) ?? throw new VehiculoException.NotFound(id.ToString());
        //LRU: Añadimos a la caché para evitar la recarga del vehículo en el próximo GetById.
        cache.Add(id, vehiculo);
        // Devolvemos el vehículo encontrado
        return vehiculo;
    }

    public IEnumerable<Vehiculo> GetByDniPropietario(string dniPropietario) {
        _logger.Information("Obteniendo vehiculo con el DNI del propietario: {dniPropietario}", dniPropietario);
        // Buscamos en la base de datos directamente (no en la caché).
        var vehiculo =  repository.GetByDniPropietario(dniPropietario) ?? throw new VehiculoException.NotFound(dniPropietario);
        
        return vehiculo;
    }

    public Vehiculo Save(Vehiculo vehiculo) {
        _logger.Information("Guardando nuevo vehiculo: {vehiculo}", vehiculo);
        
        var nuevoVehiculo = repository.Create(vehiculo) ?? throw new VehiculoException.AlreadyExists(vehiculo.DniPropietario);
        
        return nuevoVehiculo;
    }

    public Vehiculo Update(int id, Vehiculo vehiculo) {
        _logger.Information("Modificando vehiculo con ID: {id}, {vehiculo}",id, vehiculo);
        // Actualizamos en la base de datos. Si no existe, lanzamos excepción.
        var vehiculoActualizado = repository.Update(id, vehiculo) ?? throw new VehiculoException.NotFound(id.ToString());
        // LRU: Eliminamos de la caché para forzar recarga en el próximo 
        cache.Remove(id);
        
        return vehiculoActualizado;
    }

    public Vehiculo Delete(int id) {
        _logger.Information("Eliminando vehiculo con ID: {id}", id);
        // Eliminamos de la base de datos. Si no existe, lanzamos excepción.
        var eliminado =  repository.Delete(id) ?? throw new VehiculoException.NotFound(id.ToString());
        // LRU: Eliminamos de la caché si existía.
        cache.Remove(id);
        return eliminado;
    }

    public IEnumerable<InformeVehiculo> GenerarTodosInformeVehiculo() =>
        repository.GetAll().Where(v => !v.IsDeleted).Select(ToInformeVehiculo);

    public InformeVehiculo GenerarInformeVehiculPorId(int id) =>
        ToInformeVehiculo(repository.GetById(id) ?? throw new Exception());
    

    public int ImportarDatos() {
       _logger.Information("Importando datos desde almacenamiento externo");
       try {
           var vehiculos = storage.Cargar(Configuracion.ItvFile);

           repository.DeleteAll();
           
           var contador = 0;
           foreach (var v in vehiculos) {
               Save(v);
               contador++;
           }
           _logger.Information("Importando datos con exitosamente. Total de vehículos: {count}", contador);
           return contador;
       }
       catch (Exception ex) {
           _logger.Error(ex, "Error al importar datos: {message}", ex.Message);
           throw new VehiculoException.StorageError(ex.Message);
       }
    }

    public int ExportarDatos() {
        _logger.Information("Exportando datos a almacenamiento externo.");
        try {
            // Nota Importante: No usamos .ToList() aquí.
            // Pasamose el flujo directamente del repositorio al storage.

            var vehiculo = repository.GetAll();
            var count = vehiculo.Count();
            
            _logger.Information("Exportando datos a almacenamiento externo. Total de vehículos: {count}", count);
            storage.Salvar(vehiculo, Configuracion.ItvFile);
            _logger.Information("Datos exportados correctamente a {file}.", Configuracion.ItvFile);
            return count;
        }
        catch (Exception ex) {
            _logger.Error(ex, "Error al exportar datos: {message}", ex.Message);
            throw new VehiculoException.StorageError(ex.Message);
        }
    }

    public string RealizarBackup() {
        _logger.Information("Realizando backup del sistema");
        var vehiculo = repository.GetAll();
        return _backupService.RealizarBackup(vehiculo);
    }

    public int RestaurarBackup(string archivoBackup) {
        _logger.Information("Restaurando backup desde:  {archivoBackup}", archivoBackup);
        var vehiculos = _backupService.RestaurarBackup(archivoBackup).ToList();
        
        repository.DeleteAll();
        
        var contador = 0;
        foreach (var v in vehiculos) {
            Save(v);
            contador++;
        }
        _logger.Information("Restauracion completa. Total registros: {count}", contador);
        return contador;
    }

    public IEnumerable<string> ListarBackups() {
        return _backupService.ListarBackups();
    }
    
    // Metodo privado para las funciones de 'InformeVehiculo'
    private InformeVehiculo ToInformeVehiculo(Vehiculo v) {
        return new InformeVehiculo {
            Id = v.Id,
            Matricula = v.Matricula,
            MarcaModelo = $"{v.Marca} {v.Modelo}",
            DatosMotor = $"{v.Cilindrada}L {v.Motor}",
            PropietarioDni = v.DniPropietario
        };
    } 
}