using System.Text;
using GestionITV.Models;
using Serilog;

namespace GestionITV.Storage;

public class ItvCsvStorage : IItvCsvStorage {

    private readonly ILogger _logger = Log.ForContext<ItvCsvStorage>();


    public ItvCsvStorage() {
        _logger.Debug("Iniciando la clase ItvCsvStorage");
        InitStorage();
    }
    
    public void Salvar(IEnumerable<Vehiculo> items, string path) {
        try {
            _logger.Debug("Guardando los items en el archivo '{path}'", path);
            using var writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.WriteLine(
                "Id;Matricula;Marca;Modelo;Cilindrada;Motor;DniPropietario;CreatedAt;UpdateAt;IsDeleted");


            foreach (var v in items ) {
                var dto = v.ToDto();
                writer.WriteLine(
                    $"{dto.Id};{dto.Matricula};{dto.Marca};{dto.Modelo};{dto.Cilindrada};{dto.Motor};{dto.DniPropietario};{dto.CreatedAt};{dto.UpdateAt};{dto.IsDeleted}");
            }
        }
        catch (Exception ex) {
            _logger.Error(ex, "Error al guardar los items en el archivo '{path}'", path);
            throw;
        }
    }

    public IEnumerable<Vehiculo> Cargar(string path) {
        _logger.Debug("Cargando los items del archivo '´{path}'", path);
        if (!Path.Exists(path)) {
            _logger.Warning("El archivo '{path}' no existe. No se puede cargar nada", path);
            throw new FileNotFoundException($"El archivo '{path}' no existe");
            
        }
        
        
    }
}