namespace PlantillaFutbolInterfaces.Models;

public class JugadorEntrenador : Jugador, IEntrenadorPrincipal {
    public override void Jugar() {
        Console.WriteLine("Un JugadorEntrenador quiero dirigir y entrenar");
    }

    public void AjustarTactica() {
        Console.WriteLine("Tactica quiero dirigir y entrenar");
    }
}