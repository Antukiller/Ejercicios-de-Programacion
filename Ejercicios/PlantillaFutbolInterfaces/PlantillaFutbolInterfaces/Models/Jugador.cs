using PlantillaFutbolInterfaces.Models;

namespace PlantillaFutbolInterfaces;

public class Jugador : Persona {
    public required int dorsal {  get; set; }


    public virtual void Jugar() {
        Console.WriteLine("Jugando como jugador");
    }
}