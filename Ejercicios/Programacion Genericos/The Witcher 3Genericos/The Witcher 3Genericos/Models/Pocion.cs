namespace The_Witcher_3Genericos.Models;

public class Pocion(string nombre, double peso) : Suministro(nombre, peso) {
    public int DuracionEfecto { get; set; }
}