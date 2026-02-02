using Horizon_Forbidden_West.Collections;

namespace Horizon_Forbidden_West.Repositories.Common;

public interface ICrudRepository<TKey, TEntity> where TEntity : class {
    ILista<TEntity> GetAll();
    TEntity? GetById(TKey id);
    TEntity? Create(TEntity entity);
    TEntity? Update(TKey id, TEntity entity);
    TEntity? Delete(TKey id);
}