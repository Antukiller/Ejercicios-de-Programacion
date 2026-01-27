namespace GestionBiblioteca.Models;

public record Revista : Ficha {
    public int Edicion { get; init; }
    
}