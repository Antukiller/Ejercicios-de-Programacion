using LaBoticaria.Cache;
using LaBoticaria.Enums;
using LaBoticaria.Exceptions;
using LaBoticaria.Repositories;
using LaBoticaria.Validator.Common;
using Serilog;

namespace LaBoticaria.Service;

public class ServiceGeneric(
    ISustanciaRepository repoSustancia,
    ICasosMedicosRepository repoCasosMedico,
    IValidador<Sustancia> valAfrodisiaco,
    IValidador<Sustancia> valVeneno, 
    IValidador<Sustancia> valMedicina,
    IValidador<CasoMedico> valCasoMedico,
    ICache<int, Sustancia>  cacheSustancia,
    ICache<int, CasoMedico> cacheCasoMedico) : IServiceGeneric {
    
    private readonly ILogger _logger = Log.ForContext<ServiceGeneric>();
    

    public int TotalSustancia => repoSustancia.GetAll().Count();

    public int TotalCasoMedico => repoCasosMedico.GetAll().Count();
    
    
    
    public IEnumerable<Sustancia> GetAllSustancias() {
        _logger.Information("Obteniendo todas las sustancias");
        return repoSustancia.GetAll();
    }

    public Sustancia GetByIdSustancia(int id) {
        _logger.Information("Obteniendo sustancia con Id {id}", id);
        
        var cached = cacheSustancia.Get(id);

        if (cached != null) 
            return cached;
        
        var sustancia  = repoSustancia.GetById(id) ?? throw new SustanciaException.NotFound(id.ToString());
        
        cacheSustancia.Add(id, sustancia);
        
        return sustancia;
    }

    public Sustancia SaveSustancia(Sustancia sustancia) {
        _logger.Information("Guardando nueva sustancia: {sustancia}", sustancia);

        ValidarSustanciaConLogicaPolimorfica(sustancia);

        var nueva = repoSustancia.Create(sustancia) ?? throw new CasoMedicoException.AlreadyExists(sustancia.Nombre);

        return nueva;
    }

    public Sustancia UpdateSustancia(int id, Sustancia sustancia) {
        _logger.Information("Actualizando sustancia con ID {id}: {sustancia}", id, sustancia);
        
        ValidarSustanciaConLogicaPolimorfica(sustancia);

        var actualizada = repoSustancia.Update(id, sustancia) ?? throw new SustanciaException.NotFound(id.ToString());

        cacheSustancia.Remove(id);

        return actualizada;
    }

    public Sustancia DeleteSustancia(int id, Sustancia sustancia) {
        _logger.Information("Eliminando sustancia con Id {id}", id);
        
        var eliminada = repoSustancia.Delete(id, sustancia ) ?? throw new SustanciaException.AlreadyExists(id.ToString());

        cacheSustancia.Remove(id);

        return eliminada;
    }

    public InformeSustancias GenerarInformeSustancias() {
        _logger.Information("Generando informe de sustancia");

        var sustancias = repoSustancia.GetAll()
            .Where(s => !s.IsDeleted)
            .OrderByDescending(s => s.CreateAt)
            .ToList();

        var total = sustancias.Count;

        return new InformeSustancias {
            TotalAfrodisiacos = sustancias.Count(s => s is Afrodisiacos),
            TotalVenenos = sustancias.Count(s => s is Veneno),
            TotalMedicinas = sustancias.Count(s => s is Medicina),

            PrecioMedio = total > 0 ? sustancias.Average(s => s.Precio) : 0,
            PrecioMaximo = total > 0 ? sustancias.Max(s => s.Precio) : 0
        };
    }

    public IEnumerable<CasoMedico> GetAllCasoMedicos() {
        _logger.Information("Obteniendo todos los casos medicos....");
        return repoCasosMedico.GetAll();
    }

    public CasoMedico GetByIdCasoMedico(int id) {
        _logger.Information("Obteniendo un caso medico por Id {id}", id);

        var cached = cacheCasoMedico.Get(id);

        if (cached != null)
            return cached;

        var casoMedico = repoCasosMedico.GetById(id) ?? throw new SustanciaException.AlreadyExists(id.ToString());
        
        cacheCasoMedico.Add(id, casoMedico);

        return casoMedico;
    }

    public CasoMedico SaveCasoMedico(CasoMedico casoMedico) {
        _logger.Information("Guardando un nuevo caso medico", casoMedico);
        
        ValidarCasoMedicoConLogicaPolimorfica(casoMedico);

        var nuevo = repoCasosMedico.Create(casoMedico) ?? throw new SustanciaException.AlreadyExists(casoMedico.Nombre);

        return nuevo;
    }

    public CasoMedico UpdateCasoMedico(int id, CasoMedico casoMedico) {
        _logger.Information("Actualizando el caso medico con Id {id} y datos {casoMedico}", id, casoMedico);
        
        ValidarCasoMedicoConLogicaPolimorfica(casoMedico);
        var actualizado = repoCasosMedico.Update(id, casoMedico) ?? throw new CasoMedicoException.NotFound(id.ToString());

        cacheCasoMedico.Remove(id);

        return actualizado;
    }

    public CasoMedico DeleteCasoMedico(int id, CasoMedico casoMedico) {
        _logger.Information("Eliminando caso medico con Id {id}", id);
        
        var eliminado = repoCasosMedico.Delete(id, casoMedico) ?? throw new CasoMedicoException.AlreadyExists(id.ToString());

        return eliminado;
    }
    public InformeCasosMedicos GenerarInformeCasosMedicos() {
        _logger.Information("Maomao está organizando los archivos médicos del Palacio...");

        // 1. Obtenemos todos los casos que NO están borrados lógicamente
        var todosLosCasos = repoCasosMedico.GetAll()
            .Where(c => !c.IsDeleted)
            .ToList();

        // 2. Separamos por estado para el Historial y los Activos
        var activos = todosLosCasos
            .Where(c => c.Investigacion != EstadoInvestigacion.Resuelto)
            .OrderByDescending(c => c.Transcendencia) // Los más graves primero
            .ToList();

        var resueltos = todosLosCasos
            .Where(c => c.Investigacion == EstadoInvestigacion.Resuelto)
            .OrderByDescending(c => c.UpdateAt)
            .ToList();

        // 3. Lógica para el síntoma más común (Aplanamos las tuplas con SelectMany)
        var sintomaTop = todosLosCasos
            .SelectMany(c => c.SintomasObservados)
            .GroupBy(s => s.Nombre)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault() ?? "Sin datos";

        // 4. Construimos el Informe
        return new InformeCasosMedicos {
            CasosActivos = activos,
            HistorialResueltos = resueltos,
        
            CasosCerrados = resueltos.Count,
            CasosEnCurso = activos.Count,

            // Contamos Casos Urgentes (Moderada o Grave según tu Enum)
            CasosUrgentes = activos.Count(c => c.Transcendencia >= Gravedad.Moderada),

            // Calculamos la media de síntomas por caso
            MediaSintomasPorCaso = todosLosCasos.Any() 
                ? todosLosCasos.Average(c => c.SintomasObservados.Count()) 
                : 0,

            SintomaMasComun = sintomaTop
        };
    }

    
    
    
    private void ValidarSustanciaConLogicaPolimorfica(Sustancia sustancia) {

        var sustanciaErrors = sustancia switch {
            Medicina => valMedicina.Validar(sustancia),
            Afrodisiacos => valAfrodisiaco.Validar(sustancia),
            Veneno => valVeneno.Validar(sustancia),
            _ => ["Tipo de entidad no soportada para validación"]
        };

        if (sustanciaErrors.Any()) {
            _logger.Warning("Errores de validacion encontrado: {errors}", sustanciaErrors);
            throw new SustanciaException.Validation(sustanciaErrors);
        }
        
    }


    private void ValidarCasoMedicoConLogicaPolimorfica(CasoMedico casoMedico) {
        // 2. Validar el Caso Médico
        // Aquí no necesitas switch, porque casoMedico siempre es de tipo CasoMedico
        var casoMedicoErrors = valCasoMedico.Validar(casoMedico);
    
        if (casoMedicoErrors.Any()) {
            _logger.Warning("Errores de validación en el caso médico: {errors}", casoMedicoErrors);
            // Imagino que tienes una excepción similar para casos
            throw new CasoMedicoException.Validation(casoMedicoErrors); 
        }
    }
        
        
    }

