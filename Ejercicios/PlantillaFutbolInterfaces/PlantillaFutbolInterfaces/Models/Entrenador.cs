namespace PlantillaFutbolInterfaces.Models;

public class Entrenador : Persona, IEntrenadorPrincipal {
    public required int Experiencia { get; set; }
    
    public virtual void Entrenar() {
        Console.WriteLine("Entrenado al primer equipo y ajustando la tactica");
    }


    public void AjustarTactica() {
        Console.WriteLine("Los entrenadores ajustan las tacticas a los equipos ");
    }
}