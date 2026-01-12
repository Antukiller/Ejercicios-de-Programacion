namespace HerenciaVsComposicion.Herencia;

public sealed class EntrenadorSecundario : Entrenador {
    public override void Entrenar() {
        Console.WriteLine("Ayudando al entrenador principal");
    }
}