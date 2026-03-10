using LaBoticaria.Cache;
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
    IValidador<Sustancia> valMedcina,
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
        
        
    }

    public Sustancia UpdateSustancia(int id, Sustancia sustancia) {
        throw new NotImplementedException();
    }

    public Sustancia DeleteSustancia(int id) {
        throw new NotImplementedException();
    }

    public InformeSustancias GenerarInformeSustancias() {
        throw new NotImplementedException();
    }

    public IEnumerable<CasoMedico> GetAllCasoMedicos() {
        throw new NotImplementedException();
    }

    public CasoMedico GetByIdCasoMedico(int id) {
        throw new NotImplementedException();
    }

    public CasoMedico SaveCasoMedico(CasoMedico casoMedico) {
        throw new NotImplementedException();
    }

    public CasoMedico UpdateCasoMedico(int id, CasoMedico casoMedico) {
        throw new NotImplementedException();
    }

    public CasoMedico DeleteCasoMedico(int id) {
        throw new NotImplementedException();
    }

    public InformeCasosMedicos GenerarInformeCasosMedicos() {
        throw new NotImplementedException();
    }

    
    
    
    private void ValidarBoticariaConLogicaPolimorfica(Sustancia sustancia, CasoMedico casoMedico) {

        var sustanciaErrors = sustancia switch {
            Medicina => valMedcina.Validar(sustancia),
            Afrodisiacos => valAfrodisiaco.Validar(sustancia),
            Veneno => valVeneno.Validar(sustancia),
            _ => ["Tipo de entidad no soportada para validación"]
        };

        if (sustanciaErrors.Any()) {
            _logger.Warning("Errores de validacion encontrado: {errors}", sustanciaErrors);
            throw new SustanciaException.Validation(sustanciaErrors);
        }
        
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


}