namespace PlantillaFutbolComposicion.Models;

public class Jugador : Persona {
    public int Dorsal { get; set; }

    private IEntrenamiento entrenamiento;

    public Jugador(IEntrenamiento entrenamiento) {
        this.entrenamiento = entrenamiento;
    }

    public void Ensayar() => entrenamiento.Entrenar();

    public virtual void Jugar() => Console.WriteLine("El jugador se prepara para el partido");

}