namespace Horizon_Forbidden_West.Enums;


public enum TipoOrdenamiento {
    Id,                 // Orden numérico de registro
    CodigoGaia,         // Orden alfabético por código de serie (CZR, SAB, MAQ)
    Nombre,             // Orden alfabético por nombre del modelo o persona
    Peligrosidad,       // De Amenaza Mínima a Extrema (Máquinas)
    Tribu,              // Agrupado por facción cultural (Cazadores)
    Experiencia,        // Por años de veteranía (Saboteadores)
    Tipo,               // Por clase de máquina (Lidia, Transporte, etc.)
    Debilidad,          // Por elemento (Hielo, Fuego, etc.)
    Certificado         // Por nivel de Caldero (Saboteadores)
}