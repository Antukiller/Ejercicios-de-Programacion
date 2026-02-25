using Serilog;
using Serilog.Core;
using SistemaGestiónNarutoWorld.Models;

namespace SistemaGestiónNarutoWorld.Repositories;

public class ShinobiRepository  : IShinobiRepository {
    private static readonly Lazy<ShinobiRepository> Lazy = new(() => new ShinobiRepository());

    private readonly Dictionary<string, int> _dniNinja = new();

    private readonly ILogger _logger = Log.ForContext<ShinobiRepository>();


    private readonly Dictionary<int, Shinobi> _porId = new();

    private int _idCounter;
    
    private ShinobiRepository() { }

    public static ShinobiRepository Instance => Lazy.Value;
    
    
    public IEnumerable<Shinobi> GetAll() {
        _logger.Debug("Obteniendo todos los ninjas");
        return _porId.Values;
    }

    public Shinobi? GetById(int id) {
        _logger.Debug($"Obteniendo ninja con id {id}");
        return _porId.GetValueOrDefault(id);
    }

    public Shinobi? Create(Shinobi entity) {
        _logger.Debug("Creando nuevo ninja {entity}", entity);
        if (ExisteDniNinja(entity.DniNinja)) return null;

        var nuevoNinja = entity with {
            Id = ++_idCounter,
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            IsDeleted = false
        };

        _porId[nuevoNinja.Id] = nuevoNinja;
        _dniNinja[nuevoNinja.DniNinja] = nuevoNinja.Id;
        return nuevoNinja;

    }

    public Shinobi? Update(int id, Shinobi entity) {
       _logger.Debug("Actualizando ninja con id {Id} con datos {Shinobi}", id, entity);

       if (!_porId.TryGetValue(id, out var actual)) return null;

       var ninjaActualizado = entity with {
           Id = id,
           CreateAt = actual.CreateAt,
           UpdateAt = DateTime.UtcNow,
           IsDeleted = false
       };

       _porId[id] = ninjaActualizado;

       if (actual.DniNinja != ninjaActualizado.DniNinja) {
           _dniNinja.Remove(actual.DniNinja);
           _dniNinja[ninjaActualizado.DniNinja] = id;
       }

       return ninjaActualizado;
    }

    public Shinobi? Delete(int id) {
        _logger.Debug($"Eliminando persona con id {id}");

        if (!_porId.Remove(id, out var shinobi)) return null;

        _dniNinja.Remove(shinobi.DniNinja);

        return shinobi with {
            IsDeleted = true,
            UpdateAt = DateTime.UtcNow
        };
    }

    public Shinobi? GetByDniNinja(string dniNinja) {
        _logger.Debug($"Obteniendo ninja con DNI {dniNinja}");
        return _dniNinja.TryGetValue(dniNinja, out var id) && _porId.TryGetValue(id, out var shinobi)
            ? shinobi
            : null;
    }

    public bool ExisteDniNinja(string dniNinja) {
        return _dniNinja.ContainsKey(dniNinja);
    }
}