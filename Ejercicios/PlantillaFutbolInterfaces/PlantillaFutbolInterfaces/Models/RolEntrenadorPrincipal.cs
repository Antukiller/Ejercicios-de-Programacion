namespace PlantillaFutbolInterfaces.Models;

public class RolEntrenadorPrincipal() : IEntrenadorPrincipal {
    
    public void Entrenar() {
        Console.WriteLine("El entrenador principal entrea con los jugadores");
    }

    public void Adiestrar() {
        Console.WriteLine("El entrenador principal adiestra a los jugadores");
    }

    public void Dirigir() {
        Console.WriteLine("El entrenador principal dirige a los jugadores desde el banquillo");
    }
}