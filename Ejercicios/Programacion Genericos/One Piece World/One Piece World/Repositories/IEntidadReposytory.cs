using One_Piece_World.Repositories.Common;

namespace One_Piece_World.Repositories;

public interface IEntidadReposytory : ICrudRepository<int, Entidad> {
    public int TotalEntidades { get; }
}