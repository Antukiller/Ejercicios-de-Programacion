namespace PlantillaFutbolInterfaces.Models;

public sealed class Portero : Entrenador, IPortero {
    public override void Entrenar() {
        Console.WriteLine("Entrenando como portero");
    }

    public void Blocar() {
        Console.WriteLine("Blocando como portero");
    }
}