namespace PlantillaFutbolInterfaces.Models;

public sealed class Portero : Jugador, IPortero {
    public override void Jugar() {
        Console.WriteLine("Jugando el partido como portero");
    }

    public void Blocar() {
        Console.WriteLine("Blocando como portero");
    }
}