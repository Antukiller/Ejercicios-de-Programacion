namespace PlantillaFutbolInterfaces.Models;

public sealed class Defensa(string NombreCompleto, int Dorsal) : Jugador(NombreCompleto, new RolDefensa(Dorsal)) {

    public IDefensa Role => (IDefensa)Rol;

    public void Defender() {
        ((IDefensa)Rol).Defender();
    }
    public override void CambiarRol(IJugador nuevoRol) {
        base.CambiarRol(nuevoRol);
    }
    
    
}