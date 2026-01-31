namespace Horizon_Forbidden_West.Models;

public abstract record EntidadHorizon {
    public int Id { get; init; }
    public string Nombre { get; init; } = string.Empty;
    public string CodigoGaia { get; init; } = string.Empty;
    public string Descripcion { get; init; }  = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public bool IsDeleted { get; init; }

    public string NombreCompleto => $"{Nombre}, {Descripcion}";

    public virtual bool Equals(EntidadHorizon other) {
        return other is not null && string.Equals(CodigoGaia, other.CodigoGaia, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() {
        return HashCode.Combine(CodigoGaia.ToLowerInvariant());
    }
}