namespace ListasEnlazadas.Caja;

public class CajaGenericaMultiple<T, TP>(T valor, TP otroValor) {
    private T _valor = valor;
    public T GetValor() => _valor;
    public void SetValor(T nuevoValor) {
        _valor = nuevoValor;
    }
    
    private TP _otroValor = otroValor;
    public TP GetOtroValor() => _otroValor;
    public void SetOtroValor(TP nuevoOtroValor) {
        _otroValor = nuevoOtroValor;
    }

}