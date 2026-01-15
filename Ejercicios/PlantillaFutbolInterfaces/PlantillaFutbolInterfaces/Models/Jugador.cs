using PlantillaFutbolInterfaces.Models;

namespace PlantillaFutbolInterfaces;

public class Jugador(string NombreCompleto, IJugador role) : Persona(NombreCompleto, role) {


    public virtual void Convocado() {
        Console.WriteLine("Convocado como jugador");
    }
    
    public virtual void CambiarRol(IJugador nuevoRol) {
        Rol = nuevoRol;
    }
}