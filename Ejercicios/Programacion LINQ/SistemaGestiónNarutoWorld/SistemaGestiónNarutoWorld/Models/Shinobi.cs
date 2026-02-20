using SistemaGestiónNarutoWorld.Enums;

namespace SistemaGestiónNarutoWorld.Models;

/// <summary>
/// Clase abstracta Shinobi
/// </summary>
/// <param name="Id"></param>
/// <param name="DniNinja"></param>
/// <param name="Nombre"></param>
/// <param name="Aldea"></param>
/// <param name="AñoGraduacion"></param>
public abstract record Shinobi(int Id, string DniNinja, string Nombre, AldeaNinja Aldea, int AñoGraduacion);

