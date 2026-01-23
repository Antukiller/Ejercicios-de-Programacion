namespace ListasEnlazadas;

public class Lista<T> : ILista<T> {

    private Nodo<T>? _cabeza;
    private int _contador;

    public Lista() {
        Console.WriteLine($"Lista del tipo {typeof(T).Name}");
    }
    
    
    public void AgregarInicio(T valor) {
        // Creamos un nuevo nodo
        var nuevoNodo = new Nodo<T>(valor);
        
        // Si la lista esta vacía, el nuevo nodo sera la cabeza
        if (_cabeza == null) {
            _cabeza = nuevoNodo;
        }
        // si no está vacía, el nuevo nodo apunta a la cabeza y luego se actualiza la cabeza
        else {
            nuevoNodo.Siguiente = _cabeza;
            _cabeza = nuevoNodo;
        }
        
        // Incrementamos el contaoor
        _contador++;
    }

    public void AgregarFinal(T valor) {
        // Crear un nuevo nodo
        var nuevoNodo = new Nodo<T>(valor);
        
        // Si la lista esta vacia, el nuevo noso sera la cabeza
        if (_cabeza == null) {
            _cabeza = nuevoNodo;
        }
        else {
            // Si no esta vacia, recorremos hata el final de las lista 
            var actual = _cabeza;
            while (actual.Siguiente != null) 
                actual = actual.Siguiente;
            // el ultimo nodo apunta al nuevop nodo
            nuevoNodo.Siguiente = nuevoNodo;
        }
        
        // Incrementamos el contador
        _contador++;
    }

    public void AgregarEn(T valor, int indice) {
        // Creamos un nuevo nodo
        var nuevoNodo = new Nodo<T>(valor);
        // Validamos indices
        if (indice <  0 || indice > _contador)
            throw new ArgumentOutOfRangeException(nameof(indice), "indice fuera de rango"); 
        // Si el indice es 0, agreagamos al inicio
        if (indice == 0) {
            AgregarInicio(valor);
        }
        else {
            // Si el indice es mayor que 0, recorremos hasta el ultimo indice
            var actual = _cabeza;
            for (var i = 0 ; i < indice - 1; i++) {
                actual = actual?.Siguiente;
                // Creamos un nuevo nodo y lo conectamos con el actua y el siguiente
                nuevoNodo.Siguiente = actual?.Siguiente;
                actual?.Siguiente = nuevoNodo;
                // Incrementamos contador
                _contador++;
            }
        }
    }

    public void EliminarInicio() {
        // Verificamos si la lista esta vacia
        if (_cabeza == null) 
            throw new InvalidOperationException("La lista esta vacia");
            // Actualizamos la cabeza para que apunte al siguiente nodo
            _cabeza = _cabeza.Siguiente;
            // Decrecemos el contador 
            _contador--; 
        
    }

    public void EliminarFinal() {
        // Verificamos si la lista esta vacia
        if (_cabeza == null)
            throw new InvalidOperationException("La lista esta vacia");
        // Si solo hay un nodo, eliminamos la cabeza
        if (_cabeza.Siguiente == null) {
            _cabeza = null;
        }
        else {
            // Recorremos hasta el penultimo nodo
            var actual = _cabeza;
            
            // Con un bucle while 
            // while (actual.Siguiente?.Siguiente != null)
            // actual = actual?.Siguiente
            
            // con un bucle for
            for (var i = 0; i < _contador - 2; i++) {
                actual = actual?.Siguiente;
                
                // Ahora actual apunta al penultimo nodo 
                // y el penultimo nodo a null
                actual = actual?.Siguiente =  null;
            }
            
            // Decrementamos el contador
            _contador--;
            
        }
    }

    public void EliminarEn(int indice) {
        // Valida el indice 
        if (indice < 0 || indice >= _contador)
            throw new ArgumentOutOfRangeException(nameof(indice), "indice fuera de rango");
        // Si el indice es 0, eliminamos el inicio
        if (indice == 0)  {
            EliminarInicio();
        }
        else {
            // Si el indice es mayor que 0, recorremos hasta el indice deseado
            var actual = _cabeza;

            // Con un bucle while
            // while (actual.Siguiente?.Siguiente!= null && i < indice - 1)
            // actual = actual.Siguiente;
            
            // Con un bucle for+
            for (var i = 0; i < indice - 1; i++)
                actual = actual?.Siguiente;
            
            // Ahora actual apunta al nodo antes del que queremos eliminar
            // Saltamos el nodo a eliminar
            actual?.Siguiente = actual.Siguiente?.Siguiente;
            // Decrementamos el contador 
            _contador--;

        }
    }

    public T ObtenerPrimero() {
        // Verificamos si la cabeza esta vacia
        if (_cabeza == null)
            throw new InvalidOperationException("La lista está vacía");
        
        // Ahora actual apunta al primer nodo y lo devolvemos
        return _cabeza.Valor;
    }
    

    public T ObtenerUltimo() {
        // Verificamps si la lista está vacía
        if (_cabeza == null)
            throw new InvalidOperationException("La lista está vacía");
        var actual = _cabeza;
        // con un bucle while 
        // while (actual.Siguiente != null)
        //      actual = actual.Siguiente;

        for (var i = 0; i < _contador - 1; i++)
            actual = actual?.Siguiente;
        
        // Ahora actual apunta al ultimo nodo y lo devolvemos
        return actual!.Valor;
    }

    public T Obtener(int indice) {
        // Validar el indice
        if (indice < 0 || indice >= _contador)
            throw new ArgumentOutOfRangeException(nameof(indice), "Indice fuera de rango");
        var actual = _cabeza;
        
        // Con un bucle while
        // while (actual != null && i < indice)
        //    actual = actual.Siguiente;
        
        // Con un bucle for
        for (var i = 0; i < indice; i++)
            actual = actual?.Siguiente;
        
        // Ahora actual apunta al nodo el indice deseado y lo devolvemos
        return actual!.Valor;
    }

    public bool Existe(T valor) {
        var actual = _cabeza;
        // Recorremos la lista buscando el valor 
        while (actual != null ) {
            if (actual.Valor!.Equals(valor))
                return true;
            actual = actual.Siguiente;
        }

        return false;
    }

    public int Contar() {
        return _contador;
    }

    public bool EstaVacia(int indice) {
        return _contador == 0;
    }

    public void Limpiar() {
        _contador = 0;
        _cabeza = null;
    }

    public void Mostrar() {
        var actual = _cabeza;
        // Recorremos la lista mostrando los valores
        while (actual != null) {
            Console.Write(actual.Valor);
            if (actual.Siguiente != null)
                Console.Write(" -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
    
    // Esto lo veremos más adelante, pero es necesario para usar foreach
    public IEnumerable<T> GetEnumerator() {
        // Recorremos la lista devolviendo los valores
        var actual = _cabeza;
        while (actual != null) {
            // Yield devuelve un valor y pausa la ejecución, para que el ciclo foreach pueda continuar
            yield return actual.Valor;
            // Avanzamos al siguiente nodo
            actual = actual.Siguiente;
        }
    }
}