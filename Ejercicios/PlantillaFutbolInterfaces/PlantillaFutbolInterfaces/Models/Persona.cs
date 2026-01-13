namespace PlantillaFutbolInterfaces.Models;

public abstract class Persona {
    private int Id { get; init; } = 0;
    public required string Dni { get; set; }
    public required string NombreCompleto { get; set; }
}