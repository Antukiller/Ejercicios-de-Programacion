using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using GestionITV.Config;
using GestionITV.Models;
using Serilog;

namespace GestionITV.Storage.Json;

public class ItvJsonStorage : IItvCsvStorage {
    private readonly ILogger _logger =  Log.ForContext<ItvJsonStorage>();


    private readonly JsonSerializerOptions _options = new() {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition =
            JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter() },
        Encoder = JavaScriptEncoder
            .UnsafeRelaxedJsonEscaping
    };

    public ItvJsonStorage() {
        _logger.Debug("Inicializando Json Storage");
        InitStorage();
    }
    
    
    public void Salvar(IEnumerable<Vehiculo> items, string path) {
        try {
            using var stream = File.Create(path); // Preguntar diferencia entre las Create y CreateText
            var dtos = items.Select(v => v.ToDto())
                .ToList();
            JsonSerializer.Serialize(stream, dtos, _options);  
        }
        catch (Exception ex) {
            _logger.Error(ex, "Error al guardar los items en el archivo '{path}'", path);
            throw;
        }
    }

    public IEnumerable<Vehiculo> Cargar(string path) {
        _logger.Debug("Cargando los items del archivo '{path}'", path);
        if (!Path.Exists(path)) {
            _logger.Warning("El archivo '{path}' no existe. No se puede cargar nada.", path);
            throw new FileNotFoundException($"El archivo '{path}' no existe.");
        }

        try {
            using var stream = File.OpenRead(path);
            var dtos = JsonSerializer.Deserialize<List<VehiculoDto>>(stream, _options);
            
            return dtos?.Select(dto => dto.ToModel()) ??
                   throw new InvalidOperationException("No se pudieron deserializar los DTOs.");
        }
        catch (Exception ex) {
            _logger.Error(ex,"Error al cargar los items del archivo '{path}'", path);
            throw;
        }
    }

    private void InitStorage() {
        if (Directory.Exists(Configuracion.DataFolder)) 
            return;
        _logger.Debug("El directorio 'data' no existe. Creándolo...");
        Directory.CreateDirectory("data");
    }
    
}