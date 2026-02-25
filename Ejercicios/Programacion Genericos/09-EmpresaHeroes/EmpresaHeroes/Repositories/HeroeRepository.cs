using EmpresaHeroes.Models;
using Serilog;

namespace EmpresaHeroes.Repositories;

public class HeroeRepository : IHeroeRepository {
    
    private static readonly Lazy<HeroeRepository> lazy = new Lazy<HeroeRepository>(() => new HeroeRepository());

    private readonly Dictionary<int, Heroe> _porHeroe = new();
    
    private readonly ILogger _log = Log.ForContext<HeroeRepository>();

    private int _idCounter;
    
    private HeroeRepository() { }
    
    public static HeroeRepository Instance => lazy.Value;
    
    
    
    public IEnumerable<Heroe> GetAll() {
        _log.Debug("Getting all heroes");
        return _porHeroe.Values;
    }

    public Heroe? GetByID(int id) {
        _log.Debug("Obteniendo herore por Id {id} ", id);
        return _porHeroe.GetValueOrDefault(id);
    }

    public Heroe? Create(Heroe entity) {
        _log.Debug("Creando nuevo heroe {entity}", entity);

        var nuevoHeroe = entity with {
            Id = ++_idCounter,
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            IsDeleted = false

        };
        _porHeroe[nuevoHeroe.Id] = nuevoHeroe;
        return nuevoHeroe;
    }

    public Heroe? Update(int id, Heroe entity) {
        _log.Debug("Actualizando heroe {id} con datos {Heroe} ", id, entity);

        if (!_porHeroe.TryGetValue(id, out var actual)) return null;

        var heroeActualizado = entity with {
            Id = id,
            CreateAt = actual.CreateAt,
            UpdateAt = DateTime.UtcNow,
            IsDeleted = false
        };
        
        _porHeroe[id] = heroeActualizado;
        return heroeActualizado;
    }

    public Heroe? Delete(int id) {
       _log.Debug("Eliminado heore con id {id}", id);
       if (!_porHeroe.Remove(id, out var heroe)) return  null;
       
       _porHeroe.Remove(id);

       return heroe with {
           IsDeleted = true,
           UpdateAt = DateTime.UtcNow
       };
    }
}