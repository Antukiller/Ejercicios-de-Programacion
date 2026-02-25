using SistemaGestiónNarutoWorld.Enums;

namespace SistemaGestiónNarutoWorld.Models;

/// <summary>
/// Clase hija Shinobi de Elite
/// </summary>
/// <param name="Id"></param>
/// <param name="DniNinja"></param>
/// <param name="Aldea"></param>
/// <param name="Nombre"></param>
/// <param name="Edad"></param>
/// <param name="ElementoPrincipal"></param>
/// <param name="tieneKekkeiGenkai"></param>
public record ShinobiElite(
    int Id, 
    string DniNinja, 
    AldeaNinja Aldea, 
    string Nombre, 
    int Edad,
    DateTime CreateAt,
    DateTime UpdateAt,
    bool IsDeleted,
    ElementoNinja ElementoPrincipal,
    bool TieneKekkeiGenkai
) : Shinobi(Id, DniNinja, Nombre, Aldea, Edad, CreateAt, UpdateAt, IsDeleted);