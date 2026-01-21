namespace The_Witcher_3Genericos.Models;


/// <summary>
/// Representa un bruje en el videjuego. Hereda de persona
/// </summary>
/// <param name="nombre"></param>
/// <param name="estrategia"></param>
public class Brujo<T>(string Nombre, T estrategia) : Persona<T>(Nombre, ) {
    
    /// <summary>
    /// Permite cambiar de estrategia al brujo
    /// </summary>
    /// <param name="nuevaEstrategia"></param>
    public void cambiarEstrategia(T nuevaEstrategia) {
        Console.WriteLine($"\n>>> CAMBIO ESTRATÉGICO: {Nombre} guarda su equipo actual y equipa {nuevaEstrategia}");
        Estrategia = nuevaEstrategia;
    }
    
    public override string ToString() {
        // El -10 alinea el nombre a la izquierda en un espacio de 10 caracteres
        return $"│ PERSONAJE: {Nombre,-8} │ ESTRATEGIA: {Estrategia,-20} │";
    }
}