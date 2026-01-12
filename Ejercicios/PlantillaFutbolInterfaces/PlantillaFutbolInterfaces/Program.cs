// See https://aka.ms/new-console-template for more information

using PlantillaFutbolInterfaces;
using PlantillaFutbolInterfaces.Models;

Console.WriteLine("Plantilla de Futbol");

// Puedo usar persona porque entrenador hereda de persona
Persona persona = new Entrenador() { NombreCompleto = "Entrenador1", Experiencia = 7 };

IEntrenadorPrincipal entrenadorPrincipal = new Entrenador() {NombreCompleto = "Entrenador2", Experiencia = 9};

Entrenador entrenadorPortero = new EntrenadorPortero() { NombreCompleto = "Entrenador3", Experiencia = 7, AñosEspecialidad = 2};

Jugador portero = new Portero() { NombreCompleto = "Portero1", dorsal = 1};

Jugador jugador1 = new Jugador() { NombreCompleto = "Jugador1", dorsal = 90};


