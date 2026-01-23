namespace Solo_Leveling;

public class Sombra(string nombre, string rango, int energia) : Entidad(nombre, rango) {
    public int EnergiaSombras { get; set; } = energia;
}