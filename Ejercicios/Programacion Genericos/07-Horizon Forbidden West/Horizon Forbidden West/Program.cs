using System.Text;
using System.Text.RegularExpressions;
using Horizon_Forbidden_West.Collections;
using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Models;
using Horizon_Forbidden_West.Repositories;
using Horizon_Forbidden_West.Service;
using Horizon_Forbidden_West.Validator;
using Serilog;
using static System.Console;

// ====================================================================
// CONFIGURACIÓN INICIAL DE GAIA
// ====================================================================

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm} [{Level:u3}] {Message:lj}{NewLine}")
    .CreateLogger();

Title = "🏹 Protocolo ATLAS - Sistema GAIA";
OutputEncoding = Encoding.UTF8;
Clear();

Main();

Log.CloseAndFlush();
return;

// --------------------------------------------------------------------
// FLUJO PRINCIPAL
// --------------------------------------------------------------------

void Main() {
    // Inyección de dependencias con TUS nombres de clases
    IEntidadHorizonService service = new EntidadHorizonService(
        EntidadHorizonRepository.Instance,
        new ValidadorCazador(),
        new SaboteadorValidador(),
        new ValidadorMaquina()
    );

    OpcionMenu opcion;
    const string RegexMenu = @"^([0-9]|1[0-8])$";

    do {
        MostrarMenuGaia();
        var opStr = LeerCadenaValidada("👉 Seleccione protocolo: ", RegexMenu, "Opción no válida (0-18).");
        opcion = (OpcionMenu)int.Parse(opStr);

        try {
            switch (opcion) {
                case OpcionMenu.ListarTodas: ListarTodo(service); break;
                
                // MÁQUINAS
                case OpcionMenu.ListarMaquinas: ListarMaquinas(service); break;
                case OpcionMenu.AnadirMaquina: AnadirMaquina(service); break;
                case OpcionMenu.InformePeligrosidad: GenerarInformeMaquinas(service); break;

                // CAZADORES
                case OpcionMenu.ListarCazadores: ListarCazadores(service); break;
                case OpcionMenu.AnadirCazador: AnadirCazador(service); break;
                case OpcionMenu.InformeTribal: GenerarInformeCazadores(service); break;

                // SABOTEADORES
                case OpcionMenu.ListarSaboteadores: ListarSaboteadores(service); break;
                case OpcionMenu.AnadirSaboteador: AnadirSaboteador(service); break;
                case OpcionMenu.InformeCapacidades: GenerarInformeSaboteadores(service); break;

                case OpcionMenu.Salir: WriteLine("\n👋 Desconexión completada."); break;
                default: WriteLine("\n⚠️ Protocolo encriptado o no implementado."); break;
            }
        }
        catch (Exception ex) {
            Log.Error($"❌ Fallo en el sistema: {ex.Message}");
        }

        if (opcion != OpcionMenu.Salir) {
            WriteLine("\n⌨️  Presione una tecla para continuar...");
            ReadKey();
            Clear();
        }
    } while (opcion != OpcionMenu.Salir);
}

// ====================================================================
// RENDERIZADO DE MENÚS
// ====================================================================

void MostrarMenuGaia() {
    WriteLine("🚀 SISTEMA DE GESTIÓN ATLAS (GAIA)");
    WriteLine(new string('━', 50));
    WriteLine($"  {(int)OpcionMenu.ListarTodas}. 📊 Listar todo el personal y máquinas");
    WriteLine("\n🦖 --- SECTOR MÁQUINAS ---");
    WriteLine($"  {(int)OpcionMenu.ListarMaquinas}. 📜 Listar | {(int)OpcionMenu.AnadirMaquina}. ➕ Añadir");
    WriteLine($"  {(int)OpcionMenu.InformePeligrosidad}. ⚠️ INFORME PELIGROSIDAD");
    WriteLine("\n🏹 --- SECTOR CAZADORES ---");
    WriteLine($"  {(int)OpcionMenu.ListarCazadores}. 📜 Listar | {(int)OpcionMenu.AnadirCazador}. ➕ Añadir");
    WriteLine($"  {(int)OpcionMenu.InformeTribal}. 📊 INFORME PREPARACIÓN");
    WriteLine("\n💻 --- SECTOR SABOTEADORES ---");
    WriteLine($"  {(int)OpcionMenu.ListarSaboteadores}. 📜 Listar | {(int)OpcionMenu.AnadirSaboteador}. ➕ Añadir");
    WriteLine($"  {(int)OpcionMenu.InformeCapacidades}. 📈 INFORME CAPACIDADES");
    WriteLine($"\n  0. SALIR");
    WriteLine(new string('━', 50));
}

