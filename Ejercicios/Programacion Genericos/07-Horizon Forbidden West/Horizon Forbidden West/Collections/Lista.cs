using System.Collections;

namespace Horizon_Forbidden_West.Collections;

public class Lista<T> : ILista<T> {
    private Nodo<T>? _cabeza;
    public IEnumerator<T> GetEnumerator() {
        var actual = _cabeza;
        while (actual != _cabeza) {
            yield return actual.Value;
            actual = actual.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public int Size { get; private set; }
    
    public void AddFirst(T item) {
        var nuevoNodo = new Nodo<T>(item);
        if (_cabeza == null) {
            _cabeza = nuevoNodo;
        }  else {
            _cabeza.Next = _cabeza;
            _cabeza = nuevoNodo;
        }
        Size++;
    }

    public void AddLast(T item) {
        var nuevoNodo = new Nodo<T>(item);
        if (_cabeza == null) {
            _cabeza = nuevoNodo;
        }
        else {
            var actual = _cabeza;
            while (actual.Next != null) {
                actual = actual.Next;
                actual.Next = nuevoNodo;
            }
        }
        Size++;
    }

    public void AddAt(int index, T item) {
        if (index < 0 || index > Size)
            throw new ArgumentOutOfRangeException(nameof(index), "Índice fuera de rango");

        if (index == 0) {
            AddFirst(item);
        }
        else {
            var nuevoNodo = new Nodo<T>(item);
            var actual = _cabeza;
            for (var i = 0; i < index - 1; i++)
                actual = actual?.Next;

            nuevoNodo.Next = actual?.Next;
            actual!.Next = nuevoNodo;
            Size++;
        }
    }

    public void RemoveFirst() {
        if (_cabeza == null) 
            throw new InvalidOperationException("La lista está vacía");
            _cabeza = _cabeza.Next;
            Size--;
    }

    public void RemoveLast() {
        if (_cabeza == null)
            throw new InvalidOperationException("la lista está vacía");

        if (_cabeza == null) {
            _cabeza = null;
        }
        else {
            var actual = _cabeza;
            for (var i = 0; i < Size - 2; i++)
                actual = actual?.Next;
            actual!.Next = null;
        }

        Size--;
    }

    public void RemoveAt(int index) {
        if (index < 0 || index > Size)
            throw new ArgumentOutOfRangeException(nameof(index), "Indice fuera de rango");

        if (index == 0) {
            RemoveFirst();
        }
        else {
            var actual = _cabeza;
            for (var i = 0; i < index - 1; i++)
                actual = actual?.Next;
            actual!.Next = actual.Next?.Next;
            Size--;
        }
    }

    public T GetFirst() {
        if (_cabeza == null)
            throw new InvalidOperationException("La lista está vacía");
        return _cabeza.Value;
    }

    public T GetLast() {
        if (_cabeza == null)
            throw new InvalidOperationException("La lista está vacía");
        var actual = _cabeza;
        for (var i = 0; i < Size - 1; i++)
            actual = actual?.Next;
        return actual!.Value;
    }

    public T GetAt(int index) {
        if (index < 0 || index >= Size)
            throw new ArgumentOutOfRangeException(nameof(index), "Indice fuera de rango");
        var actual = _cabeza;
        for (var i = 0; i < Size - 1; i++)
            actual = actual?.Next;
        return actual!.Value;
    }

    public bool Contains(T item) {
        var actual = _cabeza;
        while (actual != null) {
            if (actual.Value!.Equals(item))
                return true;
            actual = actual.Next;
        }
        return false;
    }

    public bool IsEmpty() {
        return Size == 0;
    }

    public void Clear() {
        _cabeza =  null;
        Size = 0;
    }

    public void Display() {
        var actual = _cabeza;
        while (actual != null) {
            Console.Write(actual.Value);
            if (actual.Next != null) {
                Console.Write(" -> ");
            }
            actual = actual.Next;
        }
        Console.WriteLine();
    }

    public int IndexOf(T item) {
        var actual = _cabeza;
        var indice = 0;
        while (actual != null) {
            if (actual.Value!.Equals(item))
                return indice;
            actual = actual.Next;
            indice++;
        }

        return -1;
    }
}