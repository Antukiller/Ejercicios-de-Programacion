using LaBoticaria.Exceptions.Common;

namespace LaBoticaria.Exceptions;


/// <summary>
///     Contenedor de excepciones específicas para el dominio de Personas.
/// </summary>
public abstract class SustanciaException(string message) : DomainException(message) {
    /// <summary>Se lanza cuando no existe el registro solicitado.</summary>
    public sealed class NotFound(string id)
        : SustanciaException($"No se ha encontrado ninguna sustancia con el identificador: {id}");

    /// <summary>Se lanza cuando fallan las reglas de validación de negocio.</summary>
    public sealed class Validation(IEnumerable<string> errors)
        : SustanciaException("Se han detectado errores de validación en la entidad.") {
        public IEnumerable<string> Errores { get; init; } = errors;
    }

    /// <summary>Se lanza cuando el nombre de la sustancia ya existe.</summary>
    public sealed class AlreadyExists(string nombre)
        : SustanciaException($"Conflicto de integridad: La sustancia con nombre '{nombre}' ya está registrada.");
}