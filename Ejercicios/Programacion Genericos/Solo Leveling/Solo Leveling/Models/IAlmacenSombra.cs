namespace Solo_Leveling;

public interface IAlmacenSombras<out T> {
    T ObtenerSombra(int index);
}