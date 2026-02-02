using Horizon_Forbidden_West.Collections;

namespace Horizon_Forbidden_West.Models;

public sealed record InformeSaboteador {
    // Listado ordenado por Años de Experiencia descendente
    public ILista<Saboteador> PorExperiencia { get; init; } = new Lista<Saboteador>();

    public int TotalSaboteadores { get; init; }

    // Saboteadores con más de 20 años de experiencia
    public int MaestrosAlpha { get; init; }

    public double MediaAñosExperiencia { get; init; }

    // Número de saboteadores con CertificadoCaldero.GEMINI (el más difícil)
    public int CertificadosNivelOmega { get; init; }

    public double PorcentajeExpertos => TotalSaboteadores > 0 ? (double)MaestrosAlpha / TotalSaboteadores * 100 : 0;
}