namespace PlantillaFutbolInterfaces.Models;

public sealed class EntrenadorPortero : Entrenador, IEntrenadorPortero {
    public required int AñosEspecialidad { get; set; }

    public override void Entrenar() {
        Console.WriteLine("El entrenador de porteros esta entrenado a los porteros");
    }

    public void Especializar() {
        Console.WriteLine("El entrenador de esta especilizado con los juegos de pies");
    }

    public void Atajar() {
        Console.WriteLine("Entrenando a los porteros");
    }
}