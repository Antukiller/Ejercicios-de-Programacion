using Horizon_Forbidden_West.Collections;
using Horizon_Forbidden_West.Models;
using Serilog;

namespace Horizon_Forbidden_West.Repositories;

public class EntidadHorizonRepository : IEntidadHorizonRepository {
    private static readonly Lazy<EntidadHorizonRepository> _lazy = 
        new(() => new EntidadHorizonRepository());

    private readonly ILista<EntidadHorizon> _listado = new Lista<EntidadHorizon>();
    private readonly ILogger _log = Log.ForContext<EntidadHorizonRepository>();
    private int _idCounter;
    
    private EntidadHorizonRepository() { }

    public static EntidadHorizonRepository Instance => _lazy.Value;
    
    
    
    public ILista<EntidadHorizon> GetAll() {
        _log.Debug("Obteniendo todas las entidades de Horizon Zero Dawn");
        return _listado;
    }

    public EntidadHorizon? GetById(int id) {
        _log.Debug("Obteniendo todas las entidades por Id: {id}");
        return _listado.Find(e => e.Id == id);
    }

    public EntidadHorizon? Create(EntidadHorizon entity) {
        _log.Debug("Creando nueva entidad {entity}", entity);
        if (ExisteCodigoGaia(entity.CodigoGaia)) return null;

        var nuevaEntidad = entity with {
            Id = ++_idCounter,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsDeleted = false
        };
        
        _listado.AddLast(nuevaEntidad);
        return nuevaEntidad;
    }

    public EntidadHorizon? Update(int id, EntidadHorizon entity) {
        _log.Debug("Modificand entidad con {id} con datos {EntidadHorizon}", id, entity);
        var index = _listado.IndexOf(e => e.Id == id);
        
        if (index == -1) return null;
        
        var actual = _listado.GetAt(index);
        var entidadActulizada = entity with {
            Id = id,
            CreatedAt = actual.CreatedAt,
            UpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
        };
        _listado.RemoveAt(index);
        _listado.AddAt(index, entidadActulizada);
        return entidadActulizada;
    }

    public EntidadHorizon? Delete(int id) {
        _log.Debug("Eliminando la maquina, cazador o sabotedor con id: {id}");
        
        var index = _listado.IndexOf(e => e.Id == id);
        if (index == -1) return null;
        
        var entidadEliminado = _listado.GetAt(index);
        _listado.RemoveAt(index);
        return entidadEliminado with {
            IsDeleted = true,
            UpdatedAt = DateTime.UtcNow
        };
    }
 
    public EntidadHorizon? GetByCodigoGaia(string codigoGaia) {
        _log.Debug("Obteniendo todas las entidades por Codigo Gaia: {codigoGaia}");
        return _listado.Find(e => e.CodigoGaia == codigoGaia);
    }

    public bool ExisteCodigoGaia(string codigoGaia) {
        _log.Debug("Verificando existencia de Codigo Gaia {codigoGaia}");
        return GetByCodigoGaia(codigoGaia) != null;
    }
}