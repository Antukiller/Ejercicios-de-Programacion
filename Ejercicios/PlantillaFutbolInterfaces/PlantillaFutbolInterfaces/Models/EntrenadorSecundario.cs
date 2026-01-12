namespace PlantillaFutbolInterfaces.Models;

public sealed class EntrenadorSecundario : Entrenador, IEntrenadorSecundario {
    public override void Entrenar() {
        Console.WriteLine("Ayudando a entrenar al equipo");
    }

    public void Gestionar() {
        Console.WriteLine("Ayudando a gestionar la plantilla del equipo");
    }
}