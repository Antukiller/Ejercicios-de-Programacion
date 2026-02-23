namespace EmpresaHeroes.Models;

public class Mago(string nombre, double poderBase) : Heroe(nombre, poderBase) {

    public override double CalcularPoderTotal() => Experiencia * 0.5;
}