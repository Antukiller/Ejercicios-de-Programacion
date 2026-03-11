using LaBoticaria.Enums;

namespace LaBoticaria;

public sealed record InformeSustancias {
    public IEnumerable<Sustancia> ListadoActivo { get; init; } = Enumerable.Empty<Sustancia>();
    
    // Propiedades calculadas
    public int TotalSustancias => ListadoActivo.Count();
    
    // Totales por tipo (se llenarán en el Service)
    public int TotalMedicinas { get; init; }
    public int TotalVenenos { get; init; }
    public int TotalAfrodisiacos { get; init; }

    // Estadísticas basadas en tus campos de Sustancia
    public double PrecioMedio { get; init; }
    public double PrecioMaximo { get; init; }
    
    // Porcentaje de sustancias de Peligro Alto/Extremo
    public double IndiceRiesgoTotal => TotalSustancias > 0 
        ? (double)ListadoActivo.Count(s => s.Peligro >= NivelPeligro.Alto) / TotalSustancias * 100 
        : 0;
}