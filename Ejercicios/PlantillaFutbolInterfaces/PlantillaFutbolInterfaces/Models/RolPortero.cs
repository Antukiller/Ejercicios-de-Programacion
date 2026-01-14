namespace PlantillaFutbolInterfaces.Models;

public class RolPortero(int Dorsal = 1) : IPortero {
    public int Dorsal { get; } = Dorsal;
    
    public void Blocar() {
        Console.WriteLine("Blocando como portero");
    }

    public void Entrenar() {
        Console.WriteLine("Entrenando como jugar con los pies");
    }
    

    public void Jugar() {
        Console.WriteLine("Juega el partido como portero");
    }
}