namespace PlantillaFutbolInterfaces.Models;

public class Entrenador(string NombreCompleto, IEntrenador rol) : Persona(NombreCompleto, rol) {
    public int Experiencia { get; set; }

    public virtual void CambiarRol(IEntrenador nuevoRol) {
        Rol = nuevoRol;
    }

    public virtual void AjustarTactica() => Console.WriteLine("El entrenador ajusta la tactica");

}