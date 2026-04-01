using GestionITV.Exceptions.Common;

namespace GestionITV.Exceptions;

public abstract class VehiculoException(string message) : DomainException(message) {
    
    /// <summary>
    /// Se lanza cuando no existe el registro solicitado
    /// </summary>
    /// <param name="id"></param>
    public sealed class NotFound(string id)
        : VehiculoException($"No se ha encontrado ninguna persona con el iddentificado: {id}");
    
    
}