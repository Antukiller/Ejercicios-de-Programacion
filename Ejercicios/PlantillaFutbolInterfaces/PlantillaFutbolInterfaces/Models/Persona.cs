namespace PlantillaFutbolInterfaces.Models;

public abstract class Persona(string NombreCompleto, IRol rol) {
    private int Id { get; set; } = 0;
    public required string Dni { get; set; }
    public string NombreCompleto { get; set; } = NombreCompleto;

    public IRol Rol { get; set; } = rol;

    public override string ToString() {
        return $"Persona(nombre = '{NombreCompleto}', rol={Rol})";
    }
}