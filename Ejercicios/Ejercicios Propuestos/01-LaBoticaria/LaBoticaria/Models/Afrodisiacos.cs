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
    List<(string Nombre, int Riesgo, string Descripcion)> ListaContradicciones,
    List<(string Nombre, int Riesgo, string Descripcion)> ListaRiesgosExcivos
) : Sustancia(Id, Nombre, Descripcion, Precio, Rareza, Peligro, CreateAt, UpdateAt, IsDeleted);
        