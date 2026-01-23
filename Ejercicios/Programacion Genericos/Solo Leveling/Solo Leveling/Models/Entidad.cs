namespace Solo_Leveling;

public abstract class Entidad(string nombre, string rango) {
    public string Nombre { get; set; } = nombre;
    public string Rango { get; set; } = rango;
}