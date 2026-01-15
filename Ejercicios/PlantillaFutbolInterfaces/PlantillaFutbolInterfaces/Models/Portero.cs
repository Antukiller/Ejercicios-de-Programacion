namespace PlantillaFutbolInterfaces.Models;

public sealed class Portero(string NombreCompleto, int dorsal) : Jugador(NombreCompleto, new RolPortero(dorsal)) {
    
    
    public IPortero Role => (IPortero)Rol;

    public void Blocar() {
        ((IPortero)Rol).Blocar();
    }

    public override void CambiarRol(IJugador nuevoRol) {
        base.CambiarRol(nuevoRol);
    }
    
}