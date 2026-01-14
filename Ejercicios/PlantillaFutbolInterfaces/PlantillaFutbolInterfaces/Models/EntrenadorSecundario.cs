namespace PlantillaFutbolInterfaces.Models;

public sealed class EntrenadorSecundario(string NombreCompleto) : Entrenador(NombreCompleto, new RolEntrenadorSecundario()) {
    
    
    public IEntrenadorSecundario Role => (IEntrenadorSecundario)Rol;

    public void Gestionar() {
        ((IEntrenadorSecundario)Rol).Gestionar();
    }

    public override void CambiarRol(IEntrenador nuevoRol) {
        base.CambiarRol(nuevoRol);
    }
}