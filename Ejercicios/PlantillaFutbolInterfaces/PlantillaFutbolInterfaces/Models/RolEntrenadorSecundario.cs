namespace PlantillaFutbolInterfaces.Models;

public class RolEntrenadorSecundario() : IEntrenadorSecundario {
    
    
    public void Entrenar() {
        Console.WriteLine("El segundo entrenador entrena a los suplentes");
    }

    public void Adiestrar() {
        Console.WriteLine("El segundo entrenador adiestra a los suplentes tacticamente");
    }

    public void Gestionar() {
        Console.WriteLine("El segundo entrenador gestiona a la plantilla mentalmente");
    }
    
}