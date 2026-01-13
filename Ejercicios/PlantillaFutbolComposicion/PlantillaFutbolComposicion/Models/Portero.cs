namespace PlantillaFutbolComposicion.Models;

public class Portero : Jugador {
    public Portero(IEntrenamiento entrenamiento) : base(entrenamiento) {}
    public override void Jugar() {
        Console.WriteLine("El portero se mentaliza para el partido");
        base.Jugar();
    }
}