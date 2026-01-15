using PlantillaFutbolInterfaces.Models;

namespace PlantillaFutbolInterfaces;

public class RolDelantero(int Dorsal) : IDelantero {
    public int Dorsal { get; } = Dorsal;
    
    public void Entrenar() {
        Console.WriteLine("El delantero entrena el tornado de fuego");
    }
    
    public void Jugar() {
        Console.WriteLine("El delantero juega el partido");
    }

    public void Chutar() {
        Console.WriteLine("El delantero chuta el tornado de fuego");
    }

    public override string ToString() {
        return $"soy un delantero con dorsal : {Dorsal}";
    }
}