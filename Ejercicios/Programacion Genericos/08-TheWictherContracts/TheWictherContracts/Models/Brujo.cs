using TheWictherContracts.Enums;

namespace TheWictherContracts.Models;

public record class Brujo() {
    public int  Id { get; init; }
    public string Nombre { get; init; }
    public int Nivel { get; init; }
    public EscuelaBrujo Escuela { get; init; }
    
}