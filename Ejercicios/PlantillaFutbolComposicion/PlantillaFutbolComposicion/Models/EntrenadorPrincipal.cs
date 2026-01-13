namespace PlantillaFutbolComposicion.Models;

public sealed class EntrenadorPrincipal : Entrenador {
    public EntrenadorPrincipal(IEntrenamiento entrenar) : base(entrenar) {}
    public override void AjustarTactica() {
        Console.WriteLine("El entrenador pricipal cambia la formacion del equipo");
    }
    
}
