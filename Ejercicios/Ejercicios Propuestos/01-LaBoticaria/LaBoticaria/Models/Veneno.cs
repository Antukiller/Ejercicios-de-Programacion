using LaBoticaria.Enums;

namespace LaBoticaria;

public sealed record Veneno(
    int Id,
    string Nombre,
    string Descripcion,
    int Precio,
    Disponibilidad Rareza,
    NivelPeligro Peligro,
    DateTime CreateAt,
    DateTime UpdateAt,
    bool IsDeleted,
    ViaAdministracion Suministro,
    int TiempoAparicion,
    IEnumerable<(string Nombre, int Riesgo, string Organo, string Descripcion)> ListaSintomas,
    double GradoToxicidad,
    int ProbalidadSupevivencia
): Sustancia(Id, Nombre, Descripcion, Precio, Rareza, Peligro, CreateAt, UpdateAt, IsDeleted), ITieneSintomas;