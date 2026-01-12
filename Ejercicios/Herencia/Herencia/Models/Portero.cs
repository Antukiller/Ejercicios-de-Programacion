namespace HerenciaVsComposicion.Herencia;

public sealed class Portero : JugadorCampo {
    public override void Jugar() {
        Console.WriteLine("Jugando como portero");
    }
}