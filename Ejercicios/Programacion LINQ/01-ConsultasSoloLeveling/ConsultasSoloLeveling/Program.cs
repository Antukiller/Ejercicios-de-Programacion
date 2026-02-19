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
var level = listHunters.Select(a => a.Nivel).ToList();

WriteLine($"Count: {level.Count}");
WriteLine($"Average: {level.Average():F2}");
WriteLine($"Max: {level.Max()}");
WriteLine($"Min: {level.Min()}");

WriteLine("\n*** 12. Cazadores del Gremio Blanco: Miembros de 'White Tiger' ***");
var memberGuild = listHunters
    .Where(a => a.Gremio == "White Tiger")
    .ToList();

memberGuild.ForEach(WriteLine);

WriteLine("\n*** 13. MVP: El objeto Cazador con el nivel más alto ***");
var objectHunter = listHunters.MaxBy(a => a.Nivel);

WriteLine(objectHunter);


// ============================================================
// IV. AGRUPACIÓN (GROUP BY)
// ============================================================

WriteLine("\n*** 14. Despliegue por Gremios: Listado de nombres bajo cada gremio ***");
var huntersByGuild = listHunters
    .GroupBy(a => a.Gremio)
    .ToList();

huntersByGuild.ForEach(a => {
    WriteLine($"Gremio: {a.Key}");
    a.ToList().ForEach(WriteLine);
});

WriteLine("\n*** 15. Poder Gremial: Nivel promedio por cada gremio ***");
var guildPower =  listHunters
    .GroupBy(a => a.Gremio)
    .ToDictionary(a => a.Key, a => a.Average(a => a.Nivel));

guildPower.ToList().ForEach(a => WriteLine($"{a.Key}: {a.Value:F2}"));

WriteLine("\n*** 16. Puntas de Lanza: El cazador de mayor nivel de cada gremio ***");
var highestLevelHunterGuild =  listHunters
    .GroupBy(a => a.Gremio)
    .ToDictionary(a => a.Key, a => a.MaxBy(a => a.Nivel) );

highestLevelHunterGuild.ToList().ForEach(a => WriteLine($"{a.Key}: {a.Value}"));

WriteLine("\n*** 17. Extremos por Gremio: Máximo, Mínimo y nombres de los responsables ***");
var huntersEnd = listHunters
    .GroupBy(a => a.Gremio)
    .ToDictionary(
        a => a.Key,
        a => new {
            Maximo = a.Max(a => a.Nivel),
            Minimo = a.Min(a => a.Nivel),
            MejorHunter = a.MaxBy(a => a.Nivel)?.Nombre,
            MinimoHunter = a.MinBy(a => a.Nivel)?.Nombre,

        }
    );

huntersEnd.ToList().ForEach(kv =>
    WriteLine(
        $"{kv.Key}: Mejor = {kv.Value} ({kv.Value.MejorHunter}), Peor={kv.Value.Minimo} ({kv.Value.MinimoHunter})"));



WriteLine("\n*** 18. Estadísticas de Rango: Cantidad, Max y Promedio por Rango (S, A, B...) ***");
var huntersRange = listHunters
    .GroupBy(a => a.Rango)
    .Select(g => new {
        Rango = g.Key,
        Maximo = g.Max(a => a.Nivel),    // Operamos sobre NIVEL (int)
        Minimo = g.Min(a => a.Nivel),    // Operamos sobre NIVEL (int)
        Media = g.Average(a => a.Nivel), // Operamos sobre NIVEL (int)
        Cantidad = g.Count()             // Solo contamos elementos
    })
    .ToList();

// Para imprimirlo:
huntersRange.ForEach(r => 
    WriteLine($"Rango {r.Rango}: Cantidad={r.Cantidad}, Max={r.Maximo}, Min={r.Minimo}, Media={r.Media:F2}"));

// ============================================================
// V. FILTROS AVANZADOS (HAVING)
// ============================================================

WriteLine("\n*** 19. Gremios Masivos: Gremios con más de 3 cazadores ***");
var massiveGuild = listHunters
    .GroupBy(a => a.Gremio)
    .ToDictionary(a => a.Key, a => a.Count())
    .Where(kv => kv.Value >= 3)
    .ToList();

massiveGuild.ForEach(kv => WriteLine($"{kv.Key}: {kv.Value} cazadores guapetones"));

WriteLine("\n*** 20. Gremios de Élite: Gremios con promedio de nivel > 80 ***");
var eliteGuild =  listHunters
    .GroupBy(a => a.Gremio)
    .ToDictionary(a => a.Key, a => a.Average(a => a.Nivel))
    .Where(kv => kv.Value >= 80)
    .ToList();

eliteGuild.ForEach(kv => WriteLine($"{kv.Key}: Media = {kv.Value:F2}"));

WriteLine("\n*** 21. Podio de Poder: Los 3 mejores cazadores por nivel ***");
var eliteHunters = listHunters
    .OrderByDescending(a => a.Nivel)
    .Take(3)
    .ToList();

eliteHunters.ForEach(WriteLine);


// ============================================================
// VI. PAGINACIÓN Y EXISTENCIA
// ============================================================

WriteLine("\n*** 22. Paginación: Mostrar Página 1, 2 y 3 (5 elementos c/u) ***");

var page1 = listHunters
    .Take(5)
    .ToList();
page1.ForEach(WriteLine);

WriteLine();
var page2 = listHunters
    .Skip(5)
    .Take(5)
    .ToList();
page2.ForEach(WriteLine);

WriteLine();
var page3 = listHunters
    .Skip(10)
    .Take(5)
    .ToList();
page3.ForEach(WriteLine);

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