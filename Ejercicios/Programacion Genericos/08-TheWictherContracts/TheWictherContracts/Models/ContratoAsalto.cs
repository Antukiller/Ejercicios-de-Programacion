using TheWictherContracts.Enums;

namespace TheWictherContracts.Models;

public sealed record ContratoAsalto(int id, string titulo, int nivelRecomendado, double recompensa, int numeroEnemigos, bool requiereSigilo) : ContratoBase(id, titulo, nivelRecomendado, recompensa) {
    public int NumeroEnemigos { get; init; } = numeroEnemigos;
    public bool RequiereSigilo { get; init; } = requiereSigilo;
}