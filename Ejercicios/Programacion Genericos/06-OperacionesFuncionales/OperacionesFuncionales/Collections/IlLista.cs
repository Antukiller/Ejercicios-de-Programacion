namespace OperacionesFuncionales.Collections;

public interface ILista<T> {
    void AgregarInicio(T valor);
    void AgregarFinal(T valor);
    void Agregar(T valor, int indice);
    void EliminarInicio();
    void EliminarFinal();
    void Eliminar(int indice);
    T ObtenerPrimero();
    T ObtenerUltimo();
    T Obtener(int indice);
    bool Existe(T valor);
    int Contar();
    bool EstaVacia();
    void Limpiar();
    void Mostrar();
    IEnumerator<T> GetEnumerator();
}