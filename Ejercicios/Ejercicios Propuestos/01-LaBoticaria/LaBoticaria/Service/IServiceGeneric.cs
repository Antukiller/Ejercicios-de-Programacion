using System.Collections;

namespace LaBoticaria.Service;

public interface IServiceGeneric {
    // Propiedades estadísticas simples
    int TotalSustancia { get; }
    int TotalCasoMedico { get; }

    // --- MÉTODOS PARA SUSTANCIAS ---
    IEnumerable<Sustancia> GetAllSustancias();
    Sustancia GetByIdSustancia(int id);
    Sustancia SaveSustancia(Sustancia sustancia);
    Sustancia UpdateSustancia(int id, Sustancia sustancia); 
    Sustancia DeleteSustancia(int id, Sustancia sustancia);
    InformeSustancias GenerarInformeSustancias();

    // --- MÉTODOS PARA CASOS MÉDICOS ---
    IEnumerable<CasoMedico> GetAllCasoMedicos();
    CasoMedico GetByIdCasoMedico(int id);
    CasoMedico SaveCasoMedico(CasoMedico casoMedico);
    CasoMedico UpdateCasoMedico(int id, CasoMedico casoMedico); 
    CasoMedico DeleteCasoMedico(int id, CasoMedico casoMedico); 
    InformeCasosMedicos GenerarInformeCasosMedicos();
}