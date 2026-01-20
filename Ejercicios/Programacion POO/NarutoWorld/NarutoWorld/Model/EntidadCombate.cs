namespace NarutoWorld;

public abstract class EntidadCombate {
    public required string Nombre { get; set; }
    public int VidaActual { get; set; }

    public abstract void RealizarAccion(); 
}