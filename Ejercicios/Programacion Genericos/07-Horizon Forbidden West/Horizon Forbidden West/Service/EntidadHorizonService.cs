using Horizon_Forbidden_West.Collections;
using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Models;
using Horizon_Forbidden_West.Repositories;
using Horizon_Forbidden_West.Validator.Common;
using Serilog;

namespace Horizon_Forbidden_West.Service;

public class EntidadHorizonService(
    IEntidadHorizonRepository repository,
    IValidador<EntidadHorizon> valMaquina,
    IValidador<EntidadHorizon> valCazador,
    IValidador<EntidadHorizon> valSaboteador) : IEntidadHorizonService {
    
    private readonly ILogger _log = Log.ForContext<EntidadHorizonService>();



    public int TotalEntidades => repository.GetAll().Size;
    
    
    public ILista<EntidadHorizon> GetAll() {
        _log.Information("Obteniendo todas las entidades");
        return repository.GetAll();
    }

    public ILista<EntidadHorizon> GetAllOrdeBy(TipoOrdenamiento orden = TipoOrdenamiento.CodigoGaia, Predicate<EntidadHorizon>? filtro = null) {
        _log.Information("Obteniendo todas las entidades ordenadad por {orden} con filtro: {filtro}", orden, filtro != null ? "Si" : "No");
        
        var lista = repository.GetAll();

        if (filtro != null)
            lista = lista.Where(filtro);
        Comparison<EntidadHorizon> comparador = orden switch {
            TipoOrdenamiento.Id => (a,b) => a.Id.CompareTo(b.Id),
            
            TipoOrdenamiento.CodigoGaia => (a,b) => string.Compare(a.CodigoGaia, b.CodigoGaia,StringComparison.Ordinal ),
            
            TipoOrdenamiento.Nombre => (a,b) => string.Compare(a.Nombre, b.Nombre, StringComparison.Ordinal),
            
            TipoOrdenamiento.Peligrosidad => (a,b) => string.Compare(a.Nombre, b.Nombre, StringComparison.Ordinal)
        }
    }

    public ILista<Maquina> GetMaquinasOrdeBy(TipoOrdenamiento ordenamiento = TipoOrdenamiento.CodigoGaia) {
        throw new NotImplementedException();
    }

    public ILista<Cazador> GetCazadoresOrdeBy(TipoOrdenamiento ordenamiento = TipoOrdenamiento.CodigoGaia) {
        throw new NotImplementedException();
    }

    public ILista<Saboteador> GetSaboteadores(TipoOrdenamiento ordenamiento = TipoOrdenamiento.CodigoGaia) {
        throw new NotImplementedException();
    }

    public EntidadHorizon GetByCodigoGaia(string codigoGaia) {
        throw new NotImplementedException();
    }

    public EntidadHorizon Save(EntidadHorizon entidad) {
        throw new NotImplementedException();
    }

    public EntidadHorizon Update(int id, EntidadHorizon entidad) {
        throw new NotImplementedException();
    }

    public EntidadHorizon Delete(int id) {
        throw new NotImplementedException();
    }

    public InformeMaquina GenerarInformeMaquina() {
        throw new NotImplementedException();
    }

    public InformeCazador GenerarInformeCazador(CicloEntrenamiento? cicloEntrenamiento = null) {
        throw new NotImplementedException();
    }

    public InformeSaboteador GenerarInformeSaboteador(CicloEntrenamiento? cicloEntrenamiento = null) {
        throw new NotImplementedException();
    }
}