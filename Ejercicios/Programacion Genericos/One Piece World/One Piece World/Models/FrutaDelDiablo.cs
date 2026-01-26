using One_Piece_World.Enum;

namespace One_Piece_World;

public record FrutaDelDiablo : Entidad {
    public TipoFruta Tipo { get; init; }
    public bool IsDespertada { get; init; }
}