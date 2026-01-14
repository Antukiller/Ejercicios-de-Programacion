namespace PlantillaFutbolInterfaces.Models;

public sealed class Delantero(string NombreCompleto, int Dorsal) : Jugador(NombreCompleto, new RolDelantero(Dorsal)) {

    public IDelantero Role => (IDelantero)Rol;

    public void Chutar() {
        ((IDelantero)Rol).Chutar();
    }

    public override void CambiarRol(IJugador nuevoRol) {
        base.CambiarRol(nuevoRol);
    }
}