using One_Piece_World.Enum;

namespace One_Piece_World;

public record Marine : Entidad {
    public RangoMarine Rango { get; init; }
    public string BaseAsignada { get; init; }
}