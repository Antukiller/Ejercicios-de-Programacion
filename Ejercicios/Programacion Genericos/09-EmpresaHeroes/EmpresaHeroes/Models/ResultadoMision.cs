namespace EmpresaHeroes.Models;


/// <summary>
/// Contiene los datos estadísticos y el estado final tras la ejecución de una misión.
/// </summary>
public sealed record ResultadoMision {
    /// <summary>
    /// Indica si el poder del equipo superó el umbral de peligrosidad.
    /// </summary>
    public bool IsExito { get; init; }

    /// <summary>
    /// Listado de héroes que participaron en la misión.
    /// </summary>
    public IEnumerable<Heroe> EquipoParticipante { get; init; } = Enumerable.Empty<Heroe>();

    /// <summary>
    /// Suma total del poder de todos los integrantes (CalcularPoderTotal).
    /// </summary>
    public double PoderTotalEquipo { get; init; }

    /// <summary>
    /// Poder mínimo requerido para superar la misión (Dificultad * 50).
    /// </summary>
    public double UmbralRequerido { get; init; }

    /// <summary>
    /// Diferencia entre el poder del equipo y el umbral (Positivo = Sobrado, Negativo = Insuficiente).
    /// </summary>
    public double MargenPoder => PoderTotalEquipo - UmbralRequerido;

    /// <summary>
    /// Media de nivel de los héroes que conformaron el equipo.
    /// </summary>
    public double NivelMedioEquipo { get; init; }
}