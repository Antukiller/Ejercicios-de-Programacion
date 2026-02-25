using EmpresaHeroes.Exceptions.Common;

namespace EmpresaHeroes.Exceptions;


public abstract class HeroeException(string message) : Exception(message) {
    
    /// <summary>Se lanza cuando no existe el héroe solicitado.</summary>
    public sealed class NotFound(string id)
        : HeroeException($"No se ha encontrado el héroe con el identificador: {id}");

    /// <summary>Se lanza cuando fallan las reglas de validación (Arquero, Mago, Guerrero).</summary>
    public sealed class Validation(IEnumerable<string> errors)
        : HeroeException("Se han detectado errores de validación en el héroe.") {
        public IEnumerable<string> Errores { get; init; } = errors;
    }

    /// <summary>Se lanza si intentas crear un héroe con un nombre que ya existe (si tu lógica lo requiere).</summary>
    public sealed class AlreadyExists(string nombre)
        : HeroeException($"Conflicto: El héroe con nombre '{nombre}' ya está registrado.");
}