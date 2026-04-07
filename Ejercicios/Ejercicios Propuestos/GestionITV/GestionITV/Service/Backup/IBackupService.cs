using GestionITV.Models;

namespace GestionITV.Service.Backup;

/// <summary>
/// Contrato para el servicio der backup y restauracion del sistema
/// </summary>
public interface IBackupService {
    /// <summary>
    /// Realiza una copia de seguridad de los datos proporcionados
    /// </summary>
    /// <param name="vehiculos">Colección de vehículos a respaldar</param>
    /// <returns>La ruta del archivo ZIP creado</returns>
    string RealizarBackup(IEnumerable<Vehiculo> vehiculos);
    
    
    /// <summary>
    /// Restaura los datos desde un archivo ZIP de backup.
    /// </summary>
    /// <param name="archivoBackup">Ruta del archivo Zip de backup.</param>
    /// <returns>Colección de vehiculos restaurados</returns>
    IEnumerable<Vehiculo> RestaurarBackup(string archivoBackup);
    
    /// <summary>
    /// Obtiene la lista de archivos de backup disponibles.
    /// </summary>
    /// <returns>Enumerable con las rutas de los archivos de backup.</returns>
    IEnumerable<string> ListarBackups();
}