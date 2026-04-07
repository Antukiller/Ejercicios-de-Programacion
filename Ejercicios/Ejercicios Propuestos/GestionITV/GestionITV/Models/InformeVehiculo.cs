namespace GestionITV.Models;

public sealed record InformeVehiculo {
    // Datos Identificativos
    public int Id { get; init; }
    public string Matricula { get; init; } = string.Empty;
    public string MarcaModelo { get; init; } = string.Empty; // Combinado para el informe
    
    // Datos Técnicos
    public string DatosMotor { get; init; } = string.Empty; // Ej: "1.9 Gasolina"
    public string PropietarioDni { get; init; } = string.Empty;
    
    // Estado y Fechas
    //public string FechaAlta { get; init; } = string.Empty; // Formateada para humanos
    //public string UltimaActualizacion { get; init; } = string.Empty;
    //public string Estado { get; init; } = string.Empty; // Ej: "Activo" o "Baja"
}