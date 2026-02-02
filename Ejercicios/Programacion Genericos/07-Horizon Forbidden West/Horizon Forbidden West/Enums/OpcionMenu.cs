namespace Horizon_Forbidden_West.Enums;


public enum OpcionMenu {
    Salir = 0,

    // --- BLOQUE DE ACCESO GLOBAL (Protocolos de Red) ---
    ListarTodas = 1,
    BuscarCodigoGaia = 2,
    BuscarId = 3,

    // --- BLOQUE DE MÁQUINAS (Base de Datos Robótica) ---
    ListarMaquinas = 4,
    AnadirMaquina = 5,
    ActualizarMaquina = 6,
    EliminarMaquina = 7,
    InformePeligrosidad = 8, // Informe específico de amenazas

    // --- BLOQUE DE CAZADORES (Registros Tribales) ---
    ListarCazadores = 9,
    AnadirCazador = 10,
    ActualizarCazador = 11,
    EliminarCazador = 12,
    InformeTribal = 13,      // Informe agrupado por tribus

    // --- BLOQUE DE SABOTEADORES (Perfiles Tecnológicos) ---
    ListarSaboteadores = 14,
    AnadirSaboteador = 15,
    ActualizarSaboteador = 16,
    EliminarSaboteador = 17,
    InformeCapacidades = 18  // Informe por años de experiencia y certificados
}