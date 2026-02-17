namespace TheWictherContracts.Models;

/// <summary>
/// Contiene el análisis estadístico del tablón de anuncios y contratos disponibles.
/// </summary>
public sealed record InformeContratos {
    /// <summary>
    /// Listado de todos los contratos ordenados por recompensa (de mayor a menor).
    /// </summary>
    public IEnumerable<ContratoBase> PorRecompensa { get; init; } = Enumerable.Empty<ContratoBase>();

    /// <summary>
    /// Cantidad total de contratos registrados en el sistema.
    /// </summary>
    public int TotalContratos { get; init; }

    /// <summary>
    /// Cantidad de contratos que se consideran de "Élite" (Nivel > 30).
    /// </summary>
    public int ContratosElite { get; init; }

    /// <summary>
    /// Cantidad de contratos sencillos (Nivel < 15).
    /// </summary>
    public int ContratosBasicos { get; init; }

    /// <summary>
    /// Suma total de todos los Orens (recompensas) disponibles en el tablón.
    /// </summary>
    public double TesoroTotal { get; init; }

    /// <summary>
    /// Promedio de nivel recomendado de todos los contratos.
    /// </summary>
    public double NivelMedio { get; init; }

    /// <summary>
    /// Porcentaje de contratos de Élite respecto al total.
    /// </summary>
    public double PorcentajePeligro => TotalContratos > 0 ? (double)ContratosElite / TotalContratos * 100 : 0;
}