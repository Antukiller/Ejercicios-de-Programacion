namespace The_Witcher_3.Model;

public class RolQuen : IEstiloMagico {
    public void RealizarAccion() {
        Console.WriteLine("[Magia]Se prepara para hacer una señal");
    }

    public void PrepararInventario() {
        Console.WriteLine("[Magia]Se elige la señal Quen para lanzar");
    }

    public void LanzarSeñal() {
        Console.ForegroundColor = ConsoleColor.Cyan; // Color magia
        Console.WriteLine("   [✨] SEÑAL: Energía canalizada con éxito.");
        Console.ResetColor();
    }
    
    public override string ToString() => "Estilo Magico Quen";
}