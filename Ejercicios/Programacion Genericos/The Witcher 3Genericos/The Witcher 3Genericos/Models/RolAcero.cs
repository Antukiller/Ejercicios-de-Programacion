namespace The_Witcher_3Genericos.Models;

public class RolAcero : IEstiloEspada {
    public void PrepararInventario(string nombre) => Console.WriteLine($"[Espada]{nombre} esta afilando la espada de acero...");
    public void AsestarGolpe(string nombre) => Console.WriteLine($"[Espada]{nombre}¡ZAS! Un golpe certero contra el humano.");
}