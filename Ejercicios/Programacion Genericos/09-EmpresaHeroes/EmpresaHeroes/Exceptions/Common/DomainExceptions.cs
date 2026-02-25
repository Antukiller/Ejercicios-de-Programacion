namespace EmpresaHeroes.Exceptions.Common;

public abstract class DomainException(string message) : Exception(message);