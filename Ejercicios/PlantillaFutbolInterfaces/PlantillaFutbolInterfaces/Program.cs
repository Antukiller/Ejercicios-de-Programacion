// See https://aka.ms/new-console-template for more information


using PlantillaFutbolInterfaces;
using PlantillaFutbolInterfaces.Models;

var rolEntrenador = new RolEntrenadorPrincipal();
var p1 = new Entrenador("Pep Guardioa", rolEntrenador);
Console.WriteLine(p1);




var rolPortero = new RolPortero();
var p2 = new Jugador("Iker Casillas", rolPortero);
Console.WriteLine(p2);