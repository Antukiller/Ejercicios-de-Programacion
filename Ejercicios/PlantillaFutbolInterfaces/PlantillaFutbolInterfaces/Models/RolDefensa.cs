namespace PlantillaFutbolInterfaces.Models;

public class RolDefensa(int Dorsal = 2) : IDefensa {
    public int Dorsal { get; }  = Dorsal;
    

    public void Entrenar() {
        Console.WriteLine("El defensa entrena la cobertura");
    }

    public void Jugar() {
        Console.WriteLine("El defensa juega de lateral");
    }

    public void Defender() {
        Console.WriteLine("El defensa defiende en zona");
    }
}