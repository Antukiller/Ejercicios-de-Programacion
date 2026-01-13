namespace PlantillaFutbolComposicion.Models;

public class Entrenador : Persona {
    public int experiencia { get; set; }
    
    
    private IEntrenamiento entrenar;
    public Entrenador(IEntrenamiento entrenar) {
        this.entrenar = entrenar;
    }
    public void Adiestrar() => entrenar.Entrenar();
    
    
    public virtual void AjustarTactica() => Console.WriteLine("El entrenador cambia de tactica");
}