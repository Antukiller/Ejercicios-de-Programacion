namespace Solo_Leveling;

public class RolMago : IEstiloMagico {
    public void PrepararInventario(string nombre) => 
        Console.WriteLine($"[SISTEMA] {nombre} comienza el cántico de maná.");
    public void LanzarHabilidad(string nombre) => 
        Console.WriteLine($"[ESTILO MÁGICO] {nombre} lanza 'Lluvia de Meteoros'.");
}