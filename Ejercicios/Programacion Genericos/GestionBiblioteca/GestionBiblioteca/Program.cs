// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.RegularExpressions;
using GestionBiblioteca.Collections;
using GestionBiblioteca.Enums;
using GestionBiblioteca.Models;
using GestionBiblioteca.Repositories;
using GestionBiblioteca.Services;
using GestionBiblioteca.Validator;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(
        outputTemplate: "{Timestamp:HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();
    
    
Console.Title = "Gestion Biblioteca";
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();


Main();

Log.CloseAndFlush();
Console.WriteLine("Press any key to exit.");
Console.ReadKey();
return;


void Main() {
    IBibliotecaService service = new BibliotecaService(
        LibroRespositoryListaEnlazadaPropia.GetInstance(),
        RevistaRepositoryListaEnlazadaPropia.GetInstance(),
        DvdRepositoryListaEnlazadaPropia.GetInstance(),
        new LibroValidator(),
        new RevistaValidator(),
        new DvdValidator()
    );
    
   
    
    OpcionMenu opcion;
    const string RegexOpcionMenu = "^[0-9]$"; 

    Console.WriteLine("📚 Sistema de Gestión de Biblioteca DAW");
    Console.WriteLine("========================================");

    do {
        MostrarMenu();

        string opcionStr;
        do {
            Console.Write("Seleccione una opción: ");
            opcionStr = Console.ReadLine()?.Trim() ?? "";
            if (!Regex.IsMatch(opcionStr, RegexOpcionMenu))
                Console.WriteLine("⚠️ Opción no válida (0-9).");
        } while (!Regex.IsMatch(opcionStr, RegexOpcionMenu));

        opcion = (OpcionMenu)int.Parse(opcionStr);

        try {
            switch (opcion) {
                case OpcionMenu.ListarLibros: ListarLibros(service); break;
                case OpcionMenu.ListarRevistas: ListarRevistas(service); break;
                case OpcionMenu.ListarDVDs: ListarDvds(service); break;
                case OpcionMenu.Añadir: MenuAnadir(service); break;
                case OpcionMenu.Eliminar: MenuEliminar(service); break;
                case OpcionMenu.Estadisticas: MostrarEstadisticas(service); break;
                case OpcionMenu.Salir: Console.WriteLine("👋 Saliendo..."); break;
                default: Console.WriteLine("🚧 Opción no disponible."); break;
            }
        } catch (Exception ex) {
            Console.WriteLine($"❌ ERROR: {ex.Message}");
        }

        if (opcion != OpcionMenu.Salir) {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

    } while (opcion != OpcionMenu.Salir);

    // --- FUNCIONES LOCALES ---

    void MostrarMenu() {
        Console.Clear();
        Console.WriteLine("\n--- MENÚ PRINCIPAL BIBLIOTECA ---");
        foreach (OpcionMenu opt in Enum.GetValues<OpcionMenu>()) {
            Console.WriteLine($"{(int)opt}. {opt}");
        }
        Console.WriteLine("---------------------------------");
    }

    void MenuAnadir(IBibliotecaService service) {
        Console.WriteLine("\n¿Qué desea añadir? 1. Libro | 2. Revista | 3. DVD");
        string tipo = Console.ReadLine() ?? "";
        switch (tipo) {
            case "1": AnadirLibro(service); break;
            case "2": AnadirRevista(service); break;
            case "3": AnadirDvd(service); break;
            default: Console.WriteLine("⚠️ Tipo inválido."); break;
        }
    }

    void AnadirLibro(IBibliotecaService service) {
        Console.WriteLine("\n--- Nuevo Libro ---");
    
        // Pedimos los datos (Asegúrate de pedir Autor y Estante para que no falle el Validator)
        string titulo = LeerCadenaValidada("Título: ", @"^.{2,100}$", "Mínimo 2 caracteres.");
        string autor = LeerCadenaValidada("Autor: ", @"^.{3,50}$", "Mínimo 3 caracteres.");
        string estante = LeerCadenaValidada("Estante: ", @"^[A-Z]-\d{2}$", "Formato: A-56.");
    
        // Aplicamos la Regex flexible para el ISBN
        string regexIsbn = @"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d\- ]+$";
        string isbn = LeerCadenaValidada("ISBN: ", regexIsbn, "Formato incorrecto. Debe tener 10 o 13 dígitos (puedes usar guiones).");

        try {
            var nuevoLibro = new Libro { 
                Titulo = titulo, 
                Autor = autor, 
                Estante = estante, 
                Isbn = isbn 
            };

            service.SaveLibro(nuevoLibro);
            Console.WriteLine("✅ Libro guardado correctamente con ISBN: " + isbn);
        } catch (Exception ex) {
            Console.WriteLine($"❌ ERROR: {ex.Message}");
        }
    }
    
    void AnadirRevista(IBibliotecaService service) {
        Console.WriteLine("\n--- Nueva Revista ---");
        string titulo = LeerCadenaValidada("Título: ", @"^.{3,50}$", "Mínimo 3 caracteres.");
    
        // 1. Cambiamos la Regex para que solo acepte dígitos (uno o más)
        string edicionStr = LeerCadenaValidada("Número de Edición: ", @"^\d+$", "La edición debe ser un número entero.");

        // 2. Convertimos el string a int al crear el objeto
        var revista = new Revista { 
            Titulo = titulo, 
            Edicion = int.Parse(edicionStr) // <-- Aquí hacemos la conversión
        };

        service.SaveRevista(revista);
        Console.WriteLine("✅ Revista guardada exitosamente.");
    }

    void AnadirDvd(IBibliotecaService service) {
        Console.WriteLine("\n--- Nuevo DVD ---");
        string titulo = LeerCadenaValidada("Título: ", @"^.{3,50}$", "3-50 caracteres.");
        string duracion = LeerCadenaValidada("Duración (min): ", @"^\d{1,3}$", "Número 1-999.");
        service.SaveDvd(new Dvd { Titulo = titulo, Duracion = int.Parse(duracion) });
        Console.WriteLine("✅ DVD guardado.");
    }

    void ListarLibros(IBibliotecaService service) {
        Console.WriteLine("\n--- LISTADO DE LIBROS ---");
    
        var libros = service.GetLibrosOrdenados(TipoOrdenamientoLibro.PorAutor);

        // Validación de seguridad
        if (libros == null) {
            Console.WriteLine("⚠️ Error: La lista de libros no se ha inicializado.");
            return;
        }

        if (libros.Contar() == 0) {
            Console.WriteLine("📭 No hay libros registrados actualmente.");
            return;
        }

        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine($"{"ID",-4} {"ISBN",-15} {"Título",-30}");
        Console.WriteLine("---------------------------------------------------------");
    
        for (int i = 0; i < libros.Contar(); i++) {
            var l = libros.Obterner(i);
            if (l != null) {
                Console.WriteLine($"{l.Id,-4} {l.Isbn,-15} {l.Titulo,-30}");
            }
        }
    }

    void ListarRevistas(IBibliotecaService service) {
        var lista = service.GetRevistasOrdenadas(TipoOrdenamientoRevista.PorTitulo);
        ImprimirTabla("REVISTAS", "EDICIÓN", lista, (r) => $"{r.Id,-4} {r.Edicion,-15} {r.Titulo,-30}");
    }

    void ListarDvds(IBibliotecaService service) {
        var lista = service.GetDvdsOrdenados(TipoOrdenamientoDvd.PorTitulo);
        ImprimirTabla("DVDs", "DURACIÓN", lista, (d) => $"{d.Id,-4} {d.Duracion + " min",-10} {d.Titulo,-35}");
    }

    void ImprimirTabla<T>(string titulo, string colEspecial, ILista<T> items, Func<T, string> formateador) {
        Console.WriteLine($"\n--- LISTADO DE {titulo} ---");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine($"{"ID",-4} {colEspecial,-15} {"Título",-30}");
        Console.WriteLine("---------------------------------------------------------");
        foreach (var item in items) Console.WriteLine(formateador(item));
    }

    void MenuEliminar(IBibliotecaService service) {
        Console.Write("\n¿Qué desea eliminar? 1. Libro | 2. Revista | 3. DVD: ");
        string tipo = Console.ReadLine() ?? "";
        Console.Write("Introduzca ID: ");
        if (int.TryParse(Console.ReadLine(), out int id) && PedirConfirmacion("¿Eliminar permanentemente?")) {
            if (tipo == "1") service.DeleteLibro(id);
            else if (tipo == "2") service.DeleteRevista(id);
            else if (tipo == "3") service.DeleteDvd(id);
            Console.WriteLine("✅ Eliminado.");
        }
    }

    string LeerCadenaValidada(string prompt, string regexPattern, string errorMsg) {
        while (true) {
            Console.Write(prompt);
            string input = (Console.ReadLine() ?? "").Trim();
            if (Regex.IsMatch(input, regexPattern)) return input;
            Console.WriteLine($"❌ {errorMsg}");
        }
    }

    bool PedirConfirmacion(string mensaje) {
        Console.Write($"\n⚠️ {mensaje} (S/N): ");
        return char.ToUpper(Console.ReadKey(true).KeyChar) == 'S';
    }

    void MostrarEstadisticas(IBibliotecaService service) {
        var i = service.GenerarInforme();
        Console.WriteLine($"\n📊 ESTADÍSTICAS: Total {i.TotalFichas} | L: {i.PorcentajeLibros}% | R: {i.PorcentajeRevistas}% | D: {i.PorcentajeDvds}%");
    }
    
    
}
