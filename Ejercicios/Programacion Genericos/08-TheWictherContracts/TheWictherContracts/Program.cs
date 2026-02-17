// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Text;
using static System.Console;
using System.Text.RegularExpressions;
using Serilog;
using TheWictherContracts.Cache;
using TheWictherContracts.Collections;
using TheWictherContracts.Enums;
using TheWictherContracts.Exceptions;
using TheWictherContracts.Models;
using TheWictherContracts.Repositories;
using TheWictherContracts.Service;
using TheWictherContracts.Validator;

// ====================================================================
// GESTIÓN ACADÉMICA - CONFIGURACIÓN INICIAL
// ====================================================================


var loggerConfiguration = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(
        outputTemplate: "{Timestamp:HH:mm:ss.fff} [{Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

Log.Logger = loggerConfiguration;

Title = "📜 The Witcher Contracts";
OutputEncoding = Encoding.UTF8;
Clear();

Main();

Log.CloseAndFlush();
WriteLine("\n⌨️  Presiona una tecla para salir...");
ReadKey();
return;

// --------------------------------------------------------------------
// FLUJO PRINCIPAL
// --------------------------------------------------------------------

void Main() {
    IContratoService service = new ContratoService(
        ContratoRepository.Instance,
        new ValidadorContratoMonstruo(),
        new ValidadorContratoAsalto(),
        new LruCache<int, ContratoBase>(5)
    );


    foreach (var c in ContratosFactory.Seed()) {
        try {
            service.Save(c);
        }
        catch (ContratoException.NotFound ex) {
            Log.Warning("Semilla ignorada: ({p.Id}): {ex.Message})");
        }
    }

    OpcionMenu opcion;
    const string RegexOpcionMenu = @"^([0-9]|1[0-3])$";
    WriteLine("🚀 SISTEMA DE GESTIÓN DE CONTRATOS THE WITCHER (ESTILO BRUJO)");
    WriteLine(new string('━', 45));

    do {
        MostrarMenu();

        var opcionStr = LeerCadenaValidada("Slecciones una opcion: ", RegexOpcionMenu, "Opcion no valida (0-13).");
        var opcionValue = int.Parse(opcionStr);
        opcion = (OpcionMenu)opcionValue;

        switch (opcion) {
            case OpcionMenu.ListarTodas: ListarTodas(service); break;
            case OpcionMenu.BuscarId: BuscarPorId(service); break;
            case OpcionMenu.BuscarContratoMonstruo: BuscarContratoMonstruo(service); break;
            case OpcionMenu.AñadirContratoMonstruo: AñadirContratoMonstruo(service); break;
            case OpcionMenu.ActualizarContratoMonstruo: ActualizarContratoMonstruo(service); break;
            case OpcionMenu.EliminarContratoMonstruo: EliminarContratoMonstruo(service); break;
            case OpcionMenu.BuscarContratoAsalto: BuscarContratoAsalto(service); break;
            case OpcionMenu.AñadirContratoAsalto: AñadirContratoAsalto(service); break;
            case OpcionMenu.ActualizarContratoAsalto: ActualizarContratoAsalto(service); break;
            case OpcionMenu.EliminarContratoAsalto: EliminarContratoAsalto(service); break;
            case OpcionMenu.InformeContratos: InformeMonstruo(service); break;
            case OpcionMenu.InformeContratosMonstruos: InformeContratosMosntruos(service); break;
            case OpcionMenu.InformeContratosAsalto: InformeContratosAsalto(service); break;
            case OpcionMenu.Salir: WriteLine("\n👋 Cerrando el sistema. ¡Hasta pronto!");
        }


        if (opcion != OpcionMenu.Salir) {
            WriteLine("\n⌨️  Presione una tecla para continuar...");
            ReadKey();
        }
    } while (opcion != OpcionMenu.Salir);
}

void MostrarMenu() {
    WriteLine("\n📜 --- 1. TABLÓN GENERAL ---");
    WriteLine(new string('─', 45));
    WriteLine($"  {(int)OpcionMenu.ListarTodas}. 👥 Listar todos los contratos");
    WriteLine($"  {(int)OpcionMenu.BuscarId}. 🆔 Buscar contrato por ID");
    
    WriteLine("\n⚔️ --- 2. CONTRATOS DE MONSTRUOS ---");
    WriteLine(new string('─', 45));
    WriteLine($"  {(int)OpcionMenu.BuscarContratoMonstruo}. 🔍 Buscar Monstruos por Especie");
    WriteLine($"  {(int)OpcionMenu.AñadirContratoMonstruo}. ➕ Añadir Cacería");
    WriteLine($"  {(int)OpcionMenu.EliminarContratoMonstruo}. 🗑️  Eliminar Cacería");
    
    WriteLine("\n🛡️ --- 3. OPERACIONES DE ASALTO ---");
    WriteLine(new string('─', 45));
    WriteLine($"  {(int)OpcionMenu.BuscarContratoAsalto}. 🕵️  Buscar Asaltos (Sigilo/Fuerza)");
    WriteLine($"  {(int)OpcionMenu.AñadirContratoAsalto}. ➕ Añadir Operación");
    
    WriteLine("\n📊 --- 4. INFORMES E INTELIGENCIA ---");
    WriteLine(new string('─', 45));
    WriteLine($"  {(int)OpcionMenu.InformeContratosMonstruos}. 🐺 Informe de Monstruos");
    WriteLine($"  {(int)OpcionMenu.InformeContratosAsalto}. 🚩 Informe de Asaltos");
    
    WriteLine("\n🚪 --- 0. SALIR ---");
    WriteLine(new string('━', 45));
}

// ====================================================================
// MÉTODOS DE OPERACIÓN
// ====================================================================

void ListarTodas(IContratoService service) {
    WriteLine("\n👥 --- LISTADO INTEGRAL DEL PERSONAL ---");
    var lista = service.GetAll();
    ImprimirTablaContrato(lista);
}

void BuscarPorId(IContratoService service) {
    WriteLine("\n🆔 --- BÚSQUEDA POR ID ---");
    var idStr = LeerCadenaValidada("Introduzca ID: ", @"^\d+$", "Debe ser un número entero.");
    try {

    }
    catch (ContratoException.NotFound ex) {
        WriteLine($"❌ Error: {ex.Message}");
    }
}


void BuscarContratoMonstruo(IContratoService service) {
    WriteLine("\n🎓 --- LISTADO DE ESTUDIANTES ---");
    var lista = service.GenerarInformeMonstruos().Contratos;
    ImprimirTablaMonstruos(lista);
}




void ImprimirTablaContrato(IEnumerable<ContratoBase> lista) {
    var line = new string('━', 105);
    WriteLine(line);
    WriteLine(
        $"{"🆔 ID",-5} | {"📜 Título del Contrato",-40} | {"⚔️ LVL",-6} | {"💰 Paga",-12} | {"🎭 Tipo"}");
    WriteLine(line.Replace('━', '─'));

    foreach (var c in lista) {
        var tipo = c switch {
            ContratoMonstruo => "🐺 Cacería",
            ContratoAsalto => "🚩 Asalto",
            _ => "❓ Desconocido"
        };
        // c.id y c.titulo deben ser las propiedades de tu ContratoBase
        WriteLine($" {c.id,-5} | {c.titulo,-40} | {c.nivelRecomendado,-6} | {c.recompensa,8} Or. | {tipo}");
    }

    WriteLine(line);
}

void ImprimirTablaMonstruos(IEnumerable<ContratoMonstruo> lista) {
    var line = new string('━', 110);
    WriteLine(line);
    WriteLine(
        $"{"🆔 ID",-5} | {"📜 Contrato",-35} | {"🐺 Especie",-18} | {"⚔️ Nivel",-7} | {"💰 Recompensa"}");
    WriteLine(line.Replace('━', '─'));

    foreach (var m in lista) {
        // Usamos m.Monstruo que es tu enum EspecieCriatura
        WriteLine(
            $" {m.id,-5} | {m.titulo,-35} | {m.Monstruo,-18} | {m.nivelRecomendado,-7} | {m.recompensa,8} Orens");
    }

    WriteLine(line);
}

void ImprimirTablaAsaltos(IEnumerable<ContratoAsalto> lista) {
    var line = new string('━', 110);
    WriteLine(line);
    WriteLine(
        $"{"🆔 ID",-5} | {"🚩 Operación",-35} | {"👥 Enemigos",-12} | {"🥷 Sigilo",-10} | {"💰 Recompensa"}");
    WriteLine(line.Replace('━', '─'));

    foreach (var a in lista) {
        string sigiloStr = a.RequiereSigilo ? "✅ Sí" : "❌ No";
        WriteLine(
            $" {a.id,-5} | {a.titulo,-35} | {a.NumeroEnemigos,-12} | {sigiloStr,-10} | {a.recompensa,8} Orens");
    }

    WriteLine(line);
}

// ====================================================================
// APOYO (INPUT)
// ====================================================================


string LeerCadenaValidada(string prompt, string regex, string error) {
    while (true) {
        Write(prompt);
        var input = ReadLine()?.Trim() ?? "";
        if (Regex.IsMatch(input, regex)) return input;
        WriteLine($"❌ ERROR: {error}");
    }
}

