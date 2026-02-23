// See https://aka.ms/new-console-template for more information

using ConsultasSoloLeveling.Models;
using static System.Console;
Console.OutputEncoding = System.Text.Encoding.UTF8;


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

// Configuración para visualizar emoticonos
Console.OutputEncoding = System.Text.Encoding.UTF8;

void Separator() => WriteLine(new string('─', 75));

// ============================================================
// I. CONSULTAS BÁSICAS DE SELECCIÓN (WHERE)
// ============================================================
WriteLine("\n*** 1. Listado General: Muestra todos los cazadores registrados ***");
listHunters.ToList().ForEach(WriteLine);

WriteLine("\n*** 2. Filtro por Inicial: Cazadores cuyo nombre empiece por 'S' o 'K' ***");
var filteredHuntersByName = listHunters
    .Where(a => a.Nombre.StartsWith("S") || a.Nombre.StartsWith("K"))
    .ToList();
filteredHuntersByName.ForEach(WriteLine);

WriteLine("\n*** 3. Censo: Número total de cazadores en el sistema ***");
var totalHuntersCount = listHunters.Count();
WriteLine(totalHuntersCount);

WriteLine("\n*** 4. Élite Activa: Rango S, Nivel > 20 y Gremio 'Hunters' ***");
var activeEliteHunters = listHunters
    .Where(a => a.Nivel > 20 && a.Gremio == "Hunters")
    .ToList();
activeEliteHunters.ForEach(WriteLine);

// ============================================================
// II. ELEMENTOS ÚNICOS (TAKE, FIRST, SINGLE)
// ============================================================
WriteLine("\n*** 5. Primer Escuadrón: Los 2 primeros cazadores de la lista ***");
var firstSquadHunters = listHunters
    .Take(2)
    .ToList();
firstSquadHunters.ForEach(WriteLine);

WriteLine("\n*** 6. El Novato: Imprimir el cazador con menor nivel ***");
var lowestLevelHunter = listHunters.OrderBy(a => a.Nivel).First();
WriteLine(lowestLevelHunter);

WriteLine("\n*** 7. Líder del Ranking: Imprimir el cazador con mayor nivel ***");
var highestLevelHunter = listHunters.OrderByDescending(a => a.Nivel).First();
WriteLine(highestLevelHunter);

WriteLine("\n*** 8. Búsqueda por Patrón: Clases que contienen la letra 'a' ***");
var huntersWithCharA = listHunters
    .Where(a => a.Nombre.Contains("a", StringComparison.OrdinalIgnoreCase))
    .ToList();
huntersWithCharA.ForEach(WriteLine);

WriteLine("\n*** 9. Nombres Legendarios: Alumnos cuyo nombre tiene más de 12 caracteres ***");
var longNamedHunters = listHunters
    .Where(a => a.Nombre.Length > 12)
    .ToList();
longNamedHunters.ForEach(WriteLine);

WriteLine("\n*** 10. Filtro de Seguridad: Gremio que empieza por 'A' y longitud <= 6 ***");
var securityFilteredHunters = listHunters
    .Where(a => a.Nombre.StartsWith("A") && a.Nombre.Length <= 6)
    .ToList();
securityFilteredHunters.ForEach(WriteLine);

// ============================================================
// III. ESTADÍSTICAS Y AGREGACIÓN
// ============================================================
WriteLine("\n*** 11. Análisis de Niveles: Count, Average, Max y Min de niveles ***");
var levelsList = listHunters.Select(a => a.Nivel).ToList();
WriteLine($"Count: {levelsList.Count}");
WriteLine($"Average: {levelsList.Average():F2}");
WriteLine($"Max: {levelsList.Max()}");
WriteLine($"Min: {levelsList.Min()}");

WriteLine("\n*** 12. Miembros del Gremio Blanco: Cazadores del gremio 'White Tiger' ***");
var whiteTigerMembers = listHunters
    .Where(a => a.Gremio == "White Tiger")
    .ToList();
whiteTigerMembers.ForEach(WriteLine);

WriteLine("\n*** 13. MVP: El objeto Cazador con el nivel más alto ***");
var mvpHunter = listHunters.MaxBy(a => a.Nivel);
WriteLine(mvpHunter);

