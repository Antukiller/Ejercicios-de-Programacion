using Horizon_Forbidden_West.Collections;

namespace Horizon_Forbidden_West.Models;

public sealed record InformeMaquina {
    // Listado de máquinas ordenadas por Peligrosidad (Extrema primero)
    public ILista<Maquina> PorPeligrosidad { get; init; } = new Lista<Maquina>();

    public int TotalMaquinas { get; init; }
    
    // Máquinas con NivelAmenaza.Extrema o Elevada
    public int AmenazasCriticas { get; init; } 
    
    // Máquinas con NivelAmenaza.Minima o Moderada
    public int AmenazasMenores { get; init; }

    public int Saboteables { get; init; }

    // Porcentaje de máquinas que podemos controlar
    public double PorcentajeHackeo => TotalMaquinas > 0 ? (double)Saboteables / TotalMaquinas * 100 : 0;
}