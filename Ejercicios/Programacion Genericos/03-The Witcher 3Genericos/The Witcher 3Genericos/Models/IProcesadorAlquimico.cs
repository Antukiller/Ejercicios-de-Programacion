namespace The_Witcher_3Genericos.Models;

public interface IProcesadorAlquimico<in T> {
    void analizar(T ingrediente);
}