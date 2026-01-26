namespace GestionBiblioteca.Models;

public record Libro : Ficha {
    public string Autor { get; init; }
    public string Isbn { get; init; }
}