namespace PlantillaFutbolInterfaces.Models;

public class Entrenador(string NombreCompleto, IRol rol, int experiencia) : Persona(NombreCompleto, rol) {
    public required int Experiencia { get; set; } = experiencia;

    public virtual void AjustarTactica() => Console.WriteLine("El entrenador ajusta la tactica");

}