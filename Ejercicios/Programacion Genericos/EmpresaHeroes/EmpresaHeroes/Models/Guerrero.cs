namespace EmpresaHeroes.Models;

public class Guerrero(string nombre, double poderBase) : Heroe(nombre, poderBase) {
    
    public override double CalcularPoderTotal() => PoderBase * 1.5;
    
}