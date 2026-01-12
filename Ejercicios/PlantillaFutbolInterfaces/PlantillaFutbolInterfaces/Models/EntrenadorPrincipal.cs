namespace PlantillaFutbolInterfaces.Models;

public sealed class EntrenadorPrincipal : Entrenador, IEntrenadorPrincipal {
    public override void Entrenar() {
        Console.WriteLine("Entrenando al equipo como entrenador principal");
    }

    public void AjustarTactica() {
        Console.WriteLine("Esta modificando el esquema de juego");
    }
}