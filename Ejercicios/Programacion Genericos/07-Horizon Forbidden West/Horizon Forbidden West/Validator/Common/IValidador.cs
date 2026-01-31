using Horizon_Forbidden_West.Collections;

namespace Horizon_Forbidden_West.Validator.Common;

public interface IValidador<in T> {
    ILista<string> Validar(T entidad);
}