using TheWictherContracts.Collections;

namespace TheWictherContracts.Models;

public sealed record InformeAsalto {
    public ILista<ContratoAsalto> Contratos { get; init; } = new Lista<ContratoAsalto>();
    
    public int Total { get; init; }
    public int TotalEnemigos { get; init; }
    public int MisionesSigilo { get; init; }
    public double ProbabilidadExitoMedia { get; init; }
}