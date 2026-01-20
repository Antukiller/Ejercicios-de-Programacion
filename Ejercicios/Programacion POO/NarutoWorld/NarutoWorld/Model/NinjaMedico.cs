namespace NarutoWorld;

public class NinjaMedico : Ninja {
    public int BonoCuracion { get; set; }
    
    public override void RealizarAccion() {
        if (Jutsu != null && ChakraActual is >= 35%) {
            Console.WriteLine("El ninja medico esta curando");
        }
    }
}