// See https://aka.ms/new-console-template for more information

using Serilog;
using System.Text;
using System.Text.RegularExpressions;
using One_Piece_World;
using One_Piece_World.Collections;
using One_Piece_World.Enum;
using One_Piece_World.Repositories;
using One_Piece_World.Service;
using One_Piece_World.Validator.Common; // Ajusta a tu namespace real

// ====================================================================
// GESTIÓN DE ENTIDADES ONE PIECE - PROGRAMA PRINCIPAL
// ====================================================================

// 1. Configuración del Logger Profesional (Serilog)
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

Console.Title = "One Piece Entity Manager - .NET 10 Edition";
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

// 2. Ejecución del Template de DAW
Main();

Log.CloseAndFlush();
Console.WriteLine("\n⌨️ Presiona una tecla para salir del Grand Line...");
Console.ReadKey();
return;

// --------------------------------------------------------------------
// DAW's Template: Lógica de Menú y Control
// --------------------------------------------------------------------
void Main() {
    // Inicialización del Servicio (Singleton Pattern)
    IServiceOnePiece service = new ServiceOnePiece(EntidadRepositoryListaEnlazadaPropia.GetInstance(),
        new PirataValidator(),
        new MarineValidator(),
        new FrutaDelDiabloValidator());
    
    OpcionMenu opcion;
    const string RegexOpcionMenu = "^[0-9]$"; // Valida entrada del 0 al 9

    do {
        MostrarMenu();
        
        string entrada = LeerCadenaValidada("Seleccione una orden: ", RegexOpcionMenu, "Opción no válida (0-9).");
        opcion = (OpcionMenu)int.Parse(entrada);

        switch (opcion) {
            case OpcionMenu.ObtenerTodo:
                MostrarListado(service.ObtenerTodo(), "CENSO GLOBAL");
                break;
            case OpcionMenu.ObternerPirata:
                MostrarListado(service.ObtenerPiratas(), "PIRATAS REGISTRADOS");
                break;
            case OpcionMenu.ObtenerMarine:
                MostrarListado(service.ObtenerMarines(), "OFICIALES DE LA MARINA");
                break;
            case OpcionMenu.ObtenerFrutaDelDiablo:
                MostrarListado(service.ObtenerFrutas(), "ENCICLOPEDIA DE FRUTAS");
                break;
            case OpcionMenu.Buscar:
                EjecutarSubmenuBusqueda(service);
                break;
            case OpcionMenu.Añadir:
                MenuAñadirEntidad(service);
                break;
            case OpcionMenu.Actualizar:
                MenuActualizarEntidad(service);
                break;
            case OpcionMenu.Eliminar:
                MenuEliminarEntidad(service);
                break;
            case OpcionMenu.Estadisticas:
                MostrarEstadisticasMundiales(service);
                break;
            case OpcionMenu.Salir:
                Console.WriteLine("\n🌊 ¡Zarpando! El One Piece es real.");
                break;
        }
    } while (opcion != OpcionMenu.Salir);
}

// --------------------------------------------------------------------
// MÉTODOS DE INTERFAZ (UI)
// --------------------------------------------------------------------

void MostrarMenu() {
    Console.WriteLine("\n" + new string('=', 40));
    Console.WriteLine("        🏴‍☠️  GRAND LINE DATABASE  🏴‍☠️");
    Console.WriteLine(new string('=', 40));
    foreach (var op in Enum.GetValues<OpcionMenu>()) {
        Console.WriteLine($" [{(int)op}] {op}");
    }
    Console.WriteLine(new string('-', 40));
}

void MostrarListado(ILista<Entidad> lista, string titulo) {
    Console.Clear();
    Console.WriteLine($"\n--- 📜 {titulo} ---");
    if (lista.Contar() == 0) {
        Console.WriteLine("📭 No hay registros que mostrar.");
    } else {
        for (int i = 0; i < lista.Contar(); i++) {
            ImprimirFichaDetallada(lista.Obtener(i));
        }
    }
    Console.WriteLine("\nPresiona una tecla para volver al menú...");
    Console.ReadKey();
}

