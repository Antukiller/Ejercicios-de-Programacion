namespace The_Witcher_3.Model;


/// <summary>
/// Representa una persona del videojuego
/// </summary>
/// <param name="nombre"></param>
/// <param name="estrategia"></param>
public abstract class Persona(string Nombre, IRolEstrategiaBrujo estrategia) {
    public string Nombre { get; set; } = Nombre;
    public int Edad { get; set; }

    public IRolEstrategiaBrujo Estrategia { get; set; } = estrategia;

    

}