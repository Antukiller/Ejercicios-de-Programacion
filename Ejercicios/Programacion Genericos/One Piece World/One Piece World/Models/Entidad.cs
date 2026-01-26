namespace One_Piece_World;

public record class Entidad {
    public int Id { get; init; } = 0;
    public string NombreCompleto { get; init; }
    public string Apodo { get; init; }


    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime UpdatedAt { get; init; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;


    public virtual bool Equals(Entidad? other) {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return NombreCompleto.Equals(other.NombreCompleto, StringComparison.OrdinalIgnoreCase) && Apodo.Equals(other.Apodo, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() {
        return HashCode.Combine(NombreCompleto, Apodo);
    }
}