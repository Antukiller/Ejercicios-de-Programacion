using TheWictherContracts.Exceptions.Common;

namespace TheWictherContracts.Exceptions;

public abstract class ContratoException(string message) : DomainException(message) {
    public sealed class NotFound(string id)
        : ContratoException($"No se ha encontrado ningun contrato con el identifiacdor: {id}");
}

public sealed class Validation(IEnumerable<string> errors)
    : ContratoException("Se han detectado errores de validacion en la entidad") {
    public IEnumerable<string> Errores { get; init; } = errors;
}

public sealed class AlreadyExists(string id)
    : ContratoException($"Conflicto de integridad: El Id {id} ya esta registrado en el sitema");

