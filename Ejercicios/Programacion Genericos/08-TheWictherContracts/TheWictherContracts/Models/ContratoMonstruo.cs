using TheWictherContracts.Enums;

namespace TheWictherContracts.Models;

public sealed record ContratoMonstruo(int id, string titulo, int nivelRecomendado, double recompensa, EspecieCriatura monstruo) : ContratoBase(id, titulo, nivelRecomendado, recompensa), IBestiario {
    public EspecieCriatura Monstruo { get; init; }
    public void MostrarDetalles() {
        throw new NotImplementedException();
    }

    public void PeprararAceite() {
        Console.WriteLine();
    }

    public string SeleccionarSeñal() {
        Console.WriteLine("Seleccionando la señal adecuada para el momento...");

        string señalCombate = Monstruo switch {
            EspecieCriatura.Necrofago or EspecieCriatura.Insectoide => Señal.Igni,
            EspecieCriatura.Espectro or EspecieCriatura.Vampiro => Señal.Yrden,
            EspecieCriatura.Híbrido or EspecieCriatura.Draconico => Señal.Aard
        };
        return señalCombate;
    }

    public void MostraDebilidades() {
        throw new NotImplementedException();
    }
}