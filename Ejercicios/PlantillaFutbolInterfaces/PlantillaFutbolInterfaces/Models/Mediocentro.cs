namespace PlantillaFutbolInterfaces.Models;

public sealed class Mediocentro(string NombreCompleto, int Dorsal) : Jugador(NombreCompleto, new RolMediocentro(Dorsal) ) {

    public IMediocentro Role => (IMediocentro)Rol;

    public void Distribuir() {
        ((IMediocentro)Rol).Distribuir();
    }

    public override void CambiarRol(IJugador nuevoRol) {
        base.CambiarRol(nuevoRol);
    }
}