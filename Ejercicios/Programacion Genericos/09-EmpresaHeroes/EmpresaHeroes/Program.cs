// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.RegularExpressions;
using EmpresaHeroes.Cache;
using EmpresaHeroes.Enums;
using EmpresaHeroes.Exceptions;
using EmpresaHeroes.Exceptions.Common;
using EmpresaHeroes.Models;
using EmpresaHeroes.Repositories;
using EmpresaHeroes.Service;
using EmpresaHeroes.Validator;
using EmpresaHeroes.Factory; // Importante para usar tu Factory
using Serilog;
using static System.Console;

// ====================================================================
// CONFIGURACIÓN DE LOGGING Y ENTORNO
// ====================================================================

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

Title = "🛡️ Academia de Héroes - Sistema de Gestión Profesional";
OutputEncoding = Encoding.UTF8;
Clear();

Main();

Log.CloseAndFlush();
WriteLine("\n⌨️ Presiona una tecla para salir...");
ReadKey();
return;

// --------------------------------------------------------------------
// FLUJO PRINCIPAL
// --------------------------------------------------------------------

void Main() {
    // 1. Inyección de Dependencias
    IHeroesService service = new HeroesService(
        HeroeRepository.Instance,
        new ValidadorGuerrero(),
        new ValidadorMago(),
        new ValidadorArquero(),
        new LruCache<int, Heroe>(10) // Cache con capacidad para 10 héroes
    );

    // 2. SEEDING: Cargamos tus 45 héroes iniciales usando tu Factory
    CargarSemilla(service);

    string opcion;
    const string RegexMenu = @"^[0-8]$";

    do {
        MostrarMenu();
        opcion = LeerCadenaValidada("👉 Seleccione una opción: ", RegexMenu, "Opción no válida (0-8).");

        try {
            switch (opcion) {
                case "1": ListarRanking(service); break;
                case "2": BuscarPorNombre(service); break;
                case "3": RegistrarNuevoHeroe(service); break;
                case "4": Entrenar(service); break;
                case "5": Descansar(service); break;
                case "6": EliminarHeroe(service); break;
                case "7": VerTop10(service); break;
                case "8": SimularMision(service); break;
                case "0": WriteLine("\n👋 Saliendo del sistema..."); break;
            }
        }
        catch (HeroeException.NotFound ex) { WriteLine($"\n❌ ERROR: {ex.Message}"); }
        catch (MisionException.InvalidOperation ex) { WriteLine($"\n⚠️ MISIÓN CANCELADA: {ex.Message}"); }
        catch (Exception ex) { Log.Error(ex, "Error no controlado"); }

        if (opcion != "0") {
            WriteLine("\n⌨️ Presione una tecla para continuar...");
            ReadKey();
        }
    } while (opcion != "0");
}

// --------------------------------------------------------------------
// MÉTODOS DE APOYO (UI Y LÓGICA)
// --------------------------------------------------------------------

void CargarSemilla(IHeroesService service) {
    Log.Information("Cargando semilla de datos desde HeroesFactory...");
    int cargados = 0;
    
    foreach (var h in HeroesFactory.Seed()) {
        try {
            service.Save(h);
            cargados++;
        }
        catch (HeroeException.Validation ex) {
            Log.Warning("Héroe {Nombre} ignorado por validación: {Errores}", h.Nombre, string.Join(", ", ex.Errores));
        }
        catch (HeroeException.AlreadyExists) {
            // Ignorar duplicados si se reinicia el programa
        }
    }
    Log.Information("Se han cargado {Total} héroes correctamente.", cargados);
}

void MostrarMenu() {
    WriteLine("\n📋 --- MENÚ DE GESTIÓN DE HÉROES ---");
    WriteLine(" 1. 👥 Listar todos (Ranking Poder)");
    WriteLine(" 2. 🔍 Buscar héroe por nombre");
    WriteLine(" 3. ➕ Registrar nuevo héroe");
    WriteLine(" 4. 💪 Entrenar héroe");
    WriteLine(" 5. 💤 Descansar héroe");
    WriteLine(" 6. 🗑️  Eliminar héroe");
    WriteLine(" 7. 🏆 Ver TOP 10 más poderosos");
    WriteLine(" 8. ⚔️  Simular Misión");
    WriteLine(" 0. 🚪 Salir");
    WriteLine(new string('━', 45));
}

void ListarRanking(IHeroesService service) {
    // Si no tienes GetHeroesOrderBy, usamos GetAll() y ordenamos con LINQ
    var lista = service.GetAll()
        .OrderByDescending(h => h.CalcularPoderTotal());
    
    ImprimirTabla(lista, "RANKING POR PODER TOTAL");
}
void RegistrarNuevoHeroe(IHeroesService service) {
    WriteLine("\n➕ --- ALTA DE HÉROE ---");
    var tipo = LeerCadenaValidada("Clase (1:Guerrero, 2:Mago, 3:Arquero): ", "^[1-3]$", "1-3");
    var nom = LeerCadenaValidada("Nombre: ", @".{3,30}", "Mínimo 3 caracteres.");
    var pod = double.Parse(LeerCadenaValidada("Poder Base: ", @"^\d+$", "Número entero."));

    Heroe nuevo = tipo switch {
        "1" => new Guerrero(nom, pod),
        "2" => new Mago(nom, pod),
        _   => new Arquero(nom, pod)
    };

    try {
        var guardado = service.Save(nuevo);
        WriteLine($"✅ Héroe {guardado.Nombre} creado con ID {guardado.Id}.");
    }
    catch (HeroeException.Validation ex) {
        WriteLine("\n⚠️ ERRORES:");
        foreach (var err in ex.Errores) WriteLine($" - {err}");
    }
}

