namespace PlantillaFutbolInterfaces.Models;

public class RolEntrenadorPortero() : IEntrenadorPortero {
    
    
    public void Entrenar() {
        Console.WriteLine("Entrena a los portero de forma profesional");
    }

    public void Adiestrar() {
        Console.WriteLine("Adiestra al portero de forma que no se vuelva loco");
    }

    public void Atajar() {
        Console.WriteLine("Ayudar al portero a que ataje mejor los tiros");
    }
}