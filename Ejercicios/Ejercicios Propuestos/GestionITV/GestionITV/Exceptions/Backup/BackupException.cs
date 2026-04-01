using GestionITV.Exceptions.Common;

namespace GestionITV.Exceptions.Backup;


/// <summary>
/// Contenes
/// </summary>
/// <param name="message"></param>
public abstract class BackupException(string message) : DomainException(message) {
    
    /// <summary>
    /// Se lanza cuando el archivo de backup no existe
    /// </summary>
    /// <param name="filePath"></param>
    public sealed class FileNotFound(string filePath)
        : BackupException($"No se ha encontrado el archivo de backup: {filePath}.");
    
    /// <summary>
    /// Se lanza cuando el archivo de backup está corrupto o es inválido.
    /// </summary>
    /// <param name="details"></param>
    public sealed class InvalidBackupFile(string details) 
        : BackupException($"El archivo de backup es inválido o está corrupto: {details}.");
    
    
    /// <summary>
    /// Se lanza cuando hay errores de al crear el archivo Zip de backup
    /// </summary>
    /// <param name="details"></param>
    public sealed class CreationError(string details)
        : BackupException($"Error al crear el backup: {details}.");

    /// <summary>
    /// Se lanza cuando hay errores al restaurar desde un backup
    /// </summary>
    /// <param name="details"></param>
    public sealed class RestorationError(string details)
        : BackupException($"Error al restaura el backup: {details}");

    /// <summary>
    /// Se lanza cuando el directorio de backup no está disponible o no se puede crear
    /// </summary>
    /// <param name="details"></param>
    public sealed class DirectoryError(string details)
        : BackupException($"Error con el directorio de backup: {details}");
    
}