// ====================================================================
// LÓGICA DE INFORMES
// ====================================================================

void GenerarInformeMaquinas(IEntidadHorizonService service) {
    var info = service.GenerarInformeMaquina();
    WriteLine("\n🦖 --- INFORME DE AMENAZAS MECÁNICAS ---");
    WriteLine($"Total: {info.TotalMaquinas} | Críticas: {info.AmenazasCriticas}");
    WriteLine($"Éxito Hackeo: {info.PorcentajeHackeo:F2}%");
    ImprimirTablaMaquinas(info.PorPeligrosidad);
}

void GenerarInformeSaboteadores(IEntidadHorizonService service) {
    var info = service.GenerarInformeSaboteador();
    WriteLine("\n💻 --- INFORME DE CAPACIDADES TÉCNICAS ---");
    WriteLine($"Personal: {info.TotalSaboteadores} | Media Exp: {info.MediaAñosExperiencia:F1} años");
    ImprimirTablaSaboteadores(info.PorExperiencia);
}

void GenerarInformeCazadores(IEntidadHorizonService service) {
    var info = service.GenerarInformeCazador();
    WriteLine("\n🏹 --- INFORME DE PREPARACIÓN TRIBAL ---");
    WriteLine($"Total: {info.TotalCazadores} | Índice: {info.IndicePreparacion:F2}%");
    // ImprimirTablaCazadores si la tienes lista
}

// ====================================================================
// TABLAS Y ALTAS
// ====================================================================

void ListarTodo(IEntidadHorizonService service) {
    var lista = service.GetAll();
    WriteLine($"{"ID",-5} | {"NOMBRE",-25} | {"TIPO",-15}");
    foreach (var e in lista) {
        string tipo = e switch { Maquina => "Máquina", Cazador => "Cazador", Saboteador => "Saboteador", _ => "Desconocido" };
        WriteLine($"{e.Id,-5} | {e.Nombre,-25} | {tipo,-15}");
    }
}

void AnadirMaquina(IEntidadHorizonService service) {
    WriteLine("\n➕ --- REGISTRAR MÁQUINA ---");
    var nom = LeerCadenaValidada("Nombre: ", @"^[a-zA-Z\s]{3,20}$", "Nombre inválido.");
    WriteLine("1.Minima, 2.Moderada, 3.Elevada, 4.Extrema");
    var pel = (NivelAmenaza)(int.Parse(LeerCadenaValidada("Peligrosidad: ", "^[1-4]$", "1-4")) - 1);
    var sab = PedirConfirmacion("¿Es saboteable?");

    service.Save(new Maquina { Nombre = nom, Peligrosidad = pel, EsSaboteabale = sab });
    WriteLine("✅ Registrada.");
}

void ListarMaquinas(IEntidadHorizonService service) => 
    ImprimirTablaMaquinas(service.GetMaquinasOrdeBy(TipoOrdenamiento.Peligrosidad));

void ImprimirTablaMaquinas(ILista<Maquina> lista) {
    foreach(var m in lista) WriteLine($"{m.Id,-5} | {m.Nombre,-20} | {m.Peligrosidad}");
}

void ImprimirTablaSaboteadores(ILista<Saboteador> lista) {
    foreach(var s in lista) WriteLine($"{s.Id,-5} | {s.NombreCompleto,-20} | {s.añosExperiencia} años");
}

// ====================================================================
// UTILS
// ====================================================================

string LeerCadenaValidada(string prompt, string regex, string error) {
    while (true) {
        Write(prompt);
        var input = ReadLine()?.Trim() ?? "";
        if (Regex.IsMatch(input, regex)) return input;
        WriteLine($"❌ {error}");
    }
}

bool PedirConfirmacion(string mensaje) {
    Write($"{mensaje} (S/N): ");
    var tecla = ReadKey().Key;
    WriteLine();
    return tecla == ConsoleKey.S;
}

// Stubs para evitar errores si no los implementas aún
void ListarCazadores(IEntidadHorizonService s) => WriteLine("Listado no implementado.");
void AnadirCazador(IEntidadHorizonService s) => WriteLine("Alta no implementada.");
void ListarSaboteadores(IEntidadHorizonService s) => ImprimirTablaSaboteadores(s.GetSaboteadores(TipoOrdenamiento.Experiencia));
void AnadirSaboteador(IEntidadHorizonService s) => WriteLine("Alta no implementada.");