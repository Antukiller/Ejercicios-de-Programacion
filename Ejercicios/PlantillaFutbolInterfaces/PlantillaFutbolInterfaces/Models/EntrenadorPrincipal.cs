namespace PlantillaFutbolInterfaces.Models;

public sealed class EntrenadorPrincipal(string NombreCompleto, IRol rol, int experiencia) : Entrenador(NombreCompleto, rol, experiencia), IEntrenadorPrincipal {
    public override void AjustarTactica() {
        Console.WriteLine("El entrenador principal modifica el la formacion");
    }

    public void Entrenar() {
        throw new NotImplementedException();
    }

    public void Adiestrar() {
        throw new NotImplementedException();
    }

    public void Dirigir() {
        throw new NotImplementedException();
    }
}