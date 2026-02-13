namespace TheWictherContracts.Models;

public abstract record ContratoBase(int id, string titulo, int nivelRecomendado, double recompensa) {
    public int Id { get; init; } = id;
    public string Titulo { get; init; }  
    public int NivelRecomendado { get; init; }
    public double Recompensa { get; init; }
    
}