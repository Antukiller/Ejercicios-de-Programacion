namespace The_Witcher_3Genericos.Models;

public class RolQuen : IEstiloMagico {
    public void PrepararInventario(string nombre) => Console.WriteLine($"[CONJURO] {nombre} traza el signo Quen en el aire, cargando su energía protectora.");
    
    public void LanzarSeñal(string nombre) => Console.WriteLine($"[MAGIA] {nombre} genera una cúpula de energía dorada. ¡Escudo activo!");
    
}