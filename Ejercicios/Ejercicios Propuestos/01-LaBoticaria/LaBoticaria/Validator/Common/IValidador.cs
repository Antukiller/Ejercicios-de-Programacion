namespace LaBoticaria.Validator.Common;

public interface IValidador<in T> {
    IEnumerable<string> Validar(T entidad);
}