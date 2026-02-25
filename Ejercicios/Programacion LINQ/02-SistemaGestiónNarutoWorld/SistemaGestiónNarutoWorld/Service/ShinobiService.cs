using Serilog;
using SistemaGestiónNarutoWorld.Cache;
using SistemaGestiónNarutoWorld.Enums;
using SistemaGestiónNarutoWorld.Exceptions;
using SistemaGestiónNarutoWorld.Models;
using SistemaGestiónNarutoWorld.Repositories;
using SistemaGestiónNarutoWorld.Validator.Common;

namespace SistemaGestiónNarutoWorld.Service;

public class ShinobiService(
    IShinobiRepository repository,
    IValidador<ShinobiElite> valShinobiElite,
    IValidador<ShinobiRastreador> valShinobiRastreador,
    IValidador<Jinchuriki> valJinchuriki,
    ICache<int, Shinobi> cache) : IShinobiService {

    private readonly ILogger _logger = Log.ForContext<ShinobiService>();


    public Shinobi? ObtenerPorDni(string dni) {
        var shinobi = repository.GetByDniNinja(dni) ?? throw new ShinobiException.NotFound(dni);
        return shinobi;
        
    }
    

    public IEnumerable<Shinobi> ObtenerPorAldea(AldeaNinja aldea) {
        repository.GetAll()
            .Where(s => s.Aldea == aldea);
    }

    public IEnumerable<Shinobi> ObtenerNinjasDeAltoNivel(double umbral) {
        repository.GetAll()
            .Where(s => is Jinchuriki j )
    }

    public double ObtenerMediaControlJinchurikis(AldeaNinja aldea) {
        throw new NotImplementedException();
    }

    public IEnumerable<Shinobi> BuscarPorNombre(string prefijo) {
        throw new NotImplementedException();
    }

    public IEnumerable<IGrouping<AldeaNinja, Shinobi>> AgruparPorAldea() {
        throw new NotImplementedException();
    }

    public Shinobi? ObtenerNinjaMasPoderoso() {
        throw new NotImplementedException();
    }

    public IEnumerable<Shinobi> ObtenerRankingPorEdad() {
        throw new NotImplementedException();
    }

    public IEnumerable<Shinobi> ObtenerPagina(int numeroPagina, int tamañoPagina) {
        throw new NotImplementedException();
    }

    public IEnumerable<Shinobi> ObtenerAltasRecientes() {
        throw new NotImplementedException();
    }

    public IEnumerable<Shinobi> ObtenerModificadosRecientemente() {
        throw new NotImplementedException();
    }
}