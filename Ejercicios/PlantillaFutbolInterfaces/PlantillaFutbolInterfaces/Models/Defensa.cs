namespace PlantillaFutbolInterfaces.Models;

public sealed class Defensa : Entrenador, IDefensa {
    public override void Entrenar() {
        Console.WriteLine("Entrenando como defensa");
    }

    public void Defender() {
        Console.WriteLine("Defendiendo como defensa");
    }
}