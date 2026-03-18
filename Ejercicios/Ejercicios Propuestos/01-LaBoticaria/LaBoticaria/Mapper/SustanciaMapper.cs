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

    
    
    private static (string Nombre, int Riesgo, string Organo, string Descripcion) TraducirSintoma(string nombreSintoma) 
        => nombreSintoma.ToLower().Trim() switch
        {
            "fiebre militar"      => Sintomas.FiebreMiliar,
            "ictericia biliar"    => Sintomas.IctericiaBiliar,
            "afasia temporal"     => Sintomas.AfasiaTemporal,
            "hemoptisis"          => Sintomas.Hemoptisis,
            "midriasis"           => Sintomas.Midriasis,
            "arritmia severa"     => Sintomas.ArritmiaSevera,
            "edema renal"         => Sintomas.EdemaRenal,
            "cianosis"            => Sintomas.Cianosis,
            "melena"              => Sintomas.Melena,
            "tinnitus"            => Sintomas.Tinnitus,
            "disnea"              => Sintomas.Disnea,
            "prurito intenso"     => Sintomas.PruritoIntenso,
            "parestesia"          => Sintomas.Parestesia,
        
            // Pattern matching con "OR" (puedes usar el símbolo '|')
            "síncope" or "sincope" => Sintomas.Sincope,
        
            "inapetencia" or "inapetencia absoluta" => Sintomas.Inapetencia,

            // El descarte (discard) '_' funciona como el 'default'
            _ => ("Desconocido", 0, "Nulo", $"No se reconoce: {nombreSintoma}")
        };
    
    private static (string Nombre, int Riesgo, string Organo, string Descripcion) TraducirEfectoSecundario(string nombreEfecto)
        => nombreEfecto.ToLower().Trim() switch
        {
            "somnolencia" or "somnolencia profunda" => EfectosSecundarios.Somnolencia,
            "xerostomía" or "xerostomia"            => EfectosSecundarios.Xerostomia,
            "vértigo posicional" or "vertigo"       => EfectosSecundarios.VertigoPosicional,
            "fotosensibilidad"                      => EfectosSecundarios.Fotosensibilidad,
            "hiperactividad" or "frenesí nervioso"  => EfectosSecundarios.Hiperactividad,
            "bradicardia"                           => EfectosSecundarios.Bradicardia,
            "urticaria" or "urticaria idiopática"   => EfectosSecundarios.UrticariaIdiopatica,
            "cefalea tensional" or "cefalea"        => EfectosSecundarios.CefaleaTensional,
            "glositis" or "glositis alérgica"       => EfectosSecundarios.Glositis,
            "diaforesis" or "diaforesis profusa"    => EfectosSecundarios.Diaforesis,
            "alucinaciones"                         => EfectosSecundarios.Alucinaciones,
            "disgeusia"                             => EfectosSecundarios.Disgeusia,
            "espasmos musculares" or "espasmos"     => EfectosSecundarios.EspasmosMusculares,
            "poliuria"                              => EfectosSecundarios.Poliuria,
            "irritabilidad"                         => EfectosSecundarios.Irritabilidad,

            // Caso por defecto si no lo encuentra
            _ => ("Efecto Desconocido", 0, "Nulo", $"No se reconoce el efecto: {nombreEfecto}")
        };
}