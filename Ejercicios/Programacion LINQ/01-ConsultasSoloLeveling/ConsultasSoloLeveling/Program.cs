// See https://aka.ms/new-console-template for more information

using ConsultasSoloLeveling.Models;
using System.Linq;
using static System.Console;


var listHunters = new List<Hunter>
{
    // Rango S - Los más poderosos
    new (1, "Sung Jin-woo", "S", "Monarca", "Ahjin", 146, true),
    new (2, "Cha Hae-In", "S", "Espadachín", "Hunters", 85, true),
    new (3, "Thomas Andre", "S", "Tanque", "Scavenger", 95, true),
    new (4, "Christopher Reed", "S", "Mago", "Nacional", 92, false),
    new (5, "Go Gun-hee", "S", "Luchador", "Asociación", 90, false),
    new (6, "Choi Jong-In", "S", "Mago", "Hunters", 82, true),
    new (7, "Baek Yoon-ho", "S", "Luchador", "White Tiger", 88, true),
    new (8, "Lui Zhigang", "S", "Espadachín", "China", 98, true),
    new (9, "Hwang Dong-soo", "S", "Asesino", "Scavenger", 80, false),
    new (10, "Lennart Niermann", "S", "Mago", "Richter", 84, true),
    new (11, "Goto Ryuji", "S", "Asesino", "Draw Sword", 91, false),
    new (12, "Kanae Tawata", "S", "Espadachín", "Draw Sword", 78, false),

    // Rango A - Élite operativa
    new (13, "Woo Jin-chul", "A", "Luchador", "Asociación", 75, true),
    new (14, "Park Heui-jin", "A", "Mago", "White Tiger", 68, true),
    new (15, "Kim Chul", "A", "Tanque", "White Tiger", 70, false),
    new (16, "Lee Minsung", "A", "Espadachín", "Reaper", 62, true),
    new (17, "Jung Yoon-tae", "A", "Tanque", "Hunters", 65, true),

    // Rango B y C - Soporte y rango medio
    new (18, "Lee Joo-hee", "B", "Sanador", "Ninguno", 30, true),
    new (19, "Kang Taeshik", "B", "Asesino", "Asociación", 48, false),
    new (20, "Park Beom-shik", "B", "Luchador", "Ninguno", 35, false),
    new (21, "Song Chi-yul", "C", "Espadachín", "Ninguno", 45, true),
    new (22, "Cho Kyuhwan", "C", "Mago", "Ninguno", 40, false),

    // Rango D y E - Los que están empezando
    new (23, "Yoo Jin-ho", "D", "Tanque", "Ahjin", 25, true),
    new (24, "Han Song-yi", "E", "Asesino", "Ahjin", 15, true),
    new (25, "Kim Sang-shik", "D", "Espadachín", "Ninguno", 22, true)
};


WriteLine(";⚔️ Retos de LINQ: Solo Leveling Edition");

// ============================================================
// I. CONSULTAS BÁSICAS DE SELECCIÓN (WHERE)
// ============================================================

WriteLine("\n*** 1. Listado General: Muestra todos los cazadores registrados ***");
listHunters.ToList().ForEach(WriteLine);

WriteLine("\n*** 2. Filtro por Inicial: Cazadores cuyo nombre empiece por 'S' o 'K' ***");
var listNameHunters = listHunters
    .Where(a => a.Nombre.StartsWith("S") || a.Nombre.StartsWith("K"))
    .ToList();

listNameHunters.ForEach(WriteLine);

WriteLine("\n*** 3. Censo: Número total de cazadores en el sistema ***");
var numbersHunters = listHunters.Count();

WriteLine(numbersHunters);

WriteLine("\n*** 4. Élite Activa: Rango S, Nivel > 90 y Gremio 'Hunters' ***");
var listHuntersRangeS = listHunters
    .Where(a => a.Nivel > 20 && a.Gremio == "Hunters")
    .ToList();

listHuntersRangeS.ForEach(WriteLine);

// ============================================================
// II. ELEMENTOS ÚNICOS (TAKE, FIRST, SINGLE)
// ============================================================

WriteLine("\n*** 5. Primer Escuadrón: Los 2 primeros cazadores de la lista ***");
var squadTwoHunters = listHunters
    .Take(2)
    .ToList();

squadTwoHunters.ForEach(WriteLine);

WriteLine("\n*** 6. El Novato: Cazador con el nivel más bajo ***");
var hunterLevelMin = listHunters.OrderBy(a => a.Nivel).First();

