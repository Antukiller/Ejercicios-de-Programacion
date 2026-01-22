namespace The_Witcher_3Genericos.Models;


/// <summary>
/// Clase genérica que representa un contenedor de suministros.
/// Gestiona una colección dinámica de objetos de tipo <typeparamref name="T"/> 
/// utilizando la infraestructura de memoria de <see cref="List{T}"/>.
/// </summary>
/// <remarks>
/// Funcionamiento interno del método Add:
/// 1. Verificación de Capacidad: Comprueba si el array interno tiene espacio; si no, lo redimensiona.
/// 2. Asignación por Índice: Coloca la referencia del objeto en la última posición disponible.
/// 3. Actualización de Estado: Incrementa el contador interno de la propiedad 'Count'.
/// </remarks>
/// <typeparam name="T">El tipo de objeto almacenado, limitado por la varianza definida en las interfaces.</typeparam>
public class CofreAlquimico<T> : IInventarioConsulta<T> {
    // Campo privado: Mantiene la lista oculta para proteger la integridad de los datos (Encapsulamiento).
    private List<T> _items = new List<T>();
    
    /// <summary>
    /// Agrega un elemento a la colección. 
    /// El símbolo '=>' es Sintaxis Sugar (Expression-bodied member) para una sola instrucción.
    /// </summary>
    /// <param name="item">Instancia de tipo T que se añadirá a la lista.</param>
    // El método .Add() gestiona el crecimiento dinámico de la memoria por nosotros.
    public void AgregarItem(T item) => _items.Add(item);
    
    // Retorna el elemento usando el indexador de la lista.
    public T ObtenerItem(int index) => _items[index];
}