namespace Solo_Leveling;

public class Cazador<T> : Persona<T> where T : IEstrategiaCombate {
    public Cazador(string nombre, T estilo) : base(nombre, estilo) { }
    
    public void CambiarEstilo(T nuevoEstilo) {
        Estilo = nuevoEstilo;
        Console.WriteLine($"{Nombre} ha cambiado su estilo de combate.");
    }
}