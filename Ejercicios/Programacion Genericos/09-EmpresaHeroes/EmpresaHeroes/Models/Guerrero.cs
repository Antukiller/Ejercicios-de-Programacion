namespace EmpresaHeroes.Models;

public record Guerrero(string nombre, double poderBase) : Heroe(nombre, poderBase) {
    
    public override double CalcularPoderTotal() => PoderBase * 1.5;
    
}