using LaBoticaria.Enums;

namespace LaBoticaria;

public record class CasoMedico(
    int Id, 
    IEnumerable<(string Nombre, int Riesgo, string Organo, string Descripcion)>  SintomasObservados,
    DateTime FechaInicio,
    CausaSospecha Causa,
    EstadoInvestigacion Investigacion,
    Gravedad Transcendencia,
    DateTime CreateAt,
    DateTime UpdateAt,
    bool IsDeleted
);