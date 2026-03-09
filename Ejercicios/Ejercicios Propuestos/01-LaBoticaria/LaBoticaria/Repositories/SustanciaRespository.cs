using Serilog;

namespace LaBoticaria.Repositories;

public class SustanciaRespository : ISustanciaRepository{
    
    private static readonly Lazy<SustanciaRespository> Lazy = new(() => new SustanciaRespository());
    
    public static SustanciaRespository Instance => Lazy.Value;

    private SustanciaRespository() { }

    private Dictionary<int, Sustancia> _porId = new();

    private int _idCounter;
    
    private readonly ILogger _logger = Log.ForContext<SustanciaRespository>();
    
    
    
    
    /// <inheritdoc cref="ISustanciaReposity.GetAll"/>
    public IEnumerable<Sustancia> GetAll() {
        _logger.Debug("Obtenemos a todas las sustancias");
        return _porId.Values;
    }
    
    /// <inheritdoc cref="ISustanciaRepository."/>
    public Sustancia? GetById(int id) {
        _logger.Debug("Obtenemos sustancia por Id {id}");
        return _porId.GetValueOrDefault(id);
    }

    public Sustancia? Create(Sustancia entity) {
        _logger.Debug("Creando una nueva sustancia {entity}", entity);
        
        if (_porId.ContainsKey(entity.Id)) return null;
        var nuevaSustancia = entity with {
            Id = ++_idCounter,
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            IsDeleted = false
        };
        
        _porId.Add(entity.Id, nuevaSustancia);
        return nuevaSustancia;
    }

    public Sustancia? Update(int id, Sustancia entity) {
        _logger.Debug("Actualizando una nueva sustancia con id {Id} y datos {entity}", id, entity);
        if (!_porId.TryGetValue(id, out var value)) return null;

        var sustanciaActualizada = entity with {
            Id = id,
            CreateAt = value.CreateAt,
            UpdateAt = DateTime.UtcNow,
            IsDeleted = false
        };
        
        _porId.Add(entity.Id, sustanciaActualizada);
        return sustanciaActualizada;
    }

    public Sustancia? Delete(int id, Sustancia entity) {
        _logger.Debug("Eliminando sustancia con Id {id}" );

        if (!_porId.TryGetValue(id, out var value)) return null;

        var sustanciaEliminada = entity with {
            UpdateAt = value.UpdateAt,
            IsDeleted = true
        };

        return sustanciaEliminada;
    }
}