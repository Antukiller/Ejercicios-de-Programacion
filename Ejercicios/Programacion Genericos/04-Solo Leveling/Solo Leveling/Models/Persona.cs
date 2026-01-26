namespace Solo_Leveling;

public abstract class Persona<T> where T : IEstrategiaCombate {
    public string Nombre { get; set; }
    public T Estilo { get; set; }
    protected Persona(string nombre, T estilo) {
        Nombre = nombre;
        Estilo = estilo;
    }
}