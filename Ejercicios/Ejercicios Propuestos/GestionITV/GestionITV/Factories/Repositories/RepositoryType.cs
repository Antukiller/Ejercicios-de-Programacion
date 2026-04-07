namespace GestionITV.Factories.Repositories;

/// <summary>
/// Enum que define los tipos de repositorios disponibles en el sistema.
/// Nota Importante: Este enum permite añadir nuevos tipos de repositorio
/// sin modificar la lógica existente. Es un ejemplo de patrón "Strategy".
/// </summary>
public enum RepositoryType {
    /// <summary>
    /// Repositorio en memoria(Dictionary). Datos se pierden al cerrar.
    /// </summary>
    Memory,
    
    /// <summary>
    /// Repositorio JSON. Persiste en archivo itv.json en cada operación
    /// </summary>
    Json,
}