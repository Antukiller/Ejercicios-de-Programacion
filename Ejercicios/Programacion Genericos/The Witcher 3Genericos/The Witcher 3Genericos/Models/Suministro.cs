namespace The_Witcher_3Genericos.Models;

public class Suministro(string nombre, double peso) {
    public string Nombre { get; set; } = nombre;
    public double Peso { get; set; } = peso;
}