using LaBoticaria.Enums;

namespace LaBoticaria;

public sealed record Medicina(
    int Id,
    string Nombre,
    string Descripcion,
    int Precio,
    Disponibilidad Rareza,
    NivelPeligro Peligro,
    DateTime CreateAt,
    DateTime UpdateAt,
    bool IsDeleted,
    IEnumerable<(string Nombre, int Riesgo, string Organo, string Descripcion)> ListaSintomas,
    int DosisRecomendada,
    IEnumerable<(string Nombre, int Riesgo, string Organo, string Descripcion)> ListaEfectosSecundarios,
    int TiempoEfecto
) : Sustancia(Id, Nombre, Descripcion, Precio, Rareza, Peligro, CreateAt, UpdateAt, IsDeleted), ITieneSintomas;
