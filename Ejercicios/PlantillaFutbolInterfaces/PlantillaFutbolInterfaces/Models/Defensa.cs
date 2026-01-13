namespace PlantillaFutbolInterfaces.Models;

public sealed class Defensa(string NombreCompleto, IRol rol, int dorsal) : Jugador(NombreCompleto, rol, dorsal), IDefensa {
    public void Entrenar() {
        throw new NotImplementedException();
    }

    public void Jugar() {
        throw new NotImplementedException();
    }

    public void Defender() {
        throw new NotImplementedException();
    }
}