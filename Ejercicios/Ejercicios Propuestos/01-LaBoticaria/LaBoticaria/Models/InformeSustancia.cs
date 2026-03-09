namespace LaBoticaria;

/// <summary>
/// Contiene datos consolidados sobre el inventario de sustancias de la boticaria.
/// </summary>
public sealed record InformeSustancias {
    /// <summary>
    /// Listado de todas las sustancias (sin incluir las borradas lógicamente).
    /// </summary>
    public IEnumerable<Sustancia> ListadoActivo { get; init; } = Enumerable.Empty<Sustancia>();

    public int TotalSustancias => ListadoActivo.Count();

    // Estadísticas por tipo (Nivel DAW: usando el tipo de clase)
    public int TotalMedicinas { get; init; }
    public int TotalVenenos { get; init; }
    public int TotalAfrodisiacos { get; init; }

    /// <summary>
    /// Porcentaje de venenos respecto al total (para control de seguridad en el palacio).
    /// </summary>
    public double PorcentajePeligrosidad => TotalSustancias > 0 
        ? (double)TotalVenenos / TotalSustancias * 100 
        : 0;
}