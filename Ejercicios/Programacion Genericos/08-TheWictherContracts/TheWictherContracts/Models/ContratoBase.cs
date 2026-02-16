namespace TheWictherContracts.Models;

public abstract record ContratoBase(int id, string titulo, int nivelRecomendado, double recompensa) {
    public int Id { get; init; } = id;
    public string Titulo { get; init; }  
    public int NivelRecomendado { get; init; }
    public int Recompensa { get; init; }
    
    public DateTime CreateAt { get; init; }
    
    public DateTime UpdateAt { get; init; }
    
    public bool IsDeleted { get; init; }
    
}