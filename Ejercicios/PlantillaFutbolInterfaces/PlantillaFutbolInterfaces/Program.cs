// See https://aka.ms/new-console-template for more information


using PlantillaFutbolInterfaces;
using PlantillaFutbolInterfaces.Models;

var rolEntrenador = new RolEntrenadorPrincipal();
var e1 = new Entrenador("Pep Guardioa", rolEntrenador);
Console.WriteLine(e1);
((EntrenadorPrincipal)e1).AjustarTactica();




var rolPortero = new RolPortero();
var j1 = new Jugador("Iker Casillas", rolPortero);
Console.WriteLine(j1);
((Portero)j1).Blocar();


e1.Rol = rolPortero;
j1.Rol = rolEntrenador;





var portero =  new Portero("Victor Valdes", 1);
Console.WriteLine(portero);
portero.Role.Blocar();
portero.Role.Entrenar();


var delantero = new RolDelantero(9);
var jugador = new Portero("Fernando Alonso", 33);
Console.WriteLine($"Antes dek cambio: {jugador}");
jugador.CambiarRol(delantero);
jugador.CambiarRol($"Despues del cambio: {jugador}");