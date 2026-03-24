using System.Text;
using System.Xml;
using System.Xml.Serialization;
using GestionITV.Config;
using GestionITV.Models;
using Serilog;

namespace GestionITV.Storage.Xml;

public class ItvXmlStorage : IItvXmlStorage {
    private readonly ILogger _logger = Log.ForContext<ItvXmlStorage>();
    
    private readonly XmlSerializerNamespaces _xmlSerializerNamespaces = new ();

    private readonly XmlWriterSettings _xmlWriterSettings = new() {
        Indent = true,
        Encoding = Encoding.UTF8,
    };


    public ItvXmlStorage() {
        _logger.Debug("Inicializando la clase ItvXmlStorage");
        InitStorage();
    }

    public void Salvar(IEnumerable<Vehiculo> items, string path) {
        try {
            _logger.Debug("Guardando los items en el archivo '{path}'", path);
            var dtos = items.Select(v => v.ToDto()).ToList();
            var serializer = new XmlSerializer(typeof(List<VehiculoDto>));

            using var streamWriter = new StreamWriter(path, false, Encoding.UTF8);
            using var xmlWriter = XmlWriter.Create(streamWriter, _xmlWriterSettings);
            serializer.Serialize(xmlWriter, dtos, _xmlSerializerNamespaces);
        }
        catch (Exception ex) {
            _logger.Error(ex, "Error al guardar los items en el archivo '{path}'", path);
            throw;
        }
    }

    public IEnumerable<Vehiculo> Cargar(string path) {
        _logger.Debug("Cargando los items del archivo '{path}'", path);
        if (!Path.Exists(path)) {
            _logger.Warning("El archivo '{path}' no existe. No se puede cargar nada", path);
            throw new FileNotFoundException($"El archivo '{path}' no existe.");
        }

        try {
            var serializer = new XmlSerializer(typeof(List<VehiculoDto>));
            
            using var stream =  File.OpenRead(path);
            var dtos = serializer.Deserialize(stream) as List<VehiculoDto>;

            return dto?.Select(dto => dto.ToModel()) ??
                   throw new InvalidOperationException("No se pudieron deserializar los DTOs");
        }
        catch (Exception ex) {
            _logger.Error(ex, "Error al cargar los items en el archivo '{path}'", path);
            throw;
        }
    }


    private void InitStorage() {
        if (Directory.Exists(Configuracion.DataFolder))
            return;
            _logger.Debug("El directorio '{path}' no existe. Creándolo...");
            Directory.CreateDirectory("data");
    }
}