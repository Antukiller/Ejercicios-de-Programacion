using LaBoticaria.Enums;

namespace LaBoticaria;

public record Medicina(
    int Id,
    string Nombre,
    string Descripcion,
    int Precio,
    Disponibilidad Rareza,
    NivelPeligro Peligro,
    DateTime CreateAt,
    DateTime UpdateAt,
    bool IsDeleted,
    string Sintomas,
    int DosisRecomendada,
    string EfectosSecundarios,
    int TiempoEfecto
) : Sustancia(Id, Nombre, Descripcion, Precio, Rareza, Peligro, CreateAt, UpdateAt, IsDeleted);
