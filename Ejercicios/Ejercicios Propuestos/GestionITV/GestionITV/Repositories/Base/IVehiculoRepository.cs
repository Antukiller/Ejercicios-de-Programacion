using GestionITV.Models;
using GestionITV.Repositories.Common;

namespace GestionITV.Repositories.Base;

/// <summary>
/// Contratro especializado para la gestion de vehiculos.
/// Define las propiedades de búsqueda, persistencia y validación de identidad. 
/// </summary>
public interface IVehiculoRepository : ICrudRepository<int, Vehiculo> {
    /// <summary>
    /// Realiza una busqueda por el DNI del propietario para obtener el vehiculos o los vehiculos pertenecientes.
    /// </summary>
    /// <param name="dni"> DNI a localizar</param>
    /// <returns>El propietario asociado al DNI o null</returns>
    IEnumerable<Vehiculo>? GetByDniPropietario(string dni);
    
    
    /// <summary>
    /// Verifica si el DNI ya se encuentra registrado y activo en el sistema.
    /// </summary>
    /// <param name="dni">DNI a comprobar</param>
    /// <returns>True si el DNI está en uso; de lo contraio, false.</returns>
    bool ExisteDni(string dni);
    
    
    /// <summary>
    /// Elimina todos los vehiculos del sistema, incluyendo los marcados como eliminados, pero de manera permanente.  
    /// </summary>
    /// <returns>True si se elimina todos los vehiculos; de lo contrario, false </returns>
    /// <remarks>Esta operacion es irreversible y eliminará permanentemente la informacion de los vehiculos</remarks>
    bool DeleteAll();
}