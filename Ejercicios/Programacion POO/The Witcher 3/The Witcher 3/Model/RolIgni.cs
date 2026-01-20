namespace The_Witcher_3.Model;

public class RolIgni : IEstiloMagico {
    public void RealizarAccion() {
        Console.WriteLine("[Magia]Se prepara para la lanzar una señal");
    }

    public void PrepararInventario() {
        Console.WriteLine("[Magia]Se elige la señal Igni para lanzar");
    }

    public void LanzarSeñal() {
        Console.ForegroundColor = ConsoleColor.Cyan; // Color magia
        Console.WriteLine("   [✨] SEÑAL: Energía canalizada con éxito.");
        Console.ResetColor();
    }
    
    public override string ToString() => "Estilo Magico Ignis";
}