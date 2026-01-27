using One_Piece_World.Collections;
using One_Piece_World.Factory;
using Serilog;

namespace One_Piece_World.Repositories;

public class EntidadRepositoryListaEnlazadaPropia : IEntidadReposytory {
    private static EntidadRepositoryListaEnlazadaPropia? _instance;
    private static int _idCounter;
    private readonly ILista<Entidad> _listado = new Lista<Entidad>();
    private readonly ILogger _log = Log.ForContext<EntidadRepositoryListaEnlazadaPropia>();
    
    
    private EntidadRepositoryListaEnlazadaPropia() {
        _log.Debug("Creando instancia de EntidadRepository con herencia de One Piece");
    
        // Llamamos al método que poblará el mundo inicial
        InitDemoData();
    }

    private void InitDemoData() {
        _log.Information("Cargando datos iniciales del Grand Line...");

        // 1. Cargamos Piratas
        var piratas = PirataFactory.DemoData();
        foreach (var p in piratas) {
            // Al ser herencia, Create acepta al Pirata como Entidad
            this.Create(p);
        }

        // 2. Cargamos Marines
        var marines = MarineFactory.DemoData();
        foreach (var m in marines) {
            this.Create(m);
        }

        // 3. Cargamos Frutas
        var frutas = FrutaDelDiabloFactory.DemoData();
        foreach (var f in frutas) {
            this.Create(f);
        }

        _log.Information("Carga inicial completada. Total: {Count} entidades.", _listado.Contar());
    }
    
    
    
    
    public ILista<Entidad> GetAll() {
        _log.Debug("Obtener la lista de entidades");
        return _listado;
    }

    public Entidad? GetById(int id) {
        _log.Debug("Obteniendo entidad por Id: {Id}", id);
        for (var i = 0; i < _listado.Contar(); i++) {
            var item = _listado.Obtener(i);
            if (item?.Id == id && !item.IsDeleted) {
                return item;
            }
        } 
        return null;
    }

    public Entidad? Create(Entidad entity) {
        _log.Debug("Creando nueva entidad: {Entidad}", entity);
        if (Exists(entity)) {
            _log.Warning("La entidad ya existe: {Entidad}", entity);
            return null;
        }

        var saved = entity with {
            Id = GetNextId(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        _listado.AgregarFinal(saved);
        return saved;
    }

    public Entidad? Update(int id, Entidad entity) {
        _log.Debug("Modificando nueva entidad: {Entidad}", entity);
        var index = IndexOf(id);
        if (index == -1) {
            _log.Warning("No existe la entidad con Id {ID}", id);
            return null;
        }
        
        var item = _listado.Obtener(index);
        var actualizada = entity with {
            Id = id,
            UpdatedAt = DateTime.Now
        };
        _listado.Eliminar(index);
        _listado.Agregar(actualizada, index);
        
        return actualizada;
    }

    public Entidad? Delete(int id) {
        _log.Debug("Borrando entidad: {Entidad}", id);
        var entidad = GetById(id);
        if (entidad == null) {
            _log.Warning("No existe la entidad con Id {ID}", id);
            return null;
        }
        
        var item =  _listado.Obtener(id) with { IsDeleted = true };
        _listado.Eliminar(id);
        return item;
        
        //var item = entidad with { IsDeleted = true };
        //return Update(id,  item);
    }

    public int TotalEntidades => _listado.Contar();
    
    public static EntidadRepositoryListaEnlazadaPropia GetInstance() {
        return _instance ??= new EntidadRepositoryListaEnlazadaPropia();
    }
    
    
    private static int GetNextId() {
        return ++_idCounter;
    }
    
    
    private bool Exists(Entidad entidad) {
        _log.Debug("Comprobando existencia de la entidad: {Nombre}", entidad.NombreCompleto);
    
        // Al tener IEnumerator, podemos recorrer la lista de forma natural
        foreach (var item in _listado) {
            // 1. Saltamos los elementos borrados (Soft Delete)
            if (item.IsDeleted) continue;

            // 2. Comparamos por NombreCompleto (ignora mayúsculas/minúsculas)
            // Esto evita que "Monkey D. Luffy" y "monkey d. luffy" se registren dos veces
            if (item.NombreCompleto.Equals(entidad.NombreCompleto, StringComparison.OrdinalIgnoreCase)) {
                _log.Warning("Conflicto detectado: {Nombre} ya existe en el sistema", entidad.NombreCompleto);
                return true;
            }
        }
    
        return false;
    }
    
    private int IndexOf(int id) {
        _log.Debug("Buscando índice del alumno con id: {Id}", id);
        for (var i = 0; i < _listado.Contar(); i++)
            if (_listado.Obtener(i).Id == id)
                return i;
        return -1;
    }
}