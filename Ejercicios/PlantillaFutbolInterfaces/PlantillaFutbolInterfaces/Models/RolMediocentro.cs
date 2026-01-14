namespace PlantillaFutbolInterfaces.Models;

public class RolMediocentro(int Dorsal) : IMediocentro {
    
    public int Dorsal { get; } = Dorsal;

    public void Entrenar() {
        Console.WriteLine("Entrena los pases largos");
    }

    public void Jugar() {
        Console.WriteLine("Juega el partido de mediocentro");
    }

    public void Distribuir() {
        Console.WriteLine("Da asistencia de gol");
    }
}