namespace EmpresaHeroes.Exceptions.Common;

public abstract class MisionException(string message) : DomainException(message) {
    /// <summary>Se lanza cuando no existe el registro solicitado.</summary>
    public sealed class NotFound(string id)
        : MisionException($"No se ha encontrado ninguna persona con el identificador: {id}");

    /// <summary>Se lanza cuando fallan las reglas de validación de negocio.</summary>
    public sealed class Validation(IEnumerable<string> errors)
        : MisionException("Se han detectado errores de validación en la entidad.") {
        public IEnumerable<string> Errores { get; init; } = errors;
    }

    /// <summary>Se lanza ante conflictos de duplicidad (DNI).</summary>
    public sealed class AlreadyExists(string dni)
        : MisionException($"Conflicto de integridad: El DNI {dni} ya está registrado en el sistema.");
    
    
    /// <summary>Se lanza cuando se intenta realizar una acción no permitida por el estado actual.</summary>
    public sealed class InvalidOperation(string mensaje) 
        : MisionException(mensaje);
}