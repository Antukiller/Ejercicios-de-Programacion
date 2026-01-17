namespace The_Witcher_3.Model;

public class RolMaestroPociones : IAlquimia {
    public void RealizarAccion() {
        Console.WriteLine("[Alquimia]Se toma una pocion");
    }

    public void PrepararInventario() {
        Console.WriteLine("[Alquimia]Se busca los ingredientes para prepara la pocion");
    }

    public void DestilarPocion() {
        Console.ForegroundColor = ConsoleColor.Green; // Color brebajes
        Console.WriteLine("   [🧪] ALQUIMIA: Poción preparada y lista.");
        Console.ResetColor();
    }
    
    public override string ToString() => "Estilo Maestro de Pociones";
}