WriteLine(hunterLevelMin);

WriteLine("\n*** 7. El Líder de Ranking: Cazador con el nivel más alto ***");

var hunterLevelMax = listHunters.OrderByDescending(a => a.Nivel).First();

WriteLine(hunterLevelMax);

WriteLine("\n*** 8. Búsqueda por Patrón: Clases que contengan la letra 'a' ***");
var huntersCaracters = listHunters
    .Where(a => a.Nombre.Contains("a", StringComparison.OrdinalIgnoreCase))
    .ToList();

huntersCaracters.ForEach(WriteLine);

WriteLine("\n*** 9. Nombres Legendarios: Nombres con más de 12 caracteres ***");
var legendaryNameHunters = listHunters
    .Where(a => a.Nombre.Length > 12)
    .ToList();

legendaryNameHunters.ForEach(WriteLine);

WriteLine("\n*** 10. Filtro de Seguridad: Gremio empieza por 'A' y longitud <= 6 ***");
var nameGuild = listHunters
    .Where(a => a.Nombre.StartsWith("A") && a.Nombre.Length <= 6)
    .ToList();

nameGuild.ForEach(WriteLine);

// ============================================================
// III. ESTADÍSTICAS Y AGREGACIÓN
// ============================================================

WriteLine("\n*** 11. Análisis de Niveles: Count, Average, Max y Min de niveles ***");
// Tu código aquí...

WriteLine("\n*** 12. Cazadores del Gremio Blanco: Miembros de 'White Tiger' ***");
// Tu código aquí...

WriteLine("\n*** 13. MVP: El objeto Cazador con el nivel más alto ***");
// Tu código aquí...


// ============================================================
// IV. AGRUPACIÓN (GROUP BY)
// ============================================================

WriteLine("\n*** 14. Despliegue por Gremios: Listado de nombres bajo cada gremio ***");
// Tu código aquí...

WriteLine("\n*** 15. Poder Gremial: Nivel promedio por cada gremio ***");
// Tu código aquí...

WriteLine("\n*** 16. Puntas de Lanza: El cazador de mayor nivel de cada gremio ***");
// Tu código aquí...

WriteLine("\n*** 17. Extremos por Gremio: Máximo, Mínimo y nombres de los responsables ***");
// Tu código aquí...

WriteLine("\n*** 18. Estadísticas de Rango: Cantidad, Max y Promedio por Rango (S, A, B...) ***");
// Tu código aquí...


// ============================================================
// V. FILTROS AVANZADOS (HAVING)
// ============================================================

WriteLine("\n*** 19. Gremios Masivos: Gremios con más de 3 cazadores ***");
// Tu código aquí...

WriteLine("\n*** 20. Gremios de Élite: Gremios con promedio de nivel > 80 ***");
// Tu código aquí...

WriteLine("\n*** 21. Podio de Poder: Los 3 mejores cazadores por nivel ***");
// Tu código aquí...


// ============================================================
// VI. PAGINACIÓN Y EXISTENCIA
// ============================================================

WriteLine("\n*** 22. Paginación: Mostrar Página 1, 2 y 3 (5 elementos c/u) ***");
// Tu código aquí...

WriteLine("\n*** 23. Alerta de Monarca: ¿Existe algún cazador de clase 'Monarca'? ***");
// Tu código aquí...

WriteLine("\n*** 24. Supervivencia: ¿Todos los cazadores están vivos? ***");
// Tu código aquí...

WriteLine("\n*** 25. Búsqueda por ID: Obtener cazador con Id = 10 ***");
// Tu código aquí...

WriteLine("\n*** 26. Control de Duplicados: ¿Hay exactamente un 'Sung Jin-woo'? ***");
// Tu código aquí...


// ============================================================
// VII. PROYECCIONES (SELECT)
// ============================================================

WriteLine("\n*** 27. Ficha de Combate: Proyección de Nombre y Nivel ***");
// Tu código aquí...

WriteLine("\n*** 28. Resumen de Misión: Id, Nombre completo y prefijo de Gremio (3 letras) ***");
// Tu código aquí...

WriteLine("\n*** 29. Estado de Combate: Nombre y etiqueta 'Vanguardia' (>80) o 'Retaguardia' ***");
// Tu código aquí...

WriteLine("\n*** 30. Cálculo de Potencial: Nombre y Poder Total (Nivel * 100) ***");
// Tu código aquí...