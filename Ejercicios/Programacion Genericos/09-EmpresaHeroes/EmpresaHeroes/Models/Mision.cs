using EmpresaHeroes.Enums;

namespace EmpresaHeroes.Models;


/// <summary>
/// Clase Mision
/// </summary>
public class Mision {
    public string Nombre { get; set; }
    public DificultadadMision Peligrosidad { get; set; }
    public bool IsCompletada { get; set; }
    public HashSet<Heroe> Equipo { get; set; } = new();

    
    public double PoderRequerido => (int)Peligrosidad * 25;
    
}