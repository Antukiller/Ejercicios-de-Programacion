

using System.Globalization;
using Microsoft.Extensions.Configuration;

namespace GestionITV.Config;


/// <summary>
/// Clase estática que contiene las configuraciones globales para la gestión de la ITV
/// Nota Importante: Esta clase implementa el patrón "Service Locator" simplificado.
/// Centraliza toda la configruacion del sistema en un solo lugar, leyendo de appsetting.json.
/// Perrmite cambiar comportamiento sin recompilar (ej: tipo de repositorio, storage, etc.).
/// </summary>
public static class Configuracion {
    private static readonly IConfiguration Config;

    static Configuracion() {
        // Nota Importante: Cargamos la configuración desde el archivo Json externo.
        // Esto permite cambiar el tipo de almacenamiento o la ruta sin recompliar el código.
        Config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
    }
    
    
    /// <summary> Cultura/región para formatos (fechas/números). </summary>
    //public static CultureInfo Locale => CultureInfo.GetCultureInfo("es-Es");
    
    public static string DataFolder => Path.Combine(Environment.CurrentDirectory, Config.GetValue<string>("Repository:Directory") ?? "data");
    
    /// <summary>
    /// Tipo de almacenamiento para operaciones Import/Export.
    /// Nota Importante: Se usa en StorageFactory para crear el storage correcto.
    /// Valores permitidos: Json, Csv, Xml, Bin.
    /// </summary>
    public static string StorageType => Config.GetValue<string>("Storage:Type") ?? "json";
    
    /// <summary>
    /// Tipo de repositoprio para persistencia de datos.
    /// Nota Importante: Se usa en RepositoryFactory para crear el reposiotrio correcto
    /// Valores posibles: Memory(volátil), Binary (ficheros binarios), Json (fichero Json)
    /// Se valida el valor y si es desconocido se usa 'memory' por defecto.
    /// </summary>
    public static string RepositoryType {
        get {
            var type = Config.GetValue<string>("Repository:Type") ?? "memory";

            return type.ToLower() switch {
                "memory" => "memory",
                "binary" => "binary",
                "json" => "json",
                _ => "memory"
            };
        }
    }
    
    
    /// <summary>
    /// Ruta completa del archivo de datos según el tipo de storage.
    /// Nota Importante: Deduce la extensión según el StorageType configurado.
    /// Ejemplo: Si StorageType = "json", devuelve "data/vehiculos.json"
    /// </summary>
    public static string ItvFile {
        get {
            var extension = StorageType.ToLower() switch {
                "json" => "json",
                "xml" => "xml",
                "csv" => "csv",
                "bin" => "bin",
                _ => "json"
            };
            return Path.Combine(DataFolder, $"vehiculos{extension}");
        }
    }
    
    /// <summary>
    /// Directorio donde se guardan los archivos de backup (Zip)
    /// Nota Importante: Por defecto es 'back' relativo al ejecutable
    /// </summary>
    
    public static string BackupDirectory => Path.Combine(AppContext.BaseDirectory, Config.GetValue<string>("Backup:Directory") ?? "back");
    
    
    /// <summary>
    /// Formato de archivo para los backups.
    /// Nota Importante: Permite elegir el tipo de storage para el backup.
    /// Puede ser diferente del storage principal (ej: principal=bin, backup=json)
    /// </summary>
    public static string BackupFormat {
        get {
            var format = Config.GetValue<string>("Backup:Format") ?? "json";
            return format.ToLower() switch {
                "json" => "json",
                "xml" => "xml",
                "csv" => "csv",
                "bin" => "bin",
                _ => "json"
            };
        }
    }
}