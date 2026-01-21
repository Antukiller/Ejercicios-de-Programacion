namespace ListasEnlazadas.Caja;

public class CajaObject(object valor) {
    private object _valor = valor;
    public object GetValor() => _valor;
    public void SetValor(object nuevoValor) {
        _valor = nuevoValor;
    }
}