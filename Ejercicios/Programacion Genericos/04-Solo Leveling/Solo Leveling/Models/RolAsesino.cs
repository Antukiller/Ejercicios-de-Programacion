namespace Solo_Leveling;

public class RolAsesino : IEstiloGuerrero {
    public void PrepararInventario(string nombre) => 
        Console.WriteLine($"[SISTEMA] {nombre} activa 'Sigilo'.");
    public void EjecutarAtaque(string nombre) => 
        Console.WriteLine($"[ESTILO GUERRERO] {nombre} usa 'Mutilación'.");
}