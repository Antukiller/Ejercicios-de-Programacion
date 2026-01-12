namespace PlantillaFutbolInterfaces.Models;

public sealed class Delantero : Jugador, IDelantero {
    public override void Jugar() {
        Console.WriteLine("Jugando como delantero");
    }

    public void Chutar() {
        Console.WriteLine("Chutando el balon como un delantero");
    }
}