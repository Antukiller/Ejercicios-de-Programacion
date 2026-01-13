namespace PlantillaFutbolInterfaces.Models;

public sealed class Mediocentro : Jugador, IMediocentro {
    public override void Jugar() {
        Console.WriteLine("jugando el partido como mediocentro");
    }

    public void Distribuir() {
        Console.WriteLine("Distribuyendo el juego como mediocentro");
    }
}