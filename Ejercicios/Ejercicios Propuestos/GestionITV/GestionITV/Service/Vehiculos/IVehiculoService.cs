using GestionITV.Enum;
using GestionITV.Models;

namespace GestionITV.Service.Vehiculos;


/// <summary>
/// Contrato para el servicio integral de vehículos.
/// Define la lógica de negocio, validaciones y orquestación de informes
/// Todos los métodos de consulta devuelven IEnumerable para máximo desacoplamiento.
/// </summary>
public interface IVehiculoService {
    /// <summary>
    /// Obtiene el total de los vehículos activos en el sistema.
    /// </summary>
    int TotalVehiculos { get; }
    
    /// <summary>
    /// Devuelve la lista complet de los vehículos activos
    /// </summary>
    /// <returns>Enumerable con todos los vehívulos activos</returns>
    IEnumerable<Vehiculo> GetAll();
    
    
    /// <summary>
    /// Devuelve el listado completo aplicando ordenamiento y flitros opcionales.
    /// </summary>
    /// <param name="orden">Criterio de ordenamiento para el listado.</param>
    /// <param name="filtro">Predicado opcional para filtrar los resultados.</param>
    /// <returns>Enumerable con las personas que cumplen los requisitos</returns>
    IEnumerable<Vehiculo> GetAllOrderBy(TipoOrdenamiento orden = TipoOrdenamiento.DniPropietario,
        Predicate<Vehiculo>? filtro = null);
    
    /// <summary>
    /// Localiza una persona activa por su identificador único.
    /// </summary>
    /// <param name="id">Identificador numérico de la persona</param>
    /// <returns>La instancia de <see cref="Vehiculo" />econtrado.</returns>
    /// <exception cref="VehiculoException.NotFound">Se lanza si el identificador no existe</exception>
    Vehiculo GetById(int id);


    /// <summary>
    /// Localiza al propietario del vehiculo/ vehículos por su Documento Nacional de Indentidad.
    /// </summary>
    /// <param name="dniPropietario">DNI del propietario a buscar</param>
    /// <returns>La instancia de <see cref="Vehiculo"/> asociado al DNI.</returns>
    /// <exception cref="VehiculoException.NotFound">Se lanza si el DNI no correponde al propietario o al vheiculo buscado</exception>
    IEnumerable<Vehiculo> GetByDniPropietario(string dniPropietario);
    
    
    Vehiculo Save(Vehiculo vehiculo);
    
    Vehiculo Update(int id, Vehiculo vehiculo);
    
    Vehiculo Delete(int id);
    
    
    IEnumerable<InformeVehiculo> GenerarTodosInformeVehiculo();

    InformeVehiculo GenerarInformeVehiculPorId(int id);

    int ImportarDatos();
    
    int ExportarDatos();


    string RealizarBackup();
    
    int RestaurarBackup(string archivoBackup);
    
    IEnumerable<string> ListarBackups();
}