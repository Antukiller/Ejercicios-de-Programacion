using System.Numerics;

namespace Horizon_Forbidden_West.Collections;

public static class ListaExtensions {
    public static ILista<T> Filter<T>(this ILista<T> lista, Predicate<T> predicate) {
        var resultado = new Lista<T>();
        foreach (var elemento in lista )
            if (predicate(elemento))
                resultado.AddLast(elemento);
        return resultado;
    }

    extension<T>(ILista<T> lista) where T : class {
        public ILista<T> Where(Predicate<T> predicate) {
            var resultado = new Lista<T>();
            foreach (var elemento in lista )
                if (predicate(elemento))
                    resultado.AddLast(elemento);
            
            return resultado;
        }

        public T? Find(Predicate<T> predicate) {
            foreach (var elemento in lista)
                if (predicate(elemento))
                    return elemento;
            return null;
        }

        public int Count(Predicate<T> predicate) {
            /*var contador = 0;
            foreach (var elemento in lista)
                if (predicate(elemento))
                    contador++;*/
            return lista.Where(predicate).Size;
        }

        public ILista<TK> Select<TK>(Func<T, TK> selector) {
            var resultado = new Lista<TK>();
            foreach (var elemento in lista)
                resultado.AddLast(selector(elemento));
            return resultado;
        }

        public TResult Sum<TResult>(Func<T, TResult> selector) where TResult : INumber<TResult> {
            var suma = TResult.Zero;
            foreach (var elemento in lista)
            suma += selector(elemento);
            return suma;
            
        }

        public TAccumulate Aggregate<TAccumulate>(Func<TAccumulate, T, TAccumulate> acumulador,
            TAccumulate valorInicial) where TAccumulate : INumber<TAccumulate> {
            var resultado = valorInicial;
            foreach (var elemento in lista)
                resultado = acumulador(resultado, elemento);
            return resultado;
        }

        public void ForEach(Action<T> action) {
            foreach (var elemento in lista)
                action(elemento);
        }

        public bool All(Predicate<T> predicate) {
            foreach (var elemento in  lista )
                if (!predicate(elemento))
                    return false;
            return true;
        }

        public int IndexOf(Predicate<T> predicate) {
            var indice = 0;
            foreach (var elemento in lista) {
                if (predicate(elemento))
                    return indice;
                indice++;
            }

            return -1;
        }

        public ILista<T> Clone() {
            var resultado = new Lista<T>();
            foreach (var elemento in lista )
                resultado.AddLast(elemento);
            return resultado;
        }
        
        private void Swap(int i, int j) {
            if (i < 0  || i >= lista.Size || j < 0 || j >= lista.Size)
                throw new IndexOutOfRangeException("Los indices proporcionados están fuera de los límites de la lista");
            if (i == j) return;

            var itemI = lista.GetAt(i);
            var itemJ = lista.GetAt(j);
            
            lista.RemoveAt(i);
            lista.AddAt(i, itemJ);
            lista.RemoveAt(j);
            lista.AddAt(i, itemI);

        }

        public ILista<T> OrderBy<TK>(Func<T, TK> keySelector) where TK : IComparable<TK> {
            var copia = lista.Clone();
            var n = copia.Size;

            for (var i = 0; i < n - 1; i++) {
                for (var j = 0; j < n - i - 1; j++) {
                    var actual = keySelector(copia.GetAt(j));
                    var siguiente = keySelector(copia.GetAt(j + 1));
                    
                    if (actual.CompareTo(siguiente) > 0)
                        copia.Swap(j, j + 1);
                    
                }
            }
            return copia;
        }

        public ILista<T> Sort(Comparison<T> comparison) {
            var copia = lista.Clone();
            var n = copia.Size;

            bool cambiado;
            do {
                cambiado = false;
                for (var i = 0; i < n - 1; i++) {
                    var itemActual = copia.GetAt(i);
                    var itemSiguiente = copia.GetAt(i + 1);

                    if (comparison(itemActual, itemSiguiente) > 0) {
                        copia.Swap(i, i + 1);
                        cambiado = true;
                    }
                }

                n--;
            }  while (cambiado);
            
            return copia;

        }

        public ILista<T> Take(int cantidad) {
            var resultado = new Lista<T>();
            var total = lista.Size;
            
            var limite = cantidad > total ?  total : cantidad;
            
            for (var i = 0; i < limite; i++) 
                resultado.AddLast(lista.GetAt(i));
            
            return resultado;
        }
    }
}