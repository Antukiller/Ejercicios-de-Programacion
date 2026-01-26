using GestionBiblioteca.Enums;

namespace GestionBiblioteca.Models;

public record Dvd : Ficha {
    public string Director { get; init; }
    public int Duracion { get; init; }
    public GeneroDvd Genero { get; init; }
}