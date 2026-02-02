using Horizon_Forbidden_West.Collections;
using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Models;

namespace Horizon_Forbidden_West.Service;

public interface IEntidadHorizonService {
    int TotalEntidades { get; }
    
    ILista<EntidadHorizon> GetAll();

    ILista<EntidadHorizon> GetAllOrdeBy(TipoOrdenamiento orden = TipoOrdenamiento.CodigoGaia, Predicate<EntidadHorizon>? filtro  = null);
    
    public ILista<Maquina> GetMaquinasOrdeBy(TipoOrdenamiento ordenamiento = TipoOrdenamiento.CodigoGaia);
    
    public ILista<Cazador> GetCazadoresOrdeBy(TipoOrdenamiento ordenamiento = TipoOrdenamiento.CodigoGaia);
    
    public ILista<Saboteador> GetSaboteadores(TipoOrdenamiento ordenamiento = TipoOrdenamiento.CodigoGaia);
    
    EntidadHorizon GetByCodigoGaia(string codigoGaia);
    
    EntidadHorizon Save(EntidadHorizon entidad);
    
    EntidadHorizon Update(int id, EntidadHorizon entidad);

    EntidadHorizon Delete(int id);

    InformeMaquina GenerarInformeMaquina();
    
    InformeCazador GenerarInformeCazador(CicloEntrenamiento? cicloEntrenamiento = null);
    
    InformeSaboteador GenerarInformeSaboteador(CicloEntrenamiento? cicloEntrenamiento = null);
}