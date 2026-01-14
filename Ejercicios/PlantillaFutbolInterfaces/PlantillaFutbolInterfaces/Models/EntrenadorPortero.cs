namespace PlantillaFutbolInterfaces.Models;

public sealed class EntrenadorPortero(string NombreCompleto) : Entrenador(NombreCompleto, new RolEntrenadorPortero()) {

    public IEntrenadorPortero Role => (IEntrenadorPortero)Rol;

    public void Atajar() {
        ((IEntrenadorPortero)Rol).Atajar();
    }

    public override void CambiarRol(IEntrenador nuevoRol) {
        base.CambiarRol(nuevoRol);
    }
    
}