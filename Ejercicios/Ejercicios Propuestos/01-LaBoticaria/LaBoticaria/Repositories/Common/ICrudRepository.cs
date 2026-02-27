namespace LaBoticaria.Repositories.Common;

/// <summary>
/// Contrato de la interface Crud
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TEntity"></typeparam>
public interface ICrudRepository<TKey, TEntity> where TEntity : class{
    
    /// <summary>
    /// Recupera todas las entidades del almacen
    /// </summary>
    /// <returns>Enumerable de solo lectura de todas las entidades</returns>
    IEnumerable<TEntity> GetAll();
    
    /// <summary>
    /// Busca una entidad por su clave única
    /// </summary>
    /// <param name="id">Clave de búsqueda</param>
    /// <returns>La entidad encontrada o null</returns>
    TEntity? GetById(TKey id);
    
    /// <summary>
    /// Persiste una nueva entidad en el almacen
    /// </summary>
    /// <param name="entity">Entidad a crear</param>
    /// <returns>La entidad creada (usualmente con ID asignados) o null si ya existe</returns>
    TEntity? Create(TEntity entity);
    
    /// <summary>
    /// Actualiza los datos de la entidad existente
    /// </summary>
    /// <param name="id">Clave de la entidad</param>
    /// <param name="entity">Nuevos datos de la entidad</param>
    /// <returns>La entidad actualizada o null si no se encontró</returns>
    TEntity? Update(TKey id, TEntity entity);
    
    /// <summary>
    /// Elimina una entidad del almacen
    /// </summary>
    /// <param name="id">Clave de la entidad para eliminar</param>
    /// <returns>La entidad eliminada o null si no existe</returns>
    TEntity? Delete(TKey id);
    
    
}