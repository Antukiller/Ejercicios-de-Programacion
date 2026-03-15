using LaBoticaria.Enums;

namespace LaBoticaria;

public sealed record Afrodisiacos(
    int Id,
    string Nombre,
    string Descripcion,
    int Precio,
    Disponibilidad Rareza,
    NivelPeligro Peligro,
    DateTime CreateAt,
    DateTime UpdateAt,
    bool IsDeleted,
    IntensidadEfecto CategoriaEfecto,
    int Duracion,
    IEnumerable<(string Nombre, int Riesgo, string Descripcion)> ListaContradicciones,
    IEnumerable<(string Nombre, int Riesgo, string Organo, string Descripcion)> ListaRiesgosExcivos
) : Sustancia(Id, Nombre, Descripcion, Precio, Rareza, Peligro, CreateAt, UpdateAt, IsDeleted);
        