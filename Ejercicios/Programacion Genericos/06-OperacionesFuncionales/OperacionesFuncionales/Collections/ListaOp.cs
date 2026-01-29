namespace OperacionesFuncionales.Collections;

public class ListaOp {
    public static ILista<T> Filte<T>(ILista<T> lista, Predicate<T> predicado) {
        var resultado = new Lista<T>();
        foreach (var elemento in lista) {
            if (predicado(elemento)) {
                resultado.AgregarFinal(elemento);
            }
        }

        return resultado;
    }
}