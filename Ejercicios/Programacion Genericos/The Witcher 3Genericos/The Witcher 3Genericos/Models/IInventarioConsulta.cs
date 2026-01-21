namespace The_Witcher_3Genericos.Models;

public interface IInventarioConsulta<out T> {
    T ObtenerItem(int index);
}