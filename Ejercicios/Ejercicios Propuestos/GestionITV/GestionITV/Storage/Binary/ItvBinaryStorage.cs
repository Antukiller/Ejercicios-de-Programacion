using System.Text;
using GestionITV.Config;
using GestionITV.Dto;
using GestionITV.Mapper;
using GestionITV.Models;
using GestionITV.Storage.Binary;
using Serilog;

namespace GestionITV.Storage;

public class ItvBinaryStorage : IItvBinaryStorage {
    private readonly ILogger _logger = Log.ForContext<ItvBinaryStorage>();

    public ItvBinaryStorage() {
        _logger.Debug("Iniciando la clase ItvBinaryStorage");
    }
    
    public void Salvar(IEnumerable<Vehiculo> items, string path) {
        _logger.Debug("Guardando los items en el archivo binario '{path}'", path);
        using var stream = File.Create(path);
        using var writer = new BinaryWriter(stream, Encoding.UTF8);

        var dtos = items.Select(v => v.ToDto()).ToList();
        writer.Write(dtos.Count);

        foreach (var dto in dtos ) {
            writer.Write(dto.Id);
            writer.Write(dto.Matricula);
            writer.Write(dto.Marca);
            writer.Write(dto.Modelo);
            writer.Write(dto.Cilindrada);
            writer.Write(dto.Motor);
            writer.Write(dto.DniPropietario);
            writer.Write(dto.CreatedAt);
            writer.Write(dto.UpdatedAt);
            writer.Write(dto.IsDeleted);
        }
    }

    public IEnumerable<Vehiculo> Cargar(string path) {
        _logger.Debug("Cargando los items del archivo binario '{path}'", path);
        if (!File.Exists(path)) {
            _logger.Warning("El archivo '{path}' no existe. No se puede cargar el archivo.",  path);
            throw new FileNotFoundException($"El archivo '{path}' no existe.");
        }
        
        using var stream = File.OpenRead(path);
        using var reader = new BinaryReader(stream, Encoding.UTF8);
        
        var count = reader.ReadInt32();
        var vehiculo = new List<Vehiculo>();

        for (var i = 0; i < count; i++) {
            var dto = new VehiculoDto(
                reader.ReadInt32(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadDouble(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadString(),
                reader.ReadBoolean()
            );
        }
        return vehiculo;
    }


    private void InitStorage() {
        if (Directory.Exists(Configuracion.DataFolder))
            return;
        _logger.Debug("El directorio 'data' no existe. Creandolo...");
        Directory.CreateDirectory(Configuracion.DataFolder)
    }
}