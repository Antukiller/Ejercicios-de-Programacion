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
    /// 
    /// </summary>
    /// <param name="details"></param>
    public sealed class CreationError(string details)
        : BackupException($"Error al crear el backup: {details}.");
    
    
}