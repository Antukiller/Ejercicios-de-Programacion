namespace Solo_Leveling;

public class RolTanque : IEstiloGuerrero {
    public void PrepararInventario(string nombre) => 
        Console.WriteLine($"[SISTEMA] {nombre} activa 'Grito de Provocación'.");
    public void EjecutarAtaque(string nombre) => 
        Console.WriteLine($"[ESTILO GUERRERO] {nombre} usa 'Impacto de Escudo'.");
}