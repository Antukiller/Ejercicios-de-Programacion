using One_Piece_World.Collections;

namespace One_Piece_World.Repositories.Common;

public interface ICrudRepository<TKey, TEntity> where TEntity : class {
    ILista<TEntity> GetAll();
    TEntity? GetById(TKey id);
    TEntity? Create(TEntity entity);
    TEntity? Update(TKey id, TEntity entity);
    TEntity? Delete(TKey id);

}