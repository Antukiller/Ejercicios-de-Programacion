using LaBoticaria.Enums;

namespace LaBoticaria;

public class CasoMedico {
    public int Id { get; set; } = IdCounter.NextId();
    public List<(string Nombre, int Riesgo, string Organo, string Descripcion)>  SintomasObservados { get; set; }
    public DateTime FechaInicio { get; set; }
    public CausaSospecha Causa { get; set; }
    public EstadoInvestigacion Investigacion { get; set; }
    public Gravedad Transcendencia { get; set; }
    
    
}