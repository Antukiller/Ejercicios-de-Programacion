using LaBoticaria.Exceptions.Common;

namespace LaBoticaria.Exceptions;


/// <summary>
///     Contenedor de excepciones específicas para el dominio de Personas.
/// </summary>
public abstract class CasoMedicoException(string message) : DomainException(message) {
    /// <summary>Se lanza cuando no existe el registro solicitado.</summary>
    public sealed class NotFound(string id)
        : CasoMedicoException($"No se ha encontrado ningun caso medico con el identificador: {id}");

    /// <summary>Se lanza cuando fallan las reglas de validación de negocio.</summary>
    public sealed class Validation(IEnumerable<string> errors)
        : CasoMedicoException("Se han detectado errores de validación en la entidad.") {
        public IEnumerable<string> Errores { get; init; } = errors;
    }
    
    public sealed class AlreadyExists(string nombre)
        : CasoMedicoException($"Conflicto de integridad: EL caso medico con nombre '{nombre}' ya está registrada.");
}