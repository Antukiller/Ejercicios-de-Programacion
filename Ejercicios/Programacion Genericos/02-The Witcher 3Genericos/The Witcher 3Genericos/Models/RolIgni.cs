namespace The_Witcher_3Genericos.Models;

public class RolIgni : IEstiloMagico {
    public void PrepararInventario(string nombre) => Console.WriteLine($"[CONJURO] {nombre} ajusta sus guantes de pirómano; el aire comienza a vibrar por el calor.");
    
    public void LanzarSeñal(string nombre) => Console.WriteLine($"[MAGIA] {nombre} lanza ¡IGNI! Una ráfaga de fuego abrasador incinera todo a su paso.");
    
}