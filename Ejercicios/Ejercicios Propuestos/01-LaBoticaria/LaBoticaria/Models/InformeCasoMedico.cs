namespace LaBoticaria;

/// <summary>
/// Proporciona una visión global de los casos médicos registrados y su resolución.
/// </summary>
/// <summary>
/// Contiene el análisis estadístico de los casos médicos tratados por la boticaria.
/// </summary>
public sealed record InformeCasosMedicos {
    /// <summary>
    /// Listado de casos activos analizados.
    /// </summary>
    public IEnumerable<CasoMedico> CasosActivos { get; init; } = Enumerable.Empty<CasoMedico>();

    // El Historial: Casos que ya se cerraron y sirven de registro
    public IEnumerable<CasoMedico> HistorialResueltos { get; init; } = Enumerable.Empty<CasoMedico>();

    public int TotalCasos => CasosActivos.Count() + HistorialResueltos.Count();
    public int CasosCerrados { get; init; }
    public int CasosEnCurso { get; init; }

    // --- Análisis de Gravedad ---
    /// <summary>
    /// Cantidad de casos con gravedad Crítica o Mortal.
    /// </summary>
    public int CasosUrgentes { get; init; }

    // --- Estadísticas de Síntomas ---
    /// <summary>
    /// Promedio de síntomas observados por cada paciente.
    /// </summary>
    public double MediaSintomasPorCaso { get; init; }

    /// <summary>
    /// Porcentaje de éxito (Casos que han llegado a una conclusión/investigación finalizada).
    /// </summary>
    public double TasaResolucion => TotalCasos > 0 
        ? (double)CasosCerrados / TotalCasos * 100 
        : 0;

    /// <summary>
    /// El síntoma más repetido en todos los casos actuales.
    /// </summary>
    public string SintomaMasComun { get; init; } = "Ninguno";
}