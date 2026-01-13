namespace PlantillaFutbolInterfaces.Models;

public sealed class EntrenadorSecundario(string NombreCompleto, IRol rol, int experiencia) : Entrenador(NombreCompleto, rol, experiencia), IEntrenadorSecundario {
    public void Entrenar() {
        throw new NotImplementedException();
    }

    public void Adiestrar() {
        throw new NotImplementedException();
    }

    public void Gestionar() {
        throw new NotImplementedException();
    }
}