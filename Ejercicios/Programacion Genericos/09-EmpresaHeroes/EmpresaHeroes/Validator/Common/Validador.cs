namespace EmpresaHeroes.Validator.Common;

public interface IValidador<in T> {
    IEnumerable<string> Validate (T entidad);
}