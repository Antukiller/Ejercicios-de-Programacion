using The_Witcher_3.Model;

namespace The_Witcher_3;

public class RolPlata : IEstiloEspada {
    public void RealizarAccion() {
        Console.WriteLine("[Accion]Desenvaina la espada de acero");
    }

    public void PrepararInventario() {
        Console.WriteLine("[Accion]Preparando la espada de plata con aceites y piedras de afilar");
    }

    public void AsestarGolpe() {
        Console.ForegroundColor = ConsoleColor.Gray; // Color metal
        Console.WriteLine("   [⚔️] ESPADA: Golpe preciso asestado.");
        Console.ResetColor();
    }
    
    public override string ToString() => "Estilo de Plata";
}