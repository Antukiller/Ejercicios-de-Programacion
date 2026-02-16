namespace TheWictherContracts.Models;

public interface IEstrategia : IContrato {
    int ProbabiidadExito();
    void PlanificacionRuta();
}