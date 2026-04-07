using System.Globalization;
using GestionITV.Dto;
using GestionITV.Enum;
using GestionITV.Models;

namespace GestionITV.Mapper;

public static class VehiculoMapper {

    private const string IsoFormat = "s";

    private static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;


    public static Vehiculo ToModel(this VehiculoDto dto) {
        var createdAt = DateTime.Parse(dto.CreatedAt, InvariantCulture);
        var updatedAt = DateTime.Parse(dto.UpdatedAt, InvariantCulture);

        return new Vehiculo {
            Id = dto.Id,
            Matricula = dto.Matricula,
            Marca = dto.Marca,
            Modelo = dto.Modelo,
            Cilindrada = dto.Cilindrada,
            Motor = System.Enum.TryParse(dto.Motor, out Motor tipo) ? tipo : Motor.Diesel,
            DniPropietario = dto.DniPropietario,
            CreateAt = createdAt,
            UpdateAt = updatedAt,
            IsDeleted = dto.IsDeleted
        }; // <-- Nota que aquí usamos llaves y asignaciones con '='
    }


    public static VehiculoDto ToDto(this Vehiculo vehiculo) {
        // 1. Añadimos el 'new VehiculoDto'
        // 2. Usamos el formato ISO que definiste arriba para las fechas
        return new VehiculoDto(
            vehiculo.Id,
            vehiculo.Matricula,
            vehiculo.Marca,
            vehiculo.Modelo,
            vehiculo.Cilindrada,
            vehiculo.Motor.ToString(),
            vehiculo.DniPropietario,
            vehiculo.CreateAt.ToString(IsoFormat, InvariantCulture), // Usa tu constante IsoFormat
            vehiculo.UpdateAt.ToString(IsoFormat, InvariantCulture),
            vehiculo.IsDeleted
        );
    }
}