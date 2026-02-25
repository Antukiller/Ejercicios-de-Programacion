namespace SistemaGestiónNarutoWorld.Repositories.Common;

/// <summary>
///  Contrato genérico para operaciones CRUD de persistencia.
///  Diseñado para devolver IEnumerable, desacoplando el almacenamiento interno.
/// </summary>
/// <typeparam name="Tkey"></typeparam>
/// <typeparam name="TEntity"></typeparam>
public interface ICrudRepository<Tkey, TEntity> where TEntity : class {
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(Tkey id);
    TEntity? Create(TEntity entity);
    TEntity? Update(Tkey id, TEntity entity);
    TEntity? Delete(Tkey id);

}