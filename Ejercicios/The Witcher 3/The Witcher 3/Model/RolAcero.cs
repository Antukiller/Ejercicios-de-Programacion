namespace The_Witcher_3.Model;

public class RolAcero : IEstiloEspada {
    public void RealizarAccion() {
        Console.WriteLine("[Accion]Desenvaina la espada de acero");
    }

    public void PrepararInventario() {
        Console.WriteLine("[Accion]Preparando inventario de aceites y piedra de afilar para la espada de acero");
    }

    public void AsestarGolpe() {
        Console.ForegroundColor = ConsoleColor.Gray; // Color metal
        Console.WriteLine("   [⚔️] ESPADA: Golpe preciso asestado.");
        Console.ResetColor();
    }

    public override string ToString() => "Estilo de Acero";
}