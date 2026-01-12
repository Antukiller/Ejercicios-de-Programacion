namespace PlantillaFutbolInterfaces.Models;

public sealed class Defensa : Jugador, IDefensa {
    public override void Jugar() {
        Console.WriteLine("jugando el partido como defensa");
    }

    public void Defender() {
        Console.WriteLine("Defendiendo como defensa");
    }
}