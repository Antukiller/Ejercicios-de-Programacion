namespace GestionITV.Enum;

/// <summary>
/// Opciones del menú principal organizadas jerárquicamente.
/// </summary>
public enum OpcionMenu {
    Salir = 0,
    
    // Bloque General 
    ListarTodos = 1,
    BuscarPorId = 2,
    BuscarPoDniPropietario = 3,
    
    // Bloque de Vehiculos
    ListarVehiculos = 4,
    AnadirVehiculo = 5,
    ActualizarVehiculo = 6,
    EliminarVehiculo = 7,
    InformeVehiculo = 8,
    
    // Importar/Exportar
    ImportarDatos = 9,
    ExportarDatos = 10,
    
    // Backup 
    RealizarBackup = 11,
    RestaurarBackup = 12
}