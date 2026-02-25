using SistemaGestiónNarutoWorld.Enums;

namespace SistemaGestiónNarutoWorld.Models;

/// <summary>
/// Clase hija Jinchuriki
/// </summary>
/// <param name="ID"></param>
/// <param name="DniNinja"></param>
/// <param name="Aldea"></param>
/// <param name="Nombre"></param>
/// <param name="Edad"></param>
/// <param name="NivelControlBestia"></param>
/// <param name="Bestia"></param>
/// <param name="ColasManifestadas"></param>
public record Jinchuriki(
    int Id,
    string DniNinja,
    AldeaNinja Aldea, 
    string Nombre, 
    int Edad,
    DateTime CreateAt,
    DateTime UpdateAt,
    bool IsDeleted,
    double NivelControlBestia, 
    NombreBestia Bestia, // <--- Enum
    int ColasManifestadas
) : Shinobi(Id, DniNinja, Nombre, Aldea, Edad, CreateAt, UpdateAt, IsDeleted);