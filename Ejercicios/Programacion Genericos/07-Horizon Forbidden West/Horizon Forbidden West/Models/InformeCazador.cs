using Horizon_Forbidden_West.Collections;

namespace Horizon_Forbidden_West.Models;

public sealed record InformeCazador {
    // Listado ordenado por Rango (Buscadora > Mariscal > Vanguardia)
    public ILista<Cazador> PorRango { get; init; } = new Lista<Cazador>();

    public int TotalCazadores { get; init; }

    // Cazadores en CicloEntrenamiento.Veterano
    public int Veteranos { get; init; }

    // Cazadores en CicloEntrenamiento.Iniciado
    public int Iniciados { get; init; }

    // Porcentaje de veteranía en el ejército tribal
    public double IndicePreparacion => TotalCazadores > 0 ? (double)Veteranos / TotalCazadores * 100 : 0;
}