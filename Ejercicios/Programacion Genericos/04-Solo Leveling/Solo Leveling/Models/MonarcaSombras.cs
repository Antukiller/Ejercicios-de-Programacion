namespace Solo_Leveling;

public class MonarcaSombras<T> : Persona<T> where T : IEstrategiaCombate {
    public MonarcaSombras(string nombre, T estilo) : base(nombre, estilo) { }

    public void CambiarEstilo(T nuevoEstilo) {
        Estilo = nuevoEstilo;
        Console.WriteLine($"{Nombre} ha cambiado su estilo de combate.");
    }

    public void EjecutarHabilidadUnica() {
        string mensaje = Estilo switch {
            IEstiloMagico => $"[SISTEMA] {Nombre} usa '¡ARISE!'.",
            IEstiloGuerrero => $"[SISTEMA] {Nombre} usa 'Mano del Gobernante'.",
            _ => "[SISTEMA] Estilo no reconocido."
        };
        Console.WriteLine(mensaje);
    }
}