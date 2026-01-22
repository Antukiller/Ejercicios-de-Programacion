namespace The_Witcher_3Genericos.Models;

public class RolIgni : IEstiloMagico {
    public void PrepararInventario(string nombre) => Console.WriteLine($"[Magia]{nombre} se prepara para lanzar la señal Igni con sus guantes de pirómano...");
    public void LanzarSeñal(string nombre) => Console.WriteLine($"[Magia]{nombre} lanza ¡IGNI! Una llamarada sale de sus manos.");
}