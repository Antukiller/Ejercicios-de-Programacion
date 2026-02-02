using Horizon_Forbidden_West.Collections;

namespace Horizon_Forbidden_West.Exception;

public abstract class EntidadHorizonException(string message) : DomainException(message) {
    public sealed class NotFound(string id)
        : EntidadHorizonException("No se ha encontrado ningun entidad con el identificador: {id}");

    public sealed class Validation(ILista<string> errors)
        : EntidadHorizonException("Se han detectado errores de validacion en la entidad") {
        
        public ILista<string> Errors { get; init; } = errors;
    }
    
    public sealed class AlreadyExist(string codigoGaia) 
        : EntidadHorizonException($"Conflicto de integridad: El codigo gaia {codigoGaia} ya esta resgistrado en el sistema.");
    
}