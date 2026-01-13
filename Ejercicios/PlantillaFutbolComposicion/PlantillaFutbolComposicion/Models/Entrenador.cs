namespace PlantillaFutbolComposicion.Models;

public class Entrenador : Persona, IEntrenamiento {
    public int experiencia { get; set; }
    
    public void Adiestrar() => Entrenar();
    
    
    public virtual void AjustarTactica() => Console.WriteLine("El entrenador cambia de tactica");
    public void Entrenar() {
        throw new NotImplementedException();
    }
}