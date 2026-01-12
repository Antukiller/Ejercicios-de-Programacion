namespace HerenciaVsComposicion.Herencia;

public class Entrenador() : Persona {
    public int Experiencia {  get; set; }
    
    public void EnseñarTactica() => Console.WriteLine( "Enseñando la tactica al equipo");

    public virtual void Entrenar() => Console.WriteLine("Aprendiendo a ser entrenador");
    
}