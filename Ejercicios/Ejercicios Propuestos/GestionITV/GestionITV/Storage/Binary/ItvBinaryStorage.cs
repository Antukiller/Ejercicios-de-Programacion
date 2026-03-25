using System.Text;
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
        throw new NotImplementedException();
    }
}