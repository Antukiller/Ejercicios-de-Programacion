using System.Globalization;

namespace GestionBiblioteca.Config;

public static class Configuracion {
    // Esto sigue siendo útil para mostrar fechas y precios de multas correctamente
    public static readonly CultureInfo Locale = CultureInfo.GetCultureInfo("es-ES");

    // Propiedades útiles para tu CRUD de Biblioteca
    public static readonly int MaxLibrosPorUsuario = 5;
    public static readonly int DiasPrestamoDvd = 3; // Los DVDs suelen prestarse menos tiempo
    public static readonly int DiasPrestamoLibro = 15;
}