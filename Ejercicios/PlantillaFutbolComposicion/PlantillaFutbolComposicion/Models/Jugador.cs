namespace PlantillaFutbolComposicion.Models;

public class Jugador : Persona, IEntrenamiento {
    public int Dorsal { get; set; }
    
    

    public void Ensayar() => Entrenar();

    public virtual void Jugar() => Console.WriteLine("El jugador se prepara para el partido");

    public void Entrenar() {
        throw new NotImplementedException();
    }
}