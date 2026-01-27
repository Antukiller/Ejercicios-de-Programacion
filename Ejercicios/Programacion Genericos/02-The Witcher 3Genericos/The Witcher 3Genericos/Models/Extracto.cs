namespace The_Witcher_3Genericos.Models;

public class Extracto(string nombre, double peso) : Pocion(nombre, peso) {
    public int NivelToxicidad { get; set; }
}