void EjecutarSubmenuBusqueda(IServiceOnePiece service) {
    Console.WriteLine("\n🔍 BUSCAR POR: 1. ID | 2. Nombre/Apodo");
    string sub = Console.ReadLine();

    if (sub == "1") {
        Console.Write("ID: ");
        if (int.TryParse(Console.ReadLine(), out int id)) 
            ImprimirFichaDetallada(service.BuscarPorId(id));
    } else {
        Console.Write("Texto: ");
        var resultados = service.BuscarPorNombre(Console.ReadLine() ?? "");
        MostrarListado(resultados, "RESULTADOS DE BÚSQUEDA");
    }
}

void ImprimirFichaDetallada(Entidad? e) {
    if (e == null) { Console.WriteLine("❌ No encontrado."); return; }

    Console.WriteLine($"\n{new string('-', 35)}");
    Console.WriteLine($"ID: {e.Id} | {e.NombreCompleto} (\"{e.Apodo}\")");
    
    // Pattern Matching para detalles específicos
    switch (e) {
        case Pirata p: 
            Console.WriteLine($"🏴‍☠️ Pirata | Bounty: {p.Recompensa:N0} | Banda: {p.Tripulacion}"); break;
        case Marine m: 
            Console.WriteLine($"🛡️ Marine | Rango: {m.Rango} | Base: {m.BaseAsignada}"); break;
        case FrutaDelDiablo f: 
            Console.WriteLine($"🍓 Fruta  | Tipo: {f.Fruta} | Despertar: {(f.IsDespertada ? "SÍ" : "NO")}"); break;
    }
}

void MostrarEstadisticasMundiales(IServiceOnePiece service) {
    Console.Clear();
    Console.WriteLine("\n--- 📊 ESTADÍSTICAS DEL NUEVO MUNDO ---");
    Console.WriteLine($"💰 Total Recompensas: {service.CalcularTotalRecompensas():N0} Berries");
    Console.WriteLine($"✨ Frutas Despertadas: {service.ContarDespertadas()}");
    Console.WriteLine("\nPresiona una tecla...");
    Console.ReadKey();
}

// --------------------------------------------------------------------
// VALIDACIONES Y LECTURA
// --------------------------------------------------------------------

string LeerCadenaValidada(string prompt, string regex, string error) {
    string input;
    do {
        Console.Write(prompt);
        input = Console.ReadLine()?.Trim() ?? "";
        if (Regex.IsMatch(input, regex)) return input;
        Console.WriteLine($"❌ {error}");
    } while (true);
}

void MenuAñadirEntidad(IServiceOnePiece service) {
    Console.Clear();
    Console.WriteLine("--- 🆕 AÑADIR AL SISTEMA ---");
    Console.WriteLine("1. Pirata | 2. Marine | 3. Fruta del Diablo");
    string tipo = LeerCadenaValidada("Seleccione tipo: ", "^[1-3]$", "Elija entre 1 y 3.");

    Console.Write("Nombre Completo: ");
    string nombre = Console.ReadLine() ?? "";
    Console.Write("Apodo: ");
    string apodo = Console.ReadLine() ?? "";

    Entidad? nueva = null;

    if (tipo == "1") {
        Console.Write("Recompensa: ");
        long.TryParse(Console.ReadLine(), out long rec);
        Console.Write("Tripulación: ");
        string banda = Console.ReadLine() ?? "Ninguna";
        nueva = new Pirata { NombreCompleto = nombre, Apodo = apodo, Recompensa = rec, Tripulacion = banda };
    }
    else if (tipo == "2") {
        Console.Write("Base Asignada: ");
        string baseNaval = Console.ReadLine() ?? "G-1";
        nueva = new Marine { NombreCompleto = nombre, Apodo = apodo, Rango = RangoMarine.Aprendiz, BaseAsignada = baseNaval };
    }
    else if (tipo == "3") {
        bool esDespertada = PedirConfirmacion("¿Está la fruta despertada?");
        nueva = new FrutaDelDiablo { NombreCompleto = nombre, Apodo = apodo, IsDespertada = esDespertada, Fruta = TipoFruta.Paramecia };
    }

    if (nueva != null) {
        service.AñadirEntidad(nueva); // Sin el "var resultado ="
        Console.WriteLine("✅ Registro procesado exitosamente.");
    }
}

