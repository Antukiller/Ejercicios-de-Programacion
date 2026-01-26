namespace GestionBiblioteca.Models;

public record class Ficha {
    public int Id { get; init; } = 0;
    public string Titulo { get; init; }
    public string Estante { get; init; }
    
    
    // metadatos para auditoria
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;

    public virtual bool Equals(Ficha? other) {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Titulo.Equals(other.Titulo, StringComparison.OrdinalIgnoreCase) && Estante.Equals(other.Estante, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Titulo, Estante);
    }
}