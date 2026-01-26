using Solo_Leveling.common;

namespace Solo_Leveling;

public class EjercitoSombras<T> : IAlmacenSombras<T> {
    private ILista<T> _items = new Lista<T>();
    public void AgregarSombra(T item) => _items.AgregarFinal(item);
    public T ObtenerSombra(int index) => _items.Obtener(index);

    //public void AgregarSombra(T item) => _items.Add(item);
    //public T ObtenerSombra(int index) => _items[index]
}