void SimularMision(IHeroesService service) {
    WriteLine("\n⚔️ --- INICIANDO MISIÓN DE EQUIPO ---");
    var nom = LeerCadenaValidada("Nombre de la Misión: ", ".+", "El nombre es obligatorio.");
    
    // Selección de equipo: Tomamos los 3 con más nivel para asegurar éxito
    var equipo = service.GetAll()
        .OrderByDescending(h => h.Nivel)
        .Take(3)
        .ToHashSet();

    var mision = new Mision {
        Nombre = nom,
        Peligrosidad = DificultadadMision.Media,
        Equipo = equipo
    };

    var res = service.ResolverMision(mision);

    // RENDERIZADO DEL INFORME
    WriteLine("\n" + new string('═', 50));
    BackgroundColor = res.IsExito ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
    ForegroundColor = ConsoleColor.White;
    WriteLine($"  {(res.IsExito ? "🏆 VICTORIA" : "💀 DERROTA")}: {nom.ToUpper()}  ");
    ResetColor();
    WriteLine(new string('─', 50));

    WriteLine($"👥 Equipo enviado: {string.Join(", ", equipo.Select(h => h.Nombre))}");
    WriteLine($"📊 Poder del Equipo: {res.PoderTotalEquipo:F2}");
    WriteLine($"🚩 Umbral Requerido: {res.UmbralRequerido}");
    
    WriteLine(new string('─', 50));
    if (res.IsExito) {
        ForegroundColor = ConsoleColor.Green;
        WriteLine("¡Los héroes han regresado triunfantes a la academia!");
    } else {
        ForegroundColor = ConsoleColor.Red;
        WriteLine("El equipo ha sido superado. Necesitan más entrenamiento.");
    }
    ResetColor();
    WriteLine(new string('═', 50));
}

// Métodos restantes simplificados...
void BuscarPorNombre(IHeroesService s) => ImprimirTabla(s.BuscarPorNombre(ReadLine() ?? ""), "RESULTADOS");
void Entrenar(IHeroesService service) {
    Write("\n💪 Ingrese el ID del héroe a entrenar: ");
    if (int.TryParse(ReadLine(), out int id)) {
        try {
            // Obtenemos una referencia antes de entrenar para el mensaje
            var h = service.GetById(id);
            double poderAntes = h.PoderBase;
            
            service.EntrenarHeroe(id);
            
            // Feedback visual para el usuario
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("\n" + new string('✧', 30));
            WriteLine($"✨ ¡ENTRENAMIENTO COMPLETADO!");
            WriteLine($"{h.Nombre} ha mejorado sus habilidades.");
            WriteLine($"📈 Poder Base: {poderAntes} ➔ {h.PoderBase}");
            WriteLine($"🔋 Energía restante: {h.Energia}%");
            WriteLine(new string('✧', 30));
            ResetColor();
        }
        catch (HeroeException.NotFound) {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("❌ Error: No se encontró ningún héroe con ese ID.");
            ResetColor();
        }
    }
}
void Descansar(IHeroesService service) {
    Write("\n💤 Ingrese el ID del héroe que va a descansar: ");
    
    if (int.TryParse(ReadLine(), out int id)) {
        try {
            // 1. Obtenemos el héroe antes de descansar para mostrar su estado previo
            var heroe = service.GetById(id);
            int energiaAntes = heroe.Energia;

            // 2. Ejecutamos la acción a través del servicio
            service.DescansarHeroe(id);
            
            // 3. Feedback visual decorado
            WriteLine("\n" + new string('─', 40));
            ForegroundColor = ConsoleColor.Blue;
            WriteLine($"  🛌 ¡DESCANSO COMPLETADO: {heroe.Nombre}!");
            ResetColor();
            WriteLine(new string('─', 40));

            if (energiaAntes >= 100) {
                WriteLine("ℹ️ El héroe ya estaba totalmente recuperado.");
            } else {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine($"🔋 Energía: {energiaAntes}% ➔ {heroe.Energia}%");
                WriteLine("✨ El héroe se siente renovado y listo para la batalla.");
                ResetColor();
            }
            WriteLine(new string('─', 40));
        }
        catch (HeroeException.NotFound) {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("❌ Error: No se ha encontrado ningún héroe con ese ID.");
            ResetColor();
        }
        catch (Exception ex) {
            Log.Error(ex, "Error inesperado al intentar descansar");
            WriteLine("❌ Ocurrió un error al procesar el descanso.");
        }
    }
    else {
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("⚠️ Por favor, introduzca un número de ID válido.");
        ResetColor();
    }
}
void EliminarHeroe(IHeroesService s) { Write("ID: "); if(int.TryParse(ReadLine(), out int id)) s.Delete(id); }
void VerTop10(IHeroesService s) => ImprimirTabla(s.GetTopPoderosos(), "TOP 10 PODER");

// --------------------------------------------------------------------
// RENDERIZADO
// --------------------------------------------------------------------

void ImprimirTabla(IEnumerable<Heroe> lista, string titulo) {
    var line = new string('─', 85);
    WriteLine($"\n📊 --- {titulo} ---");
    WriteLine(line);
    WriteLine($"{"ID",-4} | {"Nombre",-20} | {"Nivel",-6} | {"Energía",-8} | {"Poder Total",-12}");
    WriteLine(line);
    foreach (var h in lista)
        WriteLine($"{h.Id,-4} | {h.Nombre,-20} | {h.Nivel,-6} | {h.Energia,-8} | {h.CalcularPoderTotal(),-12:F2}");
    WriteLine(line);
}

string LeerCadenaValidada(string prompt, string regex, string error) {
    while (true) {
        Write(prompt);
        var input = ReadLine()?.Trim() ?? "";
        if (Regex.IsMatch(input, regex)) return input;
        WriteLine($"❌ {error}");
    }
}