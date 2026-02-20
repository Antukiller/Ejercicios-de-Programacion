using SistemaGestiónNarutoWorld.Enums;

namespace SistemaGestiónNarutoWorld.Models;
/// <summary>
///  Clase hija Shinobi Rastreador
/// </summary>
/// <param name="Id"></param>
/// <param name="DniNinja"></param>
/// <param name="Aldea"></param>
/// <param name="Nombre"></param>
/// <param name="AñoGraduacion"></param>
/// <param name="VelocidadDesplazamiento"></param>
/// <param name="Metodo"></param>
/// <param name="RangoDeteccionKm"></param>
public record ShinobiRastreador(
    int Id,
    string DniNinja,
    AldeaNinja Aldea, 
    string Nombre, 
    int AñoGraduacion, 
    int VelocidadDesplazamiento,
    MetodoRastreo Metodo, // <--- Enum
    int RangoDeteccionKm
) : Shinobi(Id, DniNinja, Nombre, Aldea, AñoGraduacion);