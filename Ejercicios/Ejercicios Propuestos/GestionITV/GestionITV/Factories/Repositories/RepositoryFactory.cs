using GestionITV.Repositories.Base;
using GestionITV.Repositories.Json;
using GestionITV.Repositories.Memory;

namespace GestionITV.Factories.Repositories;


/// <summary>
/// FACTORY PATTERN: Esta clase es una frábrica de repositorios.
/// NOTA IMPORTANTE: Una fábrica (Factory) es un patrón de diseño creacional
/// que encapasula la lógica de creación de objetos. El cliente (Program.cs)
/// no sabe qué implementación se está usando, solo que implemente IVehiculoRepository.
/// Esto permite cambiar el comportamiento sin modificar el código cliente (SOLID-DIP)
/// </summary>
public static class RepositoryFactory {
    
    /// <summary>
    /// Crea un repositorio según el tipo especificado.
    /// NOTA IMPORTANTE: Usamos 'switch expression' (C# 8+ que es más que switch/case tradicional)
    /// </summary>
    /// <param name="type">Tipo de repositorio a crear</param>
    /// <returns>Instancia del repositorio solicitado</returns>
    /// <exception cref="ArgumentException">Si el tipo no es válido</exception>
    public static IVehiculoRepository GetRepository(RepositoryType type) {
        return type switch {
            RepositoryType.Memory => VehiculoMemoryRepository.Instance,
            RepositoryType.Json => VehiculoJsonRepository.Instance,
            _ => throw new ArgumentException($"Tipo de repositorio desconocido: {type}")
        };
    }

    public static IVehiculoRepository GetDefaultRepository(string configType) {
        // CONVERSIÓN: Tranformamos el string del config a enum
        // Esto permite que el ususario escriba "json" en vez de RepositoryType.Json.

        var type = configType.ToLower() switch {
            "memory" => RepositoryType.Memory,
            "json" => RepositoryType.Json,
            _ => throw new ArgumentException($"Tipo configurado desconocido: {configType}")
        };
        return GetRepository(type);
    }
}