namespace EmpresaHeroes.Models;

public class Arquero(string nombre, double poderBase) : Heroe(nombre, poderBase) {
    
    public override double CalcularPoderTotal() => Nivel * 2;
}