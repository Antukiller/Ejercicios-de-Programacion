namespace Solo_Leveling;

public class EjercitoSombras<T> : IAlmacenSombras<T> {
    private List<T> _items = new List<T>();
    public void AgregarSombra(T item) => _items.Add(item);
    public T ObtenerSombra(int index) => _items[index];
}