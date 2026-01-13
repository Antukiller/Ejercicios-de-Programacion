namespace PlantillaFutbolInterfaces.Models;

public sealed class Portero(string NombreCompleto, IRol rol, int dorsal) : Jugador(NombreCompleto, rol, dorsal), IPortero {
    public override void Convocado() {
        Console.WriteLine("El portero ha sido convocado");
    }
    

    public void Blocar() {
        Console.WriteLine("Blocando como portero");
    }

    public void Entrenar() {
        throw new NotImplementedException();
    }

    public void Jugar() {
        throw new NotImplementedException();
    }
}