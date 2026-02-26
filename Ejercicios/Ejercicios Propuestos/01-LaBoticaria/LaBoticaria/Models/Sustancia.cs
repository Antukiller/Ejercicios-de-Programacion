using LaBoticaria.Enums;

namespace LaBoticaria;

/// <summary>
/// Clase abstracta Sustancia
/// </summary>
/// <param name="Id"></param>
/// <param name="Nombre"></param>
/// <param name="Precio"></param>
/// <param name="Rareza"></param>
/// <param name="Peligro"></param>
/// <param name="CreateAt"></param>
/// <param name="UpdateAt"></param>
/// <param name="IsDeleted"></param>
public abstract record Sustancia(
int Id,
string Nombre,
string Descripcion,
int Precio,
Disponibilidad Rareza,
NivelPeligro Peligro,
DateTime CreateAt,
DateTime UpdateAt,
bool IsDeleted
);