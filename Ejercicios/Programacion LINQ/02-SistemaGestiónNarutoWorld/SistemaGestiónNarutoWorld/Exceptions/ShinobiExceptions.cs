using SistemaGestiónNarutoWorld.Exceptions.Common;
using SistemaGestiónNarutoWorld.Models;

namespace SistemaGestiónNarutoWorld.Exceptions;

public abstract class ShinobiException(string message) : DomainException(message) {
    /// <summary>Se lanza cuando no existe el registro solicitado.</summary>
    public sealed class NotFound(string id)
        : ShinobiException($"No se ha encontrado ninguna persona con el identificador: {id}.");

    /// <summary>Se lanza cuando fallan las reglas de validación de negocio.</summary>
    public sealed class Validation(IEnumerable<string> errors)
        : ShinobiException("Se han detectado errores de validación en la entidad.") {
        public IEnumerable<string> Errores { get; init; } = errors;
    }

    /// <summary>Se lanza ante conflictos de duplicidad (DNI).</summary>
    public sealed class AlreadyExists(string dniNinja)
        : ShinobiException($"Conflicto de integridad: El DNI {dniNinja} ya está registrado en el sistema.");

}