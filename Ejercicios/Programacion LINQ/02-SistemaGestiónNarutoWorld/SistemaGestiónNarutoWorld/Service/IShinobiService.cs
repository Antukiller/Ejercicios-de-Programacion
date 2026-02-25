using SistemaGestiónNarutoWorld.Enums;
using SistemaGestiónNarutoWorld.Models;

namespace SistemaGestiónNarutoWorld.Service;


public interface IShinobiService
{
    // --- GESTIÓN BÁSICA Y CACHÉ LRU ---
    
    // Este método debe gestionar la caché de los últimos 5 consultados
    Shinobi? ObtenerPorDni(string dni);
    

    // --- CONSULTAS LINQ (REQUISITOS DEL EJERCICIO) ---

    // 1. Listado de todos los alumnos de una Aldea (Equivalente a DAW)
    IEnumerable<Shinobi> ObtenerPorAldea(AldeaNinja aldea);

    // 2. Alumnos con "nota" (Poder/Control) superior o igual a 8.5
    // Buscamos Jinchurikis con alto control o Elites con mucho potencial
    IEnumerable<Shinobi> ObtenerNinjasDeAltoNivel(double umbral);

    // 3. Nota media de los alumnos de una Aldea
    double ObtenerMediaControlJinchurikis(AldeaNinja aldea);

    // 4. Alumnos cuyo nombre empieza por una letra (ej: 'A')
    IEnumerable<Shinobi> BuscarPorNombre(string prefijo);

    // 5. Agrupación de alumnos por Aldea (Curso/Grupo)
    IEnumerable<IGrouping<AldeaNinja, Shinobi>> AgruparPorAldea();

    // 6. Alumno/s con la nota máxima (sin variables intermedias)
    Shinobi? ObtenerNinjaMasPoderoso();

    // 7. Listado ordenado por edad de manera descendente
    IEnumerable<Shinobi> ObtenerRankingPorEdad();

    // 8. Paginación: Obtener alumnos de la página X (tamaño Y)
    IEnumerable<Shinobi> ObtenerPagina(int numeroPagina, int tamañoPagina);

    // --- CONSULTAS DE AUDITORÍA (NUEVOS CAMPOS) ---
    
    IEnumerable<Shinobi> ObtenerAltasRecientes(); // Basado en CreateAt
    
    IEnumerable<Shinobi> ObtenerModificadosRecientemente(); // Basado en UpdateAt
}