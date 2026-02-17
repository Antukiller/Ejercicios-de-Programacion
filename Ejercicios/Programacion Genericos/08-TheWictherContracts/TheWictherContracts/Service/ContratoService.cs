using Serilog;
using TheWictherContracts.Cache;
using TheWictherContracts.Collections;
using TheWictherContracts.Enums;
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
        
        ValidarContratoConLogicaPolimorfica(contrato);

        var nuevoContrato = repository.Create(contrato) ?? throw new AlreadyExists(contrato.id.ToString());

        return nuevoContrato;
    }

    public ContratoBase Update(int id, ContratoBase contrato) {
       _log.Information("Actualizando contrato con Is {id}: {contrato}", id, contrato);
       
       ValidarContratoConLogicaPolimorfica(contrato);

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

    public InformeMonstruo GenerarInformeMonstruos(EspecieCriatura? especie = null) {
        _log.Information("Generando informe de monstruos con ILista Extensions");

        // 1. Obtenemos todos y filtramos manualmente los que son Monstruos
        var todos = repository.GetAll(); // Esto devuelve tu ILista<ContratoBase>
        var soloMonstruos = new Lista<ContratoMonstruo>();
    
        foreach (var c in todos) {
            if (c is ContratoMonstruo m) {
                // Filtro por especie si se proporciona
                if (especie == null || m.Monstruo == especie)
                    soloMonstruos.AddLast(m);
            }
        }

        if (soloMonstruos.Size == 0) return new InformeMonstruo();

        // 2. Cálculos usando tus extensiones
        var total = soloMonstruos.Size;
        var sumaRecompensas = soloMonstruos.Sum(m => m.Recompensa);
    
        // Para el nivel más alto, podemos usar tu OrderBy y coger el último
        var ordenadosPorNivel = soloMonstruos.OrderBy(m => m.NivelRecomendado);
        var nivelMax = ordenadosPorNivel.GetAt(ordenadosPorNivel.Size - 1).NivelRecomendado;

        return new InformeMonstruo {
            Contratos = soloMonstruos.OrderBy(m => m.Recompensa), // Usando tu burbuja
            Total = total,
            RecompensaMedia = (double)sumaRecompensas / total,
            NivelMasAlto = nivelMax
        };
    }

    public InformeAsalto GenerarInformeAsaltos(bool? soloSigilo = null) {
        _log.Information("Generando informe de asaltos con ILista Extensions");

        var todos = repository.GetAll();
        var soloAsaltos = new Lista<ContratoAsalto>();

        foreach (var c in todos) {
            if (c is ContratoAsalto a) {
                if (soloSigilo == null || a.RequiereSigilo == soloSigilo)
                    soloAsaltos.AddLast(a);
            }
        }

        if (soloAsaltos.Size == 0) return new InformeAsalto();

        // Usamos tus métodos de extensión
        int total = soloAsaltos.Size;
        int enemigosTotales = soloAsaltos.Sum(a => a.NumeroEnemigos);
        int misionesSigilo = soloAsaltos.Count(a => a.RequiereSigilo);
    
        // Para la probabilidad media, como no tienes Average, sumamos y dividimos
        double sumaProbabilidades = 0;
        foreach(var a in soloAsaltos) {
            sumaProbabilidades += a.ProbabiidadExito();
        }

        return new InformeAsalto {
            Contratos = soloAsaltos,
            Total = total,
            TotalEnemigos = enemigosTotales,
            MisionesSigilo = misionesSigilo,
            ProbabilidadExitoMedia = sumaProbabilidades / total
        };
    }


    private void ValidarContratoConLogicaPolimorfica(ContratoBase c) {
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