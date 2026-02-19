namespace ConsultasSoloLeveling.Models;

public record Hunter(
    int Id, 
    string Nombre, 
    string Rango, // S, A, B, C, D, E
    string Clase, // Monarca, Asesino, Tanque, Sanador, Mago
    string Gremio, 
    int Nivel, 
    bool EstaVivo
);