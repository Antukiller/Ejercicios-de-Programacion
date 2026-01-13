// See https://aka.ms/new-console-template for more information

using PlantillaFutbolInterfaces;
using PlantillaFutbolInterfaces.Models;

Console.WriteLine("Plantilla de Futbol");

// Puedo usar persona porque entrenador hereda de persona
Persona persona = new Entrenador() { NombreCompleto = "Entrenador1", Experiencia = 7, Dni = "Dni1"};

IEntrenadorPrincipal entrenadorPrincipal = new EntrenadorPrincipal() {NombreCompleto = "Entrenador2", Experiencia = 9,  Dni = "Dni2"};

Entrenador entrenadorPortero = new EntrenadorPortero() { NombreCompleto = "Entrenador3", Experiencia = 7, AñosEspecialidad = 2, Dni = "Dni3"};

Jugador portero1 = new Portero() { NombreCompleto = "Portero1", dorsal = 1, Dni = "Dni4"};

Jugador jugador1 = new Jugador() { NombreCompleto = "Jugador1", dorsal = 90,  Dni = "Dni5"};

IDelantero jugador2 = new Delantero() {  NombreCompleto = "Jugador2", dorsal = 69,  Dni = "Dni6"};

Jugador jugador3 = new Portero() {  NombreCompleto = "Jugador3", dorsal = 32, Dni = "Dni7"};

Jugador jugador4 = new JugadorEntrenador() {  NombreCompleto = "Jugador4", dorsal = 45,  Dni = "Dni8"};






if (jugador3 is Portero a) {
    a.Blocar();
}

if (jugador2 is IDelantero b) {
    b.Chutar();
}

if (jugador1 is Jugador c) {
    c.Jugar();
}

// Antipatrón: Herencia Rígida.
// Forzar la combinación de comportamientos mediante nuevas clases hijas crea un árbol de herencia
// Inmanejable. Si mañana añadimos el rol "Masajista", necesitaríamos crear:
// JugadorMasajista, EntrenadorMasajista y JugadorEntrenadorMasajista. Insostenible.
if (jugador4 is JugadorEntrenador d) {
    d.Jugar();
    d.AjustarTactica();
}




