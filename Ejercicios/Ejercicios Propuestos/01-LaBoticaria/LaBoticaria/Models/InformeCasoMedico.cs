namespace LaBoticaria;

/// <summary>
/// Proporciona una visión global de los casos médicos registrados y su resolución.
/// </summary>
public sealed record InformeCasosMedicos {
    /// <summary>
    /// Listado de casos ordenados por fecha de creación (del más reciente al más antiguo).
    /// </summary>
    public IEnumerable<CasoMedico> CasosRecientes { get; init; } = Enumerable.Empty<CasoMedico>();

    public int TotalCasos { get; init; }
    
    /// <summary>
    /// Casos donde se ha encontrado la sustancia que resolvió el problema.
    /// </summary>
    public int CasosResueltos { get; init; }

    /// <summary>
    /// Casos que aún no tienen una sustancia resolutora asignada.
    /// </summary>
    public int CasosPendientes => TotalCasos - CasosResueltos;

    /// <summary>
    /// Tasa de éxito de Maomao en la resolución de casos.
    /// </summary>
    public double TasaExito => TotalCasos > 0 
        ? (double)CasosResueltos / TotalCasos * 100 
        : 0;
}