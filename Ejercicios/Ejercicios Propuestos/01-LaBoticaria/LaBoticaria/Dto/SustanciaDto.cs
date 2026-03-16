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
    [property: XmlAttribute("nivelpeligro")] string NivelPeligro,
    [property: XmlAttribute("listaSintomas")] string? listaSintomasMedicina,
    [property: XmlAttribute("dosisRecomendad")] int? dosisRecomendada,
    [property: XmlAttribute("listaEfectosSecundarios")] string? listaEfectosSecundarios,
    [property: XmlAttribute("tiempoEfecto")] int? tiempoEfecto,
    [property: XmlAttribute("viaAdministracion")] string? viaAdministracion,
    [property: XmlAttribute("tiempoAparicion")] int? TiempoAparicion,
    [property: XmlAttribute("listaSintomas")] string? listaSintomasVeneno,
    [property: XmlAttribute("gradoToxicidad")] string? gradoToxicidad,
    [property: XmlAttribute("probabilidadSupervivencia")] int? probabilidadSupervivencia,
    [property: XmlAttribute("intensidadEfecto")] string? intensidadEfecto,
    [property: XmlAttribute("duracion")]
    [property: XmlAttribute("createAt")] string CreateAt,
    [property: XmlAttribute("updateAt")] string UpdateAt,
    [property: XmlAttribute("isDeleted")] bool IsDeleted
) {
    public SustanciaDto(0, "", "", )
}