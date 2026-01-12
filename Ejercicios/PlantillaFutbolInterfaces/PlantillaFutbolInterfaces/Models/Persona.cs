namespace PlantillaFutbolInterfaces.Models;

public abstract class Persona {
    private int Id { get; init; } = 0;
    private string Dni { get; set; }
    public required string NombreCompleto { get; set; }
}