using EmpresaHeroes.Cache;
using EmpresaHeroes.Enums;
using EmpresaHeroes.Exceptions.Common;

namespace EmpresaHeroes.Service;

using EmpresaHeroes.Models;
using EmpresaHeroes.Repositories;
using EmpresaHeroes.Validator.Common;
using EmpresaHeroes.Exceptions; // Asumiendo que crearás excepciones personalizadas
using Serilog;

/// <summary>
/// Servicio integral para la gestión de héroes y misiones.
/// Implementa lógica de negocio mediante pipelines funcionales y estrategias de ordenamiento.
/// </summary>
public class HeroesService(
    IHeroeRepository repository,
    IValidador<Heroe> valGuerrero,
    IValidador<Heroe> valMago,
    IValidador<Heroe> valArquero,
    ICache<int, Heroe> cache) : IHeroesService {

    private readonly ILogger _log = Log.ForContext<HeroesService>();

    public int TotalHeroes => repository.GetAll().Count();

    // --- CONSULTAS Y RANKINGS ---

    public IEnumerable<Heroe> GetAll() {
        _log.Information("Obteniendo listado completo de héroes.");
        return repository.GetAll();
    }

    public IEnumerable<Heroe> GetHeroesOrderBy(TipoOrdenamiento orden = TipoOrdenamiento.Nombre) {
        _log.Information("Generando ranking de héroes ordenado por {orden}.", orden);

        var lista = repository.GetAll();

        // MAPA DE ESTRATEGIAS (Open/Closed Principle)
        var comparadores = new Dictionary<TipoOrdenamiento, Func<IEnumerable<Heroe>>> {
            { TipoOrdenamiento.Nombre, () => lista.OrderBy(h => h.Nombre) },
            { TipoOrdenamiento.Nivel, () => lista.OrderByDescending(h => h.Nivel) },
            { TipoOrdenamiento.PoderTotal, () => lista.OrderByDescending(h => h.CalcularPoderTotal()) },
            { TipoOrdenamiento.Energia, () => lista.OrderBy(h => h.Energia) },
            { TipoOrdenamiento.Experiencia, () => lista.OrderByDescending(h => h.Experiencia) }
        };

        return comparadores.TryGetValue(orden, out var estrategia) 
            ? estrategia() 
            : lista.OrderBy(h => h.Nombre);
    }

    // --- OPERACIONES CRUD ---

    public Heroe Save(Heroe heroe) {
        _log.Information("Registrando nuevo héroe: {Nombre}", heroe.Nombre);
        
        ValidarHeroePolimorfico(heroe);
        
        var nuevo = repository.Create(heroe) ?? throw new HeroeException.AlreadyExists(heroe.Nombre);
        return nuevo;
    }

    public Heroe GetById(int id) {
        _log.Information("Buscando héroe con ID {id}", id);

        // Intento recuperar de caché (LRU)
        var cached = cache.Get(id);
        if (cached != null) return cached;

        // Si no está, voy al repositorio
        var heroe = repository.GetByID(id) ?? throw new HeroeException.NotFound(id.ToString());
        
        cache.Add(id, heroe);
        return heroe;
    }

    public Heroe Update(int id, Heroe heroe) {
        _log.Information("Actualizando héroe ID {id}", id);
        
        ValidarHeroePolimorfico(heroe);
        
        var actualizado = repository.Update(id, heroe) ?? throw new HeroeException.NotFound(id.ToString());
        cache.Remove(id); // Invalidar caché tras actualización
        return actualizado;
    }

    public Heroe Delete(int id) {
        _log.Information("Eliminando héroe ID {id}", id);
        var eliminado = repository.Delete(id) ?? throw new HeroeException.NotFound(id.ToString());
        cache.Remove(id);
        return eliminado;
    }
// --- BÚSQUEDAS ESPECÍFICAS ---

    public IEnumerable<Heroe> BuscarPorNombre(string nombre) {
        _log.Information("Buscando héroes que contengan: {nombre}", nombre);
    
        // Filtro funcional con Case Insensitive
        return repository.GetAll()
            .Where(h => h.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Heroe> ObtenerPorNivelMinimo(int nivel) {
        _log.Information("Filtrando héroes con nivel >= {nivel}", nivel);
    
        return repository.GetAll()
            .Where(h => h.Nivel >= nivel)
            .OrderByDescending(h => h.Nivel);
    }

// --- LÓGICA DE ESTADO (ENTRENAR/DESCANSAR) ---

    public void EntrenarHeroe(int id) {
        _log.Information("Intentando entrenar al héroe ID: {id}", id);
    
        var heroe = GetById(id); // Usa el GetById del servicio que ya maneja caché
    
        // Ejecutamos la lógica interna del modelo
        heroe.Entrenar();
    
        // Persistimos el cambio
        repository.Update(id, heroe);
        cache.Remove(id); // Forzamos que la próxima lectura sea del repo actualizado
    
        _log.Debug("Entrenamiento completado para {nombre}. Poder Base actual: {pb}", heroe.Nombre, heroe.PoderBase);
    }

    public void DescansarHeroe(int id) {
        _log.Information("Héroe ID {id} entrando en descanso.", id);
    
        var heroe = GetById(id);
        heroe.Descansar();
    
        repository.Update(id, heroe);
        cache.Remove(id);
    }

// --- RANKINGS ---

    public IEnumerable<Heroe> GetTopPoderosos() {
        _log.Information("Generando TOP 10 de héroes más poderosos.");
    
        // Usamos el pipeline para ordenar y tomar los mejores
        return repository.GetAll()
            .OrderByDescending(h => h.CalcularPoderTotal())
            .Take(10);
    }

    // --- LÓGICA DE MISIONES ---

    public ResultadoMision ResolverMision(Mision mision) {
        _log.Information("Iniciando simulación de misión: {Nombre} (Dificultad: {Dificultad})", 
            mision.Nombre, mision.Peligrosidad);

        if (!mision.Equipo.Any()) 
            throw new MisionException.InvalidOperation("El equipo de la misión no puede estar vacío.");

        // Cálculos mediante Pipeline funcional
        double poderTotal = mision.Equipo.Sum(h => h.CalcularPoderTotal());
        double umbral = (int)mision.Peligrosidad * 50.0;
        bool esExito = poderTotal >= umbral;

        // Actualización de los héroes participantes
        foreach (var heroe in mision.Equipo) {
            var hActualizado = esExito 
                ? heroe with { Experiencia = heroe.Experiencia + 10 } // Gana experiencia
                : heroe with { Energia = heroe.Energia - 20 };       // Pierde energía

            repository.Update(hActualizado.Id, hActualizado);
            cache.Remove(hActualizado.Id);
        }

        return new ResultadoMision {
            IsExito = esExito,
            EquipoParticipante = mision.Equipo,
            PoderTotalEquipo = poderTotal,
            UmbralRequerido = umbral,
            NivelMedioEquipo = mision.Equipo.Average(h => h.Nivel)
        };
    }

    // --- MÉTODOS PRIVADOS ---

    /// <summary>
    /// Selecciona y ejecuta el validador correcto según el tipo concreto del héroe.
    /// </summary>
    private void ValidarHeroePolimorfico(Heroe heroe) {
        var errores = heroe switch {
            Guerrero => valGuerrero.Validate(heroe),
            Mago => valMago.Validate(heroe),
            Arquero => valArquero.Validate(heroe),
            _ => new List<string> { "Tipo de héroe desconocido." }
        };

        if (errores.Any()) {
            _log.Warning("Fallo de validación para {Nombre}: {Errores}", heroe.Nombre, errores);
            throw new HeroeException.Validation(errores);
        }
    }
}