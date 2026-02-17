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

       var actualizado = repository.GetById(id, contrato) ?? throw new ContratoException.NotFound(id.ToString());

       cache.Remove(id);

       return actualizado;

    }

    public ContratoBase Delete(int id) {
        throw new NotImplementedException();
    }

    public InformeContratos GenerarInformeContratos() {
        throw new NotImplementedException();
    }

    private void ValidarPersonaConLogicaPolimorfica(ContratoBase c) {
        var errores = c switch {
            ContratoMonstruo => valContratoMonstruo.Validar(c),
            ContratoAsalto => valContratoAsalto.Validar(c)
            _ => ["Tipo de contrato no soportado para la validación."]

        };

        if (errores.Any()) {
            _log.Warning("Errores de validacion encontrados: {errores}", errores);
            throw new Validation(errores);
        }
    }
}