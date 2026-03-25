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

        return new Vehiculo (
            dto.Id,
            dto.Matricula,
            dto.Marca,
            dto.Modelo,
            dto.Cilindrada,
            System.Enum.TryParse(dto.Motor, out Motor tipo ) ? tipo : Motor.Diesel ,
            dto.DniPropietario,
            createdAt,
            updatedAt,
            dto.IsDeleted
        );
    }


    public static VehiculoDto ToDto(this Vehiculo vehiculo) {
        return vehiculo(
            vehiculo.Id,
            vehiculo.Matricula,
            vehiculo.Marca,
            vehiculo.Modelo,
            vehiculo.Cilindrada,
            vehiculo.Motor.ToString(),
            vehiculo.DniPropietario,
            vehiculo.CreateAt.ToString(),
            vehiculo.UpdateAt.ToString(),
            vehiculo.IsDeleted
        );
    }
}