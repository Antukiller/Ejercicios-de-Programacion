using Microsoft.Win32.SafeHandles;

namespace NarutoWorld;

public class Ninja : EntidadCombate{
    public int ChakraActual { get; set; }
    public int ChakraMax { get; set;  }
    public Ninja? Sensei { get; set; }
    public required Jutsu?[] Repertorio { get; set; }
    
    
    
    public override void RealizarAccion() {
        if (Jutsu[] != null && ChakraActual is >= Repertorio[0].CosteEnergia) {
            Console.WriteLine("El ninja ataca");
        }
    }
}