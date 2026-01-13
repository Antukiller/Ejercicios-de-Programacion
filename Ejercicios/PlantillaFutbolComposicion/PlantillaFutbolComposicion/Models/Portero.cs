namespace PlantillaFutbolComposicion.Models;

public class Portero : Jugador {
    public override void Jugar() {
        Console.WriteLine("El portero se mentaliza para el partido");
        base.Jugar();
    }
}