namespace Solo_Leveling;

public interface IEvaluadorAsosciacion<in T> {
    void analizar(T cazador);
}