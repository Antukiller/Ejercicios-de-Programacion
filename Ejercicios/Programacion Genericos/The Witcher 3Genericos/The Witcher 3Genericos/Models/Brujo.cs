namespace The_Witcher_3Genericos.Models;


/// <summary>
public class Brujo<T> : Persona<T> where T : IRolEstrategiaBrujo
{
    public Brujo(string nombre, T estrategia) : base(nombre, estrategia) {}

    public void CambiarEstrategia(T nuevaEstrategia) 
    {
        Estrategia = nuevaEstrategia;
        Console.WriteLine($"{Nombre} ha cambiado a una nueva táctica.");
    }
    
    public override string ToString() {
        // El -10 alinea el nombre a la izquierda en un espacio de 10 caracteres
        return $"│ PERSONAJE: {Nombre,-8} │ ESTRATEGIA: {Estrategia,-20} │";
    }

}
    