using GestionITV.Models;
using GestionITV.Storage;
using GestionITV.Storage.Common;
using GestionITV.Storage.Json;
using GestionITV.Storage.Xml;

namespace GestionITV.Factories.Storage;

/// <summary>
/// Factory para crear instancias de almacenamientos según el tipo solicitado.
/// Optimizado para crear solo la instancia necesaria (Lazy Loading).
/// </summary>
public static class StorageFactory {
    
    /// <summary>
    /// Obtiene una instancia de almacenamiento según el tipo especificado.
    /// NOTA IMPORTANTE: Ya no creamos todos los storages al principio.
    /// Usamos un switch para instanciar solo el que realmente vamos a usar.
    /// </summary>
    /// <param name="type">Tipo de almacenamiento deseado</param>
    /// <returns>Tipo de almacenamiento coorrespondiente</returns>
    /// <exception cref="ArgumentException"></exception>
    public static IStorage<Vehiculo> GetStorage(StorageType type) {
        return type switch {
            StorageType.Csv => new ItvCsvStorage(),
            StorageType.Json => new ItvJsonStorage(),
            StorageType.Xml => new ItvXmlStorage(),
            StorageType.Byn => new ItvBinaryStorage(),
            _ => throw new ArgumentException($"Tipo de almacenamiento desconocido: {type}")
        };
    }
    
    public static IStorage<Vehiculo> GetDefaultStorage(string configType) {
        var type = configType.ToLower() switch {
            "csv" => StorageType.Csv,
            "json" => StorageType.Json,
            "xml" => StorageType.Xml,
            "bin" => StorageType.Byn,
            _ => throw new ArgumentException($"Tipo configurado desconocido: {configType}")
        };
        return GetStorage(type);
    }
}