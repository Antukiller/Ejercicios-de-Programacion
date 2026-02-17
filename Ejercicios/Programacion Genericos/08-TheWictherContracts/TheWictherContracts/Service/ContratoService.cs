using Serilog;
using TheWictherContracts.Cache;
using TheWictherContracts.Exceptions;
using TheWictherContracts.Models;
using TheWictherContracts.Repositories;
using TheWictherContracts.Validator.Common;

namespace TheWictherContracts.Service;

public class ContratoService(
    IContratoRepository repository,
    IValidador<ContratoBase> valContratoMonstruo,
    IValidador<ContratoBase> valContratoAsalto,
    ICache<int, ContratoBase> cache) : IContratoService {

    private readonly ILogger _log = Log.ForContext<ContratoService>();

    public int TotalContratos => repository.GetAll().Count();
    
    public IEnumerable<ContratoBase> GetAll() {
        _log.Information("Obteniendo todos los contratos");
        return repository.GetAll();
    }

    public ContratoBase GetById(int id) {
        _log.Information("Obteniendo contrato por Id {id}", id);
        var cached = cache.Get(id);
        if (cached != null)
            return cached;

        var contrato = repository.GetById(id) ?? throw new ContratoException.NotFound(id.ToString());
        
        cache.Add(id, contrato);

        return contrato;
    }

    public ContratoBase Save(ContratoBase contrato) {
        _log.Information("Guardando nuevo contrato: {contrato}", contrato);
        
        ValidarPersonaConLogicaPolimorfica(contrato);

        var nuevoContrato = repository.Create(contrato) ?? throw new AlreadyExists(contrato.id.ToString());

        return nuevoContrato;
    }

    public ContratoBase Update(int id, ContratoBase contrato) {
       _log.Information("Actualizando contrato con Is {id}: {contrato}", id, contrato);
       
       ValidarPersonaConLogicaPolimorfica(contrato);

       var actualizado = repository.Update(id, contrato) ?? throw new ContratoException.NotFound(id.ToString());

       cache.Remove(id);

       return actualizado;

    }

    public ContratoBase Delete(int id) {
        _log.Information("Eliminando contrato: {id}", id);
        var eliminado = repository.Delete(id) ??  throw new ContratoException.NotFound(id.ToString());
        cache.Remove(id);
        return eliminado;
    }

    public InformeContratos GenerarInforme(IEnumerable<ContratoBase> contratos) {
        var lista = contratos.ToList(); // Para no recorrerla varias veces

        return new InformeContratos {
            TotalContratos = lista.Count,
            PorRecompensa = lista.OrderByDescending(c => c.recompensa),
            ContratosElite = lista.Count(c => c.nivelRecomendado >= 30),
            ContratosBasicos = lista.Count(c => c.nivelRecomendado < 15),
            TesoroTotal = lista.Sum(c => c.recompensa),
            NivelMedio = lista.Any() ? lista.Average(c => c.nivelRecomendado) : 0
        };
    }
    
    

    private void ValidarPersonaConLogicaPolimorfica(ContratoBase c) {
        var errores = c switch {
            ContratoMonstruo => valContratoMonstruo.Validar(c),
            ContratoAsalto => valContratoAsalto.Validar(c),
            _ => ["Tipo de contrato no soportado para la validación."]

        };

        if (errores.Any()) {
            _log.Warning("Errores de validacion encontrados: {errores}", errores);
            throw new Validation(errores);
        }
    }
}