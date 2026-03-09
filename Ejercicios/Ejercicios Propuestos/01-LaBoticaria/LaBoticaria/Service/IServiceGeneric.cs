using System.Collections;

namespace LaBoticaria.Service;

public interface IServiceGeneric {
    // Propiedades estadísticas simples
    int TotalSustancia { get; }
    int TotalCasoMedico { get; }

    // --- MÉTODOS PARA SUSTANCIAS ---
    IEnumerable<Sustancia> GetAllSustancias();
    Sustancia GetByIdSustancia(int id); // Añadido ?
    Sustancia SaveSustancia(Sustancia sustancia);
    Sustancia UpdateSustancia(int id, Sustancia sustancia); // Añadido ?
    Sustancia DeleteSustancia(int id); // Añadido ?
    InformeSustancias GenerarInformeSustancias();

    // --- MÉTODOS PARA CASOS MÉDICOS ---
    IEnumerable<CasoMedico> GetAllCasoMedicos();
    CasoMedico GetByIdCasoMedico(int id); // Añadido ?
    CasoMedico SaveCasoMedico(CasoMedico casoMedico);
    CasoMedico UpdateCasoMedico(int id, CasoMedico casoMedico); // Añadido ?
    CasoMedico DeleteCasoMedico(int id); // Añadido ?
    InformeCasosMedicos GenerarInformeCasosMedicos(); // Cambiado a plural para ser iguales
}