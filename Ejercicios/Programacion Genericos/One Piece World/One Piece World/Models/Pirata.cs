using One_Piece_World.Enum;

namespace One_Piece_World;

public record Pirata : Entidad {
    public long Recompensa { get; init; }
    public string Tripulacion { get; init; }
    public PosicionPirata Posicion { get; init; }
}