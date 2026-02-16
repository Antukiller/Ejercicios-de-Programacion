using Serilog;
using TheWictherContracts.Models;

namespace TheWictherContracts.Repositories;

public class ContratoRepository : IContratoRepository {
    private static readonly Lazy<ContratoRepository> Lazy = new(() => new ContratoRepository());

    private readonly Dictionary<int, ContratoBase> _porId = new();
    
    private readonly ILogger _log = Log.ForContext<ContratoRepository>();

    private int _idCounter;
    
    private ContratoRepository Instance => Lazy.Value;
    
    
    public IEnumerable<ContratoBase> GetAll() {
        _log.Debug("Obteniendo todo los contratos");
        return _porId.Values;
    }

    public ContratoBase? GetById(int id) {
        _log.Debug("Obteniendo todo los contratos por id {0}", id);
        return _porId.GetValueOrDefault(id);
    }

    public ContratoBase? Create(ContratoBase entity) {
        _log.Debug("Creando nuevo contrato {entity}", entity);

        var nuevoContrato = entity with {
            Id = ++_idCounter,
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            IsDeleted = false
        };
        _porId[nuevoContrato.Id] = nuevoContrato;
        return nuevoContrato;
    }

    public ContratoBase? Update(int id, ContratoBase entity) {
        _log.Debug("Modificando contrato con {id} con datos {Contrato}", id, entity);

        if (!_porId.TryGetValue(id, out var actual)) return null;

        var contratoActualizado = entity with {
            Id = id,
            CreateAt = actual.CreateAt,
            UpdateAt = DateTime.UtcNow,
            IsDeleted = false
        };
        _porId[id] = contratoActualizado;
        return contratoActualizado;
    }

    public ContratoBase? Delete(int id) {
        _log.Debug("Eliminando persona con Id {id}");

        if (!_porId.Remove(id, out var contrato)) return null;
        _porId.Remove(id);
        return contrato with {
            IsDeleted = true,
            UpdateAt = DateTime.UtcNow
        };
    }
}