void MenuActualizarEntidad(IServiceOnePiece service) {
    Console.Write("\nID de la entidad a actualizar: ");
    if (!int.TryParse(Console.ReadLine(), out int id)) return;

    var antiguo = service.BuscarPorId(id); // O BuscarPorId según tu Service
    if (antiguo == null) {
        Console.WriteLine("❌ No se encontró el registro.");
        return;
    }

    Console.WriteLine($"\n--- EDITANDO: {antiguo.NombreCompleto} ---");

    // 1. Campos comunes (Entidad)
    Console.Write($"Nuevo Nombre [{antiguo.NombreCompleto}]: ");
    string nuevoNombre = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(nuevoNombre)) nuevoNombre = antiguo.NombreCompleto;

    Console.Write($"Nuevo Apodo [{antiguo.Apodo}]: ");
    string nuevoApodo = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(nuevoApodo)) nuevoApodo = antiguo.Apodo;

    Entidad propuesta;

    // 2. Campos específicos mediante Pattern Matching
    switch (antiguo) {
        case Pirata p:
            Console.Write($"Nueva Recompensa [{p.Recompensa}]: ");
            string recStr = Console.ReadLine();
            long nuevaRec = string.IsNullOrWhiteSpace(recStr) ? p.Recompensa : long.Parse(recStr);

            Console.Write($"Nueva Tripulación [{p.Tripulacion}]: ");
            string nuevaBanda = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nuevaBanda)) nuevaBanda = p.Tripulacion;

            propuesta = p with { 
                NombreCompleto = nuevoNombre, 
                Apodo = nuevoApodo, 
                Recompensa = nuevaRec, 
                Tripulacion = nuevaBanda 
            };
            break;

        case Marine m:
            Console.Write($"Nueva Base [{m.BaseAsignada}]: ");
            string nuevaBase = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nuevaBase)) nuevaBase = m.BaseAsignada;
            
            // Aquí podrías añadir lógica para cambiar el Rango si usas Enums
            propuesta = m with { 
                NombreCompleto = nuevoNombre, 
                Apodo = nuevoApodo, 
                BaseAsignada = nuevaBase 
            };
            break;

        case FrutaDelDiablo f:
            bool nuevoDespertar = PedirConfirmacion($"¿Está despertada? (Actual: {f.IsDespertada})");
            
            propuesta = f with { 
                NombreCompleto = nuevoNombre, 
                Apodo = nuevoApodo, 
                IsDespertada = nuevoDespertar 
            };
            break;

        default:
            propuesta = antiguo with { NombreCompleto = nuevoNombre, Apodo = nuevoApodo };
            break;
    }

    // 3. Enviar al Service
    if (service.ActualizarEntidad(id, propuesta)) {
        Console.WriteLine("✅ Registro actualizado íntegramente.");
    } else {
        Console.WriteLine("❌ Error al actualizar (posible fallo de validación).");
    }
}

void MenuEliminarEntidad(IServiceOnePiece service) {
    Console.Write("\nID a eliminar: ");
    if (int.TryParse(Console.ReadLine(), out int id)) {
        bool ok = service.EliminarEntidad(id);
        Console.WriteLine(ok ? "✅ Registro marcado como borrado." : "❌ ID no existe.");
    }
}

bool PedirConfirmacion(string mensaje) {
    Console.Write($"\n⚠️ {mensaje} (S/N): ");
    var key = Console.ReadKey(false).Key;
    Console.WriteLine();
    return key == ConsoleKey.S;
}
