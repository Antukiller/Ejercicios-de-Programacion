namespace PlantillaFutbolInterfaces.Models;

public sealed class EntrenadorPrincipal(string NombreCompleto) : Entrenador(NombreCompleto, new RolEntrenadorPrincipal()) {

    public IEntrenadorPrincipal Role => (IEntrenadorPrincipal)Rol;

    public void Entrenar() {
        ((IEntrenadorPrincipal)Rol).Entrenar();
    }
    
    public override void CambiarRol(IEntrenador nuevoRol) {
        base.CambiarRol(nuevoRol);
    }
}