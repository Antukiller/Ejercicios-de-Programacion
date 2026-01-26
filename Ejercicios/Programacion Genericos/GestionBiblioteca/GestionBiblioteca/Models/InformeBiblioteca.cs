namespace GestionBiblioteca.Models;

public record InformeBiblioteca(
    int TotalFichas,
    int TotalLibros,
    int TotalRevistas,
    int TotalDvds,
    double PorcentajeLibros,
    double PorcentajeRevistas,
    double PorcentajeDvds
);