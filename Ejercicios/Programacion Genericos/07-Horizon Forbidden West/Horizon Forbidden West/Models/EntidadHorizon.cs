namespace Horizon_Forbidden_West.Models;

public record class EntidadHorizon {
    public int Id { get; init; }
    public string Nombre { get; init; } = string.Empty;
    public string CodigoGaia { get; init; } = string.Empty;
    public string Descripcion { get; init; }  = string.Empty;
        
    
}