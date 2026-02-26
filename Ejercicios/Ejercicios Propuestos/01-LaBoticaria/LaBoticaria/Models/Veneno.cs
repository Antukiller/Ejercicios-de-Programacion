using LaBoticaria.Enums;

namespace LaBoticaria;

public record Veneno(
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
    string Antidoto,
    double GradoToxicidad,
    int ProbrobalidadSupevivencia
): Sustancia(Id, Nombre, Descripcion, Precio, Rareza, Peligro, CreateAt, UpdateAt, IsDeleted);