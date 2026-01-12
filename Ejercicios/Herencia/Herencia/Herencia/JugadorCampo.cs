namespace HerenciaVsComposicion.Herencia;

public class JugadorCampo : Persona {
    public int Dorsal {get; set;}
    
    
    public virtual void Mejorar() => Console.WriteLine("Mejorando las capacidades del jugador");
    public virtual void Jugar() => Console.WriteLine("Aprendiendo a ser jugador");
}