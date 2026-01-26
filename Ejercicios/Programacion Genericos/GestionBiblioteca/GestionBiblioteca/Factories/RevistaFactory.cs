using GestionBiblioteca.Enums;
using GestionBiblioteca.Models;
using Serilog;

namespace GestionBiblioteca.Factories;

public static class RevistaFactory {
    private static readonly ILogger _log = Log.ForContext(typeof(RevistaFactory));

    /// <summary>
    ///     Genera un conjunto de datos de prueba para Alumnos.
    /// </summary>
    /// <returns>Un vector de Alumnos con datos de prueba.</returns>
    public static Revista[] DemoData() {
        _log.Information("Inicializando datos de prueba para Alumnos...");
        var lista = new Revista[3];

        var c1 = new Revista
            { Titulo = "National Geographic", Edicion = 145, Estante = "B-5" };
        var c2 = new Revista
            { Titulo = "Muy Interesante", Edicion = 22, Estante = "B-10" };
        var c3 = new Revista { Titulo = "Pronto", Edicion = 500, Estante = "B-20" };

        // Asignación a las primeras posiciones del vector
        lista[0] = c1; // ID 1
        lista[1] = c2; // ID 2
        lista[2] = c3; // ID 3

        return lista;
    }
}