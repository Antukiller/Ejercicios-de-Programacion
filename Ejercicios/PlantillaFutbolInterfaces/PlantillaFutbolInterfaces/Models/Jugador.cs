using PlantillaFutbolInterfaces.Models;

namespace PlantillaFutbolInterfaces;

public class Jugador(string NombreCompleto, IJugador rol) : Persona(NombreCompleto, rol) {


    public virtual void Convocado() {
        Console.WriteLine("Convocado como jugador");
    }
    
    public virtual void CambiarRol(IJugador nuevoRol) {
        Rol = nuevoRol;
    }
}