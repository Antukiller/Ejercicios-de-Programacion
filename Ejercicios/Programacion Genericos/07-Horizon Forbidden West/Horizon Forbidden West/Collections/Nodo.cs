namespace Horizon_Forbidden_West.Collections;

public class Nodo<T>(T value) {
    public T Value { get; set; } = value;
    public Nodo<T>? Next { get; set; } = null;

    public override string ToString() {
        return $"Nodo({Value})";
    }
}