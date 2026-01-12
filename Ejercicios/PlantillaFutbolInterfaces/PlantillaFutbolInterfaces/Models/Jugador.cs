using PlantillaFutbolInterfaces.Models;

namespace PlantillaFutbolInterfaces;

public class Jugador : Persona, IDelantero, IDefensa, IMediocenttro, IPortero {
    public required int dorsal {  get; set; }


    public virtual void Jugar() {
        Console.WriteLine("Jugando como jugador");
    }

    public void Chutar() {
        throw new NotImplementedException();
    }

    public void Defender() {
        throw new NotImplementedException();
    }

    public void Distribuir() {
        throw new NotImplementedException();
    }

    public void Blocar() {
        throw new NotImplementedException();
    }
}