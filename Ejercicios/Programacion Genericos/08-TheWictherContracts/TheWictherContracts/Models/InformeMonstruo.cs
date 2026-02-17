using TheWictherContracts.Collections;

namespace TheWictherContracts.Models;

public sealed record InformeMonstruo {
    // Usamos tu interfaz ILista para que sea compatible con tus extensiones
    public ILista<ContratoMonstruo> Contratos { get; init; } = new Lista<ContratoMonstruo>();
    
    public int Total { get; init; }
    public double RecompensaMedia { get; init; }
    public int NivelMasAlto { get; init; }
    
    // Un detalle extra: ¿cuál es el monstruo más peligroso?
    public string NombreMasPeligroso { get; init; } = "Ninguno";
}