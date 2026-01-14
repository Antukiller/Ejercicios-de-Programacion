namespace PlantillaFutbolInterfaces.Models;

public interface IJugador : IRol {
    public int Dorsal {  get; }
    public void Jugar();
}