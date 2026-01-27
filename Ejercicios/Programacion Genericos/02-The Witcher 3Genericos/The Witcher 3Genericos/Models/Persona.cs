namespace The_Witcher_3Genericos.Models;


/// <summary>
/// Representa una persona del videojuego con una especialidad genérica
/// </summary>
/// <typeparam name="T">El tipo específico de estrategia que implementa IRolEstrategiaBrujo</typeparam>
public abstract class Persona<T> where T : IRolEstrategiaBrujo 
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    // ¡Aquí está la magia! Ya no es la interfaz básica, es el tipo exacto T.
    public T Estrategia { get; set; } 

    protected Persona(string nombre, T estrategia) 
    {
        Nombre = nombre;
        Estrategia = estrategia;
    }
}