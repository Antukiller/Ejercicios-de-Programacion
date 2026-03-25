using System.Xml.Serialization;

namespace GestionITV.Dto;

[XmlRoot("Itv")]
[XmlType("Vehiculo")]
public record VehiculoDto(
    [property: XmlAttribute("id")] int Id,
    [property: XmlElement("matricula")] string Matricula,
    [property: XmlElement("marca")] string Marca,
    [property: XmlElement("modelo")] string Modelo,
    [property: XmlElement("cilindrada")] double Cilindrada,
    [property: XmlElement("motor")] string Motor,
    [property: XmlElement("dniPropietario")] string DniPropietario,
    [property: XmlElement("createdAt")] string CreatedAt,
    [property: XmlElement("updatedAt")] string UpdatedAt,
    [property: XmlElement("isDeleted")] bool IsDeleted
) {
    public VehiculoDto() : this(0, "", "", "", 0.0, "", "", "", "", false) { }
}