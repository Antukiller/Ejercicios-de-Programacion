using Serilog;

namespace LaBoticaria.Repositories;

public class CasosMedicosRepository : ICasosMedicosRepository {

    private static readonly Lazy<CasosMedicosRepository> Lazy = new(() => new CasosMedicosRepository());

    private static CasosMedicosRepository Instance = Lazy.Value;
    
    private CasosMedicosRepository() { }

    private Dictionary<int, CasoMedico> _porId = new();

    private int _idCounter;

    private readonly ILogger _logger = Log.ForContext<CasosMedicosRepository>();
    
    
    
    public IEnumerable<CasoMedico> GetAll() {
        _logger.Debug("Obteniendo todos los casos medicos");

        return _porId.Values.Where(c => c.IsDeleted == false);
    }

    public CasoMedico? GetById(int id) {
        _logger.Debug("Obteniendo caso medico por Id {id}", id);

        return _porId.GetValueOrDefault(id);
    }

    public CasoMedico? Create(CasoMedico entity) {
        _logger.Debug("Creando un caso medico {entity}", entity);

        if (_porId.ContainsKey(entity.Id)) return null;

        var nuevoCasoMedico = entity with {
            Id = ++_idCounter,
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            IsDeleted = false
        };

        return nuevoCasoMedico;
    }

    public CasoMedico? Update(int id, CasoMedico entity) {
        _logger.Debug("Actualizando caso medico con id {id} y datos {entity}", id, entity);

        if (!_porId.TryGetValue(id, out var medico)) return null;

        var casoMedicoActualizado = entity with {
            CreateAt = medico.CreateAt,
            UpdateAt = DateTime.UtcNow,
            IsDeleted = false
        };

        return casoMedicoActualizado;
    }

    public CasoMedico? Delete(int id, CasoMedico entity) {
        _logger.Debug("Eliminando caso medico con Id {id}", id);

        if (!_porId.TryGetValue(id, out var medico)) return null;

        var casoMedicoEliminado = entity with {
            UpdateAt = medico.UpdateAt,
            IsDeleted = true
        };

        return casoMedicoEliminado;
    }
}