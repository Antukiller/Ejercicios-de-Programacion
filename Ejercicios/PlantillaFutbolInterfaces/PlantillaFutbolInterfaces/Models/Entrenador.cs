namespace PlantillaFutbolInterfaces.Models;

public class Entrenador : Persona {
    public required int Experiencia { get; set; }
    
    public virtual void Entrenar() {
        Console.WriteLine("Entrenado al primer equipo y ajustando la tactica");
    }
    
    
}