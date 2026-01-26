using GestionBiblioteca.Enums;
using GestionBiblioteca.Models;
using Serilog;

namespace GestionBiblioteca.Factories;

public static class DvdFactory {
    private static readonly ILogger _log = Log.ForContext(typeof(DvdFactory));

    /// <summary>
    ///     Genera un conjunto de datos de prueba para Alumnos.
    /// </summary>
    /// <returns>Un vector de Alumnos con datos de prueba.</returns>
    public static Dvd[] DemoData() {
        _log.Information("Inicializando datos de prueba para Alumnos...");
        var lista = new Dvd[3];

        var b1 = new Dvd 
        { Titulo = "Inception", Director = "Christopher Nolan", Duracion = 148, Genero = GeneroDvd.CienciaFiccion, Estante = "D-1" };
        var b2 = new Dvd
        { Titulo = "El Padrino", Director = "Francis Ford Coppola", Duracion = 175, Genero = GeneroDvd.Drama, Estante = "D-15" };
        var b3 = new Dvd
        { Titulo = "Superbad", Director = "Greg Mottola", Duracion = 113, Genero = GeneroDvd.Comedia, Estante = "D-40" };

        // Asignación a las primeras posiciones del vector
        lista[0] = b1; // ID 1
        lista[1] = b2; // ID 2
        lista[2] = b3; // ID 3

        return lista;
    }
}