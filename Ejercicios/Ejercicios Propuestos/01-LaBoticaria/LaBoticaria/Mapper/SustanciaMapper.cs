using System.Globalization;
using LaBoticaria.Dto;
using LaBoticaria.Enums;

namespace LaBoticaria.Mapper;

public static class SustanciaMapper {
    private const string IsoFormat = "s";
    private static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;


    public static Sustancia ToModel(this SustanciaDto dto) {
        var createAt = DateTime.Parse(dto.CreateAt, InvariantCulture);
        var updateAt = DateTime.Parse(dto.UpdateAt, InvariantCulture);
        return dto.Tipo switch {
            "Medicina" => new Medicina {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio =  dto.Precio,
                Disponibilidad = Enum.TryParse(dto.Disponibilidad, out Disponibilidad disponibilidad ) ? disponibilidad : Disponibilidad.Rara,
                NivelPeligro = Enum.TryParse(dto.NivelPeligro, out NivelPeligro peligro) ? peligro : NivelPeligro.Bajo,
                ListaSintomas = dto.ListaSintomasMedicina.Cast<string>().Select(s => TraducirSintoma(s)).ToList(),
                DosisRecomendada = dto.DosisRecomendada ?? 0,
                ListaEfectosSecundarios = dto.ListaEfectosSecundarios.Cast<string>().Select(s => TraducirEfectoSecundario(s)).ToList(),
                TiempoEfecto = dto.TiempoEfecto ?? 0,
                CreateAt =  createAt,
                UpdateAt = updateAt,
                IsDeleted = dto.IsDeleted
            },
            
            "Afrodisiaco" => new Afrodisiacos {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio =  dto.Precio,
                Disponibilidad = Enum.TryParse(dto.Disponibilidad, out Disponibilidad disponibilidad ) ? disponibilidad : Disponibilidad.Rara,
                NivelPeligro = 
                
            }
            
        }
    }

    
    