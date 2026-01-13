namespace PlantillaFutbolComposicion.Models;

public abstract class Persona {
    public int Id { get; set; }
    public required string NombreCompleto { get; set; }
    public required int Edad { get; set; }
}