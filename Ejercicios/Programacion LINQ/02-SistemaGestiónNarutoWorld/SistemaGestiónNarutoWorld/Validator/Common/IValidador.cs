namespace SistemaGestiónNarutoWorld.Validator.Common;

/// <summary>
/// Interfaz generica para la validacion
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IValidador<in T> {
/// <summary>
/// Evalua si la instancia propocionada cumple con los requisitos del sistema.
/// </summary>
/// <param name="entidad"></param>
/// <returns></returns>
    IEnumerable<string> Validar(T entidad);
}