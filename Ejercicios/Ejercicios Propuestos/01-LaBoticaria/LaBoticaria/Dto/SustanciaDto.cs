using System.Xml.Serialization;

namespace LaBoticaria.Dto;

[XmlRoot("LaBoticaria")]
[XmlType("Sustancia")]
public record SustanciaDto(
    [property: XmlAttribute("id")] int Id,
    [property: XmlAttribute("nombre")] string Nombre,
    [property: XmlAttribute("descripcion")] string Descripcion,
    [property: XmlAttribute("precio")] int Precio,
    [property: XmlAttribute("disponibilidad")] string Disponibilidad,
    [property: XmlAttribute("nivelPeligro")] string NivelPeligro,
    [property: XmlAttribute("tipo")] string Tipo,
    [property: XmlAttribute("listaSintomas")] string? ListaSintomasMedicina,
    [property: XmlAttribute("dosisRecomendada")] int? DosisRecomendada,
    [property: XmlAttribute("listaEfectosSecundarios")] string? ListaEfectosSecundarios,
    [property: XmlAttribute("tiempoEfecto")] int? TiempoEfecto,
    [property: XmlAttribute("viaAdministracion")] string? ViaAdministracion,
    [property: XmlAttribute("tiempoAparicion")] int? TiempoAparicion,
    [property: XmlAttribute("listaSintomas")] string? ListaSintomasVeneno,
    [property: XmlAttribute("gradoToxicidad")] string? GradoToxicidad,
    [property: XmlAttribute("probabilidadSupervivencia")] int? ProbabilidadSupervivencia,
    [property: XmlAttribute("intensidadEfecto")] string? IntensidadEfecto,
    [property: XmlAttribute("duracion")] int?  Duracion,
    [property: XmlAttribute("listaContradiciones")] string? ListaContradiciones,
    [property: XmlAttribute("listaRiesgos")] string? ListaRiesgos,
    [property: XmlAttribute("createAt")] string CreateAt,
    [property: XmlAttribute("updateAt")] string UpdateAt,
    [property: XmlAttribute("isDeleted")] bool IsDeleted
) {
    public SustanciaDto() : this(0, "", "", 0, "", "", "", null, null, null, null, null, null, null, null, null, null, null, null, null, "", "", false) { }
}