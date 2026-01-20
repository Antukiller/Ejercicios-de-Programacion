using Microsoft.Win32.SafeHandles;

namespace NarutoWorld;

public class Shinobi : EntidadCombate{
    public int ChakraActual { get; set; }
    public int ChakraMax { get; set;  }
    public Shinobi? Sensei { get; set; }
    public Jutsu?[] LibroJutsus = new Jutsu?[5];
    
    
    
    public override void RealizarAccion() {
        if (Jutsu != null && ChakraActual is >=  ) 
    }
}