using PlantillaFutbolInterfaces.Models;

namespace PlantillaFutbolInterfaces;

public class Jugador(string NombreCompleto, IRol rol, int dorsal) : Persona(NombreCompleto, rol) {
    public required int dorsal {  get; set; } = dorsal;


    public virtual void Convocado() {
        Console.WriteLine("Convocado como jugador");
    }
}