// ============================================================
// IV. AGRUPACIÓN (GROUP BY)
// ============================================================
WriteLine("\n*** 14. Despliegue por Gremios: Listado de nombres bajo cada gremio ***");
var groupedByGuild = listHunters
    .GroupBy(a => a.Gremio)
    .ToList();

groupedByGuild.ForEach(a => {
    WriteLine($"\nGremio: {a.Key}");
    a.ToList().ForEach(WriteLine);
});

WriteLine("\n*** 15. Poder Gremial: Nota (nivel) media por cada gremio ***");
var averageLevelByGuild = listHunters
    .GroupBy(a => a.Gremio)
    .ToDictionary(a => a.Key, a => a.Average(a => a.Nivel));
averageLevelByGuild.ToList().ForEach(a => WriteLine($"{a.Key}: {a.Value:F2}"));

WriteLine("\n*** 16. Puntas de Lanza: El cazador de mayor nivel de cada gremio ***");
var topHunterPerGuild = listHunters
    .GroupBy(a => a.Gremio)
    .ToDictionary(a => a.Key, a => a.MaxBy(a => a.Nivel));
topHunterPerGuild.ToList().ForEach(a => WriteLine($"{a.Key}: {a.Value}"));

WriteLine("\n*** 17. Extremos por Gremio: Mejor y peor cazador por gremio ***");
var guildExtremesStats = listHunters
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
guildExtremesStats.ToList().ForEach(kv =>
    WriteLine($"{kv.Key}: Mejor = {kv.Value.Maximo} ({kv.Value.MejorHunter}), Peor = {kv.Value.Minimo} ({kv.Value.MinimoHunter})"));

WriteLine("\n*** 18. Estadísticas de Rango: Cantidad, Max y Promedio por Rango ***");
var statsByRank = listHunters
    .GroupBy(a => a.Rango)
    .Select(g => new {
        Rango = g.Key,
        Maximo = g.Max(a => a.Nivel),
        Minimo = g.Min(a => a.Nivel),
        Media = g.Average(a => a.Nivel),
        Cantidad = g.Count()
    })
    .ToList();
statsByRank.ForEach(r => 
    WriteLine($"Rango {r.Rango}: Cantidad={r.Cantidad}, Max={r.Maximo}, Min={r.Minimo}, Media={r.Media:F2}"));

// ============================================================
// V. FILTROS AVANZADOS (HAVING)
// ============================================================
WriteLine("\n*** 19. Gremios Masivos: Cursos (gremios) con más de 3 cazadores ***");
var massiveGuildsList = listHunters
    .GroupBy(a => a.Gremio)
    .ToDictionary(a => a.Key, a => a.Count())
    .Where(kv => kv.Value >= 3)
    .ToList();
massiveGuildsList.ForEach(kv => WriteLine($"{kv.Key}: {kv.Value} cazadores"));

WriteLine("\n*** 20. Gremios de Élite: Gremios con nota media mayor a 80 ***");
var eliteGuildsList = listHunters
    .GroupBy(a => a.Gremio)
    .ToDictionary(a => a.Key, a => a.Average(a => a.Nivel))
    .Where(kv => kv.Value >= 80)
    .ToList();
eliteGuildsList.ForEach(kv => WriteLine($"{kv.Key}: Media = {kv.Value:F2}"));

WriteLine("\n*** 21. Podio de Poder: Los 3 primeros cazadores por nota ***");
var topThreeHunters = listHunters
    .OrderByDescending(a => a.Nivel)
    .Take(3)
    .ToList();
topThreeHunters.ForEach(WriteLine);

// ============================================================
// VI. PAGINACIÓN Y EXISTENCIA
// ============================================================
WriteLine("\n*** 22. Paginación: Mostrar Página 1, 2 y 3 ***");
var firstPage = listHunters.Take(5).ToList();
firstPage.ForEach(WriteLine);
WriteLine("--- Siguiente Página ---");
var secondPage = listHunters.Skip(5).Take(5).ToList();
secondPage.ForEach(WriteLine);
WriteLine("--- Siguiente Página ---");
var thirdPage = listHunters.Skip(10).Take(5).ToList();
thirdPage.ForEach(WriteLine);

WriteLine("\n*** 23. Alerta de Monarca: ¿Existe algún cazador con clase 'Monarca'? ***");
var hasMonarchClass = listHunters.Any(a => a.Clase == "Monarca");
WriteLine(hasMonarchClass ? "⚠️ ¡Sí, hay un cazador clase Monarca!" : "No hay cazadores de esa clase.");

WriteLine("\n*** 24. Supervivencia: ¿Todos los cazadores están vivos? ***");
var allHuntersAlive = listHunters.All(a => a.EstaVivo);
WriteLine(allHuntersAlive ? "✅ Sí, todos están vivos." : "❌ No todos han sobrevivido.");

WriteLine("\n*** 25. Búsqueda por ID: Obtener cazador con ID = 10 ***");
var hunterByIdTen = listHunters.SingleOrDefault(a => a.Id == 10);
WriteLine(hunterByIdTen?.ToString() ?? "No encontrado");

WriteLine("\n*** 26. Control de Duplicados: ¿Hay exactamente un 'Sung Jin-woo'? ***");
var sungJinWooCount = listHunters.Count(a => a.Nombre == "Sung Jin-woo");
WriteLine(sungJinWooCount == 1 ? "✅ Sí, hay exactamente uno." : $"Hay {sungJinWooCount} registros.");

// ============================================================
// VII. PROYECCIONES (SELECT)
// ============================================================
WriteLine("\n*** 27. Ficha de Combate: Proyección de Nombre y Nivel ***");
var combatCardsInfo = listHunters
    .Select(a => new { a.Nombre, a.Nivel })
    .ToList();
combatCardsInfo.ForEach(WriteLine);

WriteLine("\n*** 28. Resumen de Misión: ID, Nombre completo y prefijo de Gremio ***");
var missionSummaries = listHunters
    .Select(a => new {
        Id = a.Id,
        NombreCompleto = a.Nombre,
        PrefijoGremio = a.Gremio.Length >= 3 ? a.Gremio.Substring(0, 3).ToUpper() : a.Gremio.ToUpper()
    })
    .ToList();
missionSummaries.ForEach(i => WriteLine($"ID: {i.Id}, Nombre: {i.NombreCompleto}, Gremio: {i.PrefijoGremio}"));

WriteLine("\n*** 29. Estado de Combate: Nombre y etiqueta Vanguardia (>80) o Retaguardia ***");
var unitDeploymentStatus = listHunters
    .Select(a => new {
        a.Nombre,
        Estado = a.Nivel > 80 ? "Vanguardia" : "Retaguardia"
    })
    .ToList();
unitDeploymentStatus.ForEach(i => WriteLine($"{i.Nombre}: {i.Estado}"));

WriteLine("\n*** 30. Cálculo de Potencial: Nombre y Poder Total (Nivel * 100) ***");
var potentialPowerStats = listHunters
    .Select(a => new {
        a.Nombre,
        Poder = a.Nivel * 100
    })
    .ToList();
potentialPowerStats.ForEach(i => WriteLine($"{i.Nombre}: {i.Poder} SP"));


// ============================================================
// CONSULTA EXTRA: RANGO MÁS FRECUENTE
// ============================================================

WriteLine("\n*** Extra: Rango que más aparece (el más común) ***");
var mostFrequentRange = listHunters
    .GroupBy(a => a.Rango)
    .OrderByDescending(a => a.Count())
    .Select(g => new {
        Rango = g.Key,
        Cantidad = g.Count()
    })
    .First();

WriteLine($"El rango más común es el {mostFrequentRange.Rango} con {mostFrequentRange.Cantidad} cazadores.");


WriteLine("\n*** Obtén el nombre del gremio cuya diferencia entre el nivel máximo y el nivel mínimo sea la más pequeña (menor brecha de poder) ***");
var differenceGuilds = listHunters
    .GroupBy(a => a.Gremio)
    .Select(g => new {
        Gremio = g.Key,
        Diferencia = g.Max(a => a.Nivel) - g.Min(a => a.Nivel)
    })
    .OrderBy(a => a.Diferencia)
    .First();

WriteLine($"El gremio más equilibrado es: {differenceGuilds.Gremio} (Brecha: {differenceGuilds.Diferencia})");
    
