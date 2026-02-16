namespace TheWictherContracts.Repository.Common;

public interface ICrudRepository<Tkey, TEntity> where TEntity : class {
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(Tkey id);
    TEntity? Create(TEntity entity);
    TEntity? Update(Tkey id, TEntity entity);
    TEntity? Delete(Tkey id);
}