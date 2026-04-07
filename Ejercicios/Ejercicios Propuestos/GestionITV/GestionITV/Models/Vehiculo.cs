using GestionITV.Enum;

namespace GestionITV.Models;

/// <summary>
///  Clase record vehiculo
/// </summary>
/// <param name="Matricula"></param>
/// <param name="Marca"></param>
/// <param name="Modelo"></param>
/// <param name="Cilindrada"></param>
/// <param name="Motor"></param>
/// <param name="DniPropietario"></param>
public record Vehiculo {
    public int Id { get; init; }
    public string Matricula { get; init; }
    public string Marca { get; init; }
    public string Modelo { get; init; }
    public double Cilindrada { get; init; }
    public Motor Motor { get; init; }
    public string DniPropietario { get; init; }
    public DateTime CreateAt { get; init; }
    public DateTime UpdateAt { get; init; }
    public bool IsDeleted { get; init; }



    public virtual bool Equals(Vehiculo? other) {
        return other is not null && string.Equals(Matricula, other.Matricula, StringComparison.CurrentCultureIgnoreCase);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Matricula.ToLowerInvariant());
    }
}