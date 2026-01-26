using GestionBiblioteca.Models;
using Serilog;

namespace GestionBiblioteca.Factories;

public static class LibroFactory {
    private static readonly ILogger _log = Log.ForContext(typeof(LibroFactory));

    /// <summary>
    ///     Genera un conjunto de datos de prueba para Alumnos.
    /// </summary>
    /// <returns>Un vector de Alumnos con datos de prueba.</returns>
    
    public static Libro[] DemoData() {
        _log.Information("Inicializando datos de prueba para Libros...");
        var lista = new Libro[3];
    
        // El Quijote - ISBN Correcto
        var a1 = new Libro
            { Titulo = "El Quijote", Autor = "Miguel de Cervantes", Isbn = "978-84-241-1546-4", Estante = "A-1" };
    
        // Cien años de soledad - ISBN Corregido (termina en 0)
        var a2 = new Libro
            { Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Isbn = "978-03-073-5043-0", Estante = "A-12"};
    
        // El resplandor - ISBN Correcto
        var a3 = new Libro 
            { Titulo = "El resplandor", Autor = "Stephen King", Isbn = "978-84-975-9381-6", Estante = "A-5" };

        lista[0] = a1; 
        lista[1] = a2; 
        lista[2] = a3; 

        return lista;
    }
}