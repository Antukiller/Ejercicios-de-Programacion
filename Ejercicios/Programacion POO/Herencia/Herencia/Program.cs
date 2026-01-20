// See https://aka.ms/new-console-template for more information

using HerenciaVsComposicion.Herencia;

Console.WriteLine("Herenciaa");
Console.WriteLine();
Console.WriteLine("Entrenadores");

var e1 = new Entrenador() {Nombre = "John Doe", Experiencia = 7};
e1.Entrenar();
if (e1 is Persona)
    Console.WriteLine($"{e1.Nombre} es una persona");
if (e1 is Entrenador)
    Console.WriteLine($"{e1.Nombre} es un entrenador");


Console.WriteLine();
var e2 = new EntrenadorPrincipal() {Nombre = "John Smith", Experiencia = 10};
e2.Entrenar();
if (e2 is object)
    Console.WriteLine($"{e2.Nombre} es un objeto");
if (e2 is Persona)
    Console.WriteLine($"{e2.Nombre} es una persona");
if (e2 is Entrenador)
    Console.WriteLine($"{e2.Nombre} es un entrenador");
if (e2 is EntrenadorPrincipal)
    Console.WriteLine($"{e2.Nombre} es entrenador del primer equipo");

/*Console.WriteLine();
var e3 = new Persona() { Nombre = "Persona1", };
e3.
Si soy un objeto persona no puedo acceder a los comportiemientos de los entrenadores
*/

Console.WriteLine();
Console.WriteLine("Jugadores");
var j1 = new Delantero() { Nombre = "Satoru", Dorsal = 7 };
j1.Jugar();
if (j1 is object)
    Console.WriteLine($"{j1.Nombre} es un objeto");
if (j1 is Persona)
    Console.WriteLine($"{j1.Nombre} es un persona");
if (j1 is JugadorCampo)
    Console.WriteLine($"{j1.Nombre} es un jugador de campo");
if (j1 is Delantero) 
    Console.WriteLine($"{j1.Nombre} es un delantero");

    




