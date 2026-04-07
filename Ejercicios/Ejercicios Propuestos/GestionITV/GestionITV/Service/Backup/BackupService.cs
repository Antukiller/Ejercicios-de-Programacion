using System.IO.Compression;
using GestionITV.Config;
using GestionITV.Exceptions.Backup;
using GestionITV.Models;
using GestionITV.Storage.Common;
using Serilog;

namespace GestionITV.Service.Backup;

public class BackupService(
    IStorage<Vehiculo> storage
) : IBackupService {
    private readonly string _backupDirectory = Configuracion.BackupDirectory;
    private readonly ILogger _logger = Log.ForContext<BackupService>();

    public string RealizarBackup(IEnumerable<Vehiculo> vehiculos) {
        _logger.Information("Realizando proceso de Backup");
        
        var vehiculosList = vehiculos.ToList();
        if (vehiculosList.Count == 0) {
            _logger.Warning("No hay datos para respaldar");
            throw new BackupException.CreationError("No hay datos para respaldar");
        }

        try {
            Directory.CreateDirectory(_backupDirectory);
        }
        catch (Exception ex) {
            _logger.Error(ex, "Error al crear el directorio de backup: {dir}", _backupDirectory);
            throw new BackupException.DirectoryError($"Error al crear el directorio de backup: {_backupDirectory}");
        }

        var tempDir = Path.Combine(Path.GetTempPath(), $"backup-{Guid.NewGuid()}");
        Directory.CreateDirectory(tempDir);

        try {
            var jsonPath = Path.Combine(tempDir, "data.json");
            try {
                storage.Salvar(vehiculosList, jsonPath);
            }
            catch (Exception ex) {
                _logger.Error(ex, "Error al serializar los datos del json.");
                throw new BackupException.CreationError("Error al serializar los datos del json.");
            }

            var fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var zipPath = Path.Combine(_backupDirectory, $"{fecha}.zip");

            try {
                ZipFile.CreateFromDirectory(tempDir, zipPath);
            }
            catch (Exception ex) {
                _logger.Error(ex, "Error al crear el archivo Zip.");
                throw new BackupException.CreationError("Error al comprimir el backup.");
            }

            _logger.Information("Backup creado correctamente: {zipPath}", zipPath);
            return zipPath;

        }
        finally {
            if (Directory.Exists(tempDir)) {
                Directory.Delete(tempDir, true);
                _logger.Debug("Directorio temporal limpiado correctamente");
            }
        }
    }

    public IEnumerable<Vehiculo> RestaurarBackup(string archivoBackup) {
        _logger.Information("Iniciando restauracion desde: {archivo}", archivoBackup);

        if (!File.Exists(archivoBackup)) {
            _logger.Warning("Archivo de backup no encontrado: {path}", archivoBackup);
            throw new BackupException.FileNotFound(archivoBackup);
        }

        var tempDir = Path.Combine(Path.GetTempPath(), $"restore-{Guid.NewGuid()}");
        Directory.CreateDirectory(tempDir);

        try {
            try {
                ZipFile.ExtractToDirectory(archivoBackup, tempDir);
            }
            catch (Exception ex) {
                _logger.Error(ex, "Error al extraer el archivo Zip.");
                throw new BackupException.InvalidBackupFile("No se pudo extraer el archivo Zip.");
            }

            var jsonPath = Path.Combine(tempDir, "data.json");
            if (!File.Exists(jsonPath)) {
                _logger.Warning("Archivo de backup no contiene datos válidos (data.json no encontrado)");
                throw new BackupException.InvalidBackupFile("El archivo de backup no contiene datos válidos.");
            }

            try {
                var vehiculos = storage.Cargar(jsonPath);
                _logger.Information("Datos extraídos del backup correctamente");
                return vehiculos;
            }
            catch (Exception ex) {
                _logger.Error(ex, "Error al deserializar los datos del backup.");
                throw new BackupException.InvalidBackupFile("El archivo de backup contiene datos corruptos.");
            }
        }


        finally {
            if (Directory.Exists(tempDir)) {
                Directory.Delete(tempDir, true);
                _logger.Debug("Directorio limpiado correctamente");
            }
        }
    }

    public IEnumerable<string> ListarBackups() {
        if (!Directory.Exists(_backupDirectory)) return Enumerable.Empty<string>();

        return Directory.GetFiles(_backupDirectory, "*.zip")
            .OrderByDescending(f => File.GetCreationTime(f));
    }
}