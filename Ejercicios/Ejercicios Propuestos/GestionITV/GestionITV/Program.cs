// See https://aka.ms/new-console-template for more information


using static System.Console;
using System.Text;
using GestionITV.Cache;
using GestionITV.Config;
using GestionITV.Enum;
using GestionITV.Exceptions;
using GestionITV.Factories.Repositories;
using GestionITV.Factories.Storage;
using GestionITV.Factory;
using GestionITV.Models;
using GestionITV.Service.Backup;
using GestionITV.Service.Vehiculos;
using GestionITV.Validator;
using Serilog;

var loggerConfiguracion = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(
        outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception} ")
        .CreateLogger();
        
        
Log.Logger = loggerConfiguracion;
Title = "GestionITV";
OutputEncoding = Encoding.UTF8;
Clear();

Main();

Log.CloseAndFlush();
WriteLine("\n⌨️ Presiona una tecla para salir...");
ReadKey();
return;

void Main() {
    var storage = StorageFactory.GetDefaultStorage(Configuracion.StorageType);
    var backupStorage = StorageFactory.GetDefaultStorage(Configuracion.BackupFormat);
    var repository = RepositoryFactory.GetDefaultRepository(Configuracion.RepositoryType);
    WriteLine($"Usando respositorio: {repository}");
    IBackupService backupService = new BackupService(backupStorage);


    IVehiculoService service = new VehiculosService(
        repository,
        storage,
        new ValidadorVehiculo(),
        new LruCache<int, Vehiculo>(5),
        backupService
    );

    if (Configuracion.RepositoryType.ToLower() != "binary") {
        repository.DeleteAll();
        VehiculoFactory.Seed().ToList().ForEach(v => service.Save(v));
    }

    OpcionMenu opcion;
    const string RegexOpcionMenu = @"^([0-3]|1[0-9])$";
    WriteLine(new string('-', 80));

    do {
        MostrarMenu();

        var opcionStr = LeerCadenaValida("Seleccione una opcion: ", RegexOpcionMenu, "Opción no válida (0-8)");
        var opcionValue = int.Parse(opcionStr);
        opcion = (OpcionMenu)opcionValue;

        switch (opcion) {
            case OpcionMenu.ListarTodos: ListarTodos(service); break;
            case OpcionMenu.BuscarPoDniPropietario: BuscarPorDniPropietario(service); break;
            case OpcionMenu.BuscarPorId: BuscarPorIdGeneral(service); break;
            case OpcionMenu.ListarVehiculos: ListarVehiculos(service); break;
            case OpcionMenu.AnadirVehiculo: AnadirNuevoVehiculo(service); break;
            case OpcionMenu.ActualizarVehiculo: ActualizarVehiculo(service); break;
            case OpcionMenu.EliminarVehiculo: EliminarVehiculo(service); break;
            case OpcionMenu.InformeVehiculo: MostrarInformeVehiculo(service); break;
            case OpcionMenu.InformeIndivudial: MostrarInformeIndividual(service); break;
            case OpcionMenu.ImportarDatos: ImportarDatos(service); break;
            case OpcionMenu.ExportarDatos: ExportarDatos(service); break;
            case OpcionMenu.RealizarBackup: RealizarBackup(service); break;
            case OpcionMenu.RestaurarBackup: RestaurarBackup(service); break;
            case OpcionMenu.Salir: WriteLine("\n🤪🤪Cerrando sistema. ¡Váyase de aqui vagabundo!😋😋"); break;
        }

        if (opcion != OpcionMenu.Salir) {
            WriteLine("\n⌨️ Presione una teclado para continuar.......");
            ReadKey();
        }

    } while (opcion != OpcionMenu.Salir);

    void MostrarMenu() {
        WriteLine("\n📝 ---1. Operaciones Generales ---");
        WriteLine(new string('-', 80));
        WriteLine($"    {(int)OpcionMenu.ListarTodos}. 🚗🚗 Listar todos los vehiculos.");
        WriteLine($"    {(int)OpcionMenu.BuscarPorId}. 🆔 Buscar vehiculo por ID.");
        WriteLine($"    {(int)OpcionMenu.BuscarPoDniPropietario}. 🪪 Buscar vehiculo por el DNI del propietario.");
        
        
        WriteLine("\n🚜 ---2. Gestión de los vehículos");
        WriteLine(new string('-', 80));
        WriteLine($"    {(int)OpcionMenu.ListarVehiculos}. 📜 Listar Vehiculo");
        WriteLine($"    {(int)OpcionMenu.AnadirVehiculo}. ➕ Añadir Vehiculo");
        WriteLine($"    {(int)OpcionMenu.ActualizarVehiculo}. 📝 Actualizar Vehiculo");
        WriteLine($"    {(int)OpcionMenu.EliminarVehiculo}. 🗑️ Eliminar Vehiculo");
        WriteLine($"    {(int)OpcionMenu.InformeVehiculo}. 📊 Informe los Vehiculos");
        
        WriteLine("\n💾 --- 4. Importar/Exportar datos ---");
        WriteLine(new string('-', 80));
        WriteLine($"    {(int)OpcionMenu.ImportarDatos}. 📥 Importar los datos desde fichero.");
        WriteLine($"    {(int)OpcionMenu.ExportarDatos}. 📤 Exportar los datos a fichero.");
        
        WriteLine("\n📀 --- 5. Copias de seguridad ---");
        WriteLine(new string('-', 80));
        WriteLine($"    {(int)OpcionMenu.RealizarBackup}. 💾 Crear Backup");
        WriteLine($"    {(int)OpcionMenu.RestaurarBackup}. ♻️ Restaurar Backup");
        
        WriteLine("\n👋 ---0. Salir ---");
        WriteLine(new string('-', 80));
        
    }
    
    // ===============================================================================
    // MÉTODOS DE OPERACIÓN
    // ===============================================================================

    void ListarTodos(IVehiculoService service) {
        WriteLine("\n🚜 --- LISTADO DE VEHÍCULOS ---");
        WriteLine("\n⚙️ Criterios: 1.ID, 2.DNI del Propietario, 3.Marca, 4.Modelo, 5.Matricula");
        var op = LeerCadenaValida("\n🔍 Seleccione criterio: ", "^[1-5]$", "Elija entre 1 y 5.");

        var criterio = op switch {
            "1" => TipoOrdenamiento.Id,
            "2" => TipoOrdenamiento.DniPropietario,
            "3" => TipoOrdenamiento.Marca,
            "4" => TipoOrdenamiento.Modelo,
            _ => TipoOrdenamiento.Matricula
        };
        var lista = service.GetAllOrderBy(criterio);
        ImprimirTablaVehículos(lista);
    }

    void BuscarPorIdGeneral(IVehiculoService service) {
        WriteLine("\n🆔 --- Búsqueda por ID ---");
        var idStr = LeerCadenaValida("Introduzca ID: ", @"^\d+$", "Debe ser un numero entero.");
        try {
            var v = service.GetById(int.Parse(idStr));
            ImprimirTablaVehículos(v);
        }
        catch (VehiculoException.NotFound ex) {
            WriteLine($"❌ ERROR: {ex.Message}");
        }
    }

    void BuscarPorDniPropietario(IVehiculoService service) {
        WriteLine("\n🪪 --- Búsqueda por Dni ---");
        var dni = LeerDniValidado();
        try {
            var v = service.GetByDniPropietario(dni);
            ImprimirTablaVehículos(v);
        }
        catch (VehiculoException.NotFound ex) {
            WriteLine($"❌ ERROR: {ex.Message}");
            throw;
        }
    }

    void ListarVehiculos(IVehiculoService service) {
        WriteLine("\n🚓🚨 --- Listado de Vehiculos ---");
        WriteLine("\n🔍 Criterios: 1.ID, 2.Dni del Propietario, 3.Marca, 4.Modelo, 5.Cilindrada, 6.Motor, 7.Matrícula");
        var op = LeerCadenaValida("\n Seleccione criterio: ", "^[1-7]$", "Elija entre 1 y 7.");

        var criterio = op switch {
            "1" => TipoOrdenamiento.Id,
            "2" => TipoOrdenamiento.DniPropietario,
            "3" => TipoOrdenamiento.Marca,
            "4" => TipoOrdenamiento.Modelo,
            "5" => TipoOrdenamiento.Cilindrada,
            "6" => TipoOrdenamiento.Motor,
            _ => TipoOrdenamiento.Matricula
        };
        var lista = service.GetAllOrderBy(criterio);
        ImprimirTablaVehículos(lista);
    }

    void AnadirNuevoVehiculo(IVehiculoService service) {
        WriteLine("\n➕ --- Alta de nuevo Vehículo ---");
        WriteLine(" 0. ⬅️ Volver");

        if (!PedirConfimacion("¿Desea dar de alta un nuevo vehiculo?")) {
            WriteLine("👋 Operación cancelada");
            return;
        }


        var dni = LeerDniValidado();
        var modelo = LeerCadenaValida("Modelo: ", @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{2,30}$", "Mínimo 2 car.");
        var marca = LeerCadenaValida("Marca: ", @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{2,30}$", "Mínimo 2 car.");
        var motor = LeerMotor();
        var cilindrada = LeerCilindradaValida();
        var matricula = LeerMatriculaValida();
        
        var temp = new Vehiculo 
            { DniPropietario = dni, Modelo = modelo, Marca = marca, Motor = motor, Cilindrada = cilindrada,  Matricula = matricula };
        WriteLine("\n👀 Revise los datos para su correcto funcionamiento🙈");
        ImprimirTablaVehículos(temp);
        
        if (PedirConfimacion("¿Confimar alta del vehiculo?"))
            try {
                var creado = service.Save(temp);
                WriteLine("✅ Guardado exitosamente");
                ImprimirTablaVehículos(creado);
            }
            catch (VehiculoException.Validation ex) {
                ImprimirErroresValidacion(ex.Errores);
            }

            catch (VehiculoException.AlreadyExists ex) {
                WriteLine($"❌ CONFLICTO: {ex.Message}");
            }

            catch (Exception ex) {
                WriteLine($"💀 ERROR DESCONOCIDO: {ex.Message}");
            }
    }


    void ActualizarVehiculo(IVehiculoService service) {
        WriteLine("\n➕ --- Actualización de Vehiculo ---");
        WriteLine(" 0. ⬅️ Volver");

        if (!PedirConfimacion("¿Desea dar de alta un nuevo vehiculo?")) {
            WriteLine("👋 Operación cancelada");
            return;
        }

        var dni = LeerDniValidado();
        try {
            var v = service.GetByDniPropietario(dni);
            if (v is not Vehiculo vehiculo) {
                WriteLine("❌ ERROR: No es un Vehículo");
                return;
            }

            ImprimirTablaVehículos(vehiculo);
            var nMarca = LeerCadenaValida($"👤 Nombre [{vehiculo.Marca}] (Enter mant.): ",
                @"^([a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{2,30})?$",
                "Error.");

            var nModelo = LeerCadenaValida($"👤 Nombre [{vehiculo.Modelo}] (Enter mant.): ",
                @"^([a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{2,30})?$",
                "Error.");
            var nDniPropietario = PedirConfimacion("Desea cambiar el DNI del propietario del vehículos?")
                ? LeerDniValidado()
                : vehiculo.DniPropietario;

            var nCilindrada = PedirConfimacion("¿Desea cambiar la cilindrada del vehiculo?")
                ? LeerCilindradaValida()
                : vehiculo.Cilindrada;

            var nMartricula = PedirConfimacion("¿Desea cambiar la martricula del vehiculo?")
                ? LeerMatriculaValida()
                : vehiculo.Matricula;

            var nMotor = PedirConfimacion("¿Desea cambiar el motor del vehiculo?")
                ? LeerMotor()
                : vehiculo.Motor;

            var act = vehiculo with {
                Marca = string.IsNullOrWhiteSpace(nMarca) ? vehiculo.Marca : nMarca,
                Modelo = string.IsNullOrWhiteSpace(nModelo) ? vehiculo.Modelo : nModelo,
                Matricula = string.IsNullOrWhiteSpace(nMartricula) ? vehiculo.Matricula : nMartricula,
                DniPropietario = string.IsNullOrWhiteSpace(nDniPropietario) ? vehiculo.DniPropietario : nDniPropietario,
                Motor = nMotor, Cilindrada = nCilindrada
            };

            WriteLine("\n👀 Revise los cambios efectuados y no toque nada ¡Simio!🙉");
            ImprimirTablaVehículos(act);
            if (PedirConfimacion("¿Actualizar?")) {
                var actualizado = service.Update(vehiculo.Id, act);
                WriteLine("✅ Actualizado correctamente");
                ImprimirTablaVehículos(actualizado);
            }
        }
        catch (VehiculoException.Validation ex) {
            ImprimirErroresValidacion(ex.Errores);
        }
        catch (VehiculoException.NotFound ex) {
            WriteLine($"❌ ERROR: {ex.Message}");
        }
        catch (Exception ex) {
            WriteLine($"💀  ERROR DESCONOCIDO: {ex.Message}");
        }

    }

    void EliminarVehiculo(IVehiculoService service) {
        WriteLine("\n🚮 --- Eliminación del Vehículo ---");
        var dni = LeerDniValidado();
        try {
            var v = service.GetByDniPropietario(dni);
            foreach (var vehiculo in v) {
                WriteLine("Analizando: {vehiculo.Marca} {vehiculo.Modelo} ({vehiculo.Matricula})");
                if (PedirConfimacion("¿Desea eliminar este vehículo")) {
                    service.Delete(vehiculo.Id);
                    WriteLine("🚮 Vehiculo Eliminado correctamente");
                    ImprimirTablaVehículos(vehiculo);
                }
            }
            
        }
        catch (VehiculoException.NotFound ex) {
            WriteLine($"❌ ERROR: {ex.Message}");
        }
        catch (Exception ex) {
            WriteLine($"☠️ ERROR DESCONOCIDO: {ex.Message}");
        }
    }

    void MostrarInformeVehiculo(IVehiculoService service) {
        var informes = service.GenerarTodosInformeVehiculo(); 
        WriteLine("\n📊 --- INFORME RESUMIDO DE VEHÍCULOS ---");
        WriteLine(new string('-', 80));
        foreach (var info in informes) {
            WriteLine($"[{info.Id}] {info.MarcaModelo} - Matrícula: {info.Matricula}");
            WriteLine($"    Motor: {info.DatosMotor} | Propietario: {info.PropietarioDni}");
            WriteLine(new string('.', 80));
        }
    }
    
    void MostrarInformeIndividual(IVehiculoService service) {
        WriteLine("\n📊 --- CONSULTA DE INFORME TÉCNICO ---");
    
        // Pedimos el ID usando tu función de apoyo
        var idStr = LeerCadenaValida("Introduzca el ID del vehículo: ", @"^\d+$", "Debe ser un número.");
        int id = int.Parse(idStr);

        try {
            // Llamamos al servicio
            var info = service.GenerarInformeVehiculPorId(id);

            // Imprimimos el informe con formato de "ficha"
            WriteLine("\n" + new string('=', 40));
            WriteLine($"   INFORME DEL VEHÍCULO #{info.Id}");
            WriteLine(new string('-', 40));
            WriteLine($" 🚗 MARCA/MODELO: {info.MarcaModelo}");
            WriteLine($" 🎫 MATRÍCULA:    {info.Matricula}");
            WriteLine($" ⚙️  MOTORIZACIÓN: {info.DatosMotor}");
            WriteLine($" 🪪 PROPIETARIO:  {info.PropietarioDni}");
            WriteLine(new string('=', 40));
        }
        catch (VehiculoException.NotFound) {
            WriteLine($"\n❌ ERROR: No se encontró ningún vehículo con el ID {id}.");
        }
    }

    
    // ===============================================================================
    // MÉTODOS DE IMPORTACIÓN, EXPORTACIÓN Y BACKUP
    // ===============================================================================

void ImportarDatos(IVehiculoService service) {
    WriteLine("\n📥 --- IMPORTAR DATOS DESDE FICHERO ---");
    // Usamos Configuracion.ItvFile que es el que tienes en tu Service
    if (!PedirConfimacion(
            $"¿Desea importar los datos desde el fichero: {Configuracion.ItvFile}?\n⚠️ Esta acción sobrescribirá los datos actuales.")) {
        WriteLine("👋 Operación cancelada.");
        return;
    }
    
    try {
        var importados = service.ImportarDatos();
        WriteLine($"✅ ¡Éxito! Se han importado {importados} vehículos.");
    }
    catch (Exception ex) {
        WriteLine($"☠️ ERROR AL IMPORTAR: {ex.Message}");
    }
}

void ExportarDatos(IVehiculoService service) {
    WriteLine("\n📤 --- EXPORTAR DATOS A FICHERO ---");
    try {
        var exportados = service.ExportarDatos();
        WriteLine($"✅ ¡Éxito! Se han exportado {exportados} vehículos a {Configuracion.ItvFile}.");
    }
    catch (Exception ex) {
        WriteLine($"☠️ ERROR AL EXPORTAR: {ex.Message}");
    }
}

void RealizarBackup(IVehiculoService service) {
    WriteLine("\n💾 --- CREAR COPIA DE SEGURIDAD (BACKUP) ---");
    if (!PedirConfimacion("¿Desea crear una copia de seguridad de la base de datos actual?")) {
        WriteLine("👋 Operación cancelada.");
        return;
    }

    try {
        var ruta = service.RealizarBackup();
        WriteLine("✅ Backup creado correctamente.");
        WriteLine($"📁 Archivo guardado en: {ruta}");
    }
    catch (Exception ex) {
        WriteLine($"☠️ ERROR AL CREAR BACKUP: {ex.Message}");
    }
}

void RestaurarBackup(IVehiculoService service) {
    WriteLine("\n♻️ --- RESTAURAR COPIA DE SEGURIDAD ---");

    // Listamos los archivos disponibles a través del service
    var backups = service.ListarBackups().ToList();
    
    if (backups.Count == 0) {
        WriteLine("❌ No se han encontrado copias de seguridad en la carpeta de Backup.");
        return;
    }

    WriteLine("\n📋 COPIAS DE SEGURIDAD DISPONIBLES:");
    WriteLine("   0. ⬅️ VOLVER");
    
    for (var i = 0; i < backups.Count; i++) {
        var file = new FileInfo(backups[i]);
        // Cálculo de tamaño amigable
        var size = file.Length < 1024 
            ? $"{file.Length} B" 
            : $"{Math.Round(file.Length / 1024.0, 1)} KB";
            
        WriteLine($"   {i + 1}. 📄 {file.Name} ({size}) - Creado: {file.CreationTime:g}");
    }

    var seleccion = LeerCadenaValida("\n🎯 Seleccione el número de archivo (0 para cancelar): ", @"^\d+$", "Por favor, introduzca un número válido.");
    var indice = int.Parse(seleccion) - 1;

    if (indice == -1) {
        WriteLine("👋 Operación cancelada.");
        return;
    }

    if (indice < 0 || indice >= backups.Count) {
        WriteLine("❌ Selección fuera de rango.");
        return;
    }

    var archivoSeleccionado = backups[indice];
    WriteLine($"\n🔎 Has seleccionado: {Path.GetFileName(archivoSeleccionado)}");

    if (!PedirConfimacion("⚠️ ADVERTENCIA: Esta acción borrará todos los vehículos actuales para restaurar la copia. ¿Continuar?")) {
        WriteLine("👋 Operación cancelada.");
        return;
    }

    try {
        var restaurados = service.RestaurarBackup(archivoSeleccionado);
        WriteLine($"✅ Restauración completada con éxito. {restaurados} vehículos cargados.");
    }
    catch (Exception ex) {
        WriteLine($"☠️ ERROR CRÍTICO AL RESTAURAR: {ex.Message}");
    }
}
    
    
    // ===============================================================================
    // FUNCIONES DE LECTURA Y VALIDACIÓN
    // ===============================================================================

    string LeerCadenaValida(string mensaje, string regex = @".+", string errorMsg = "Entrada no válida.") {
        while (true) {
            Write(mensaje);
            var entrada = ReadLine()?.Trim() ?? "";
            if (System.Text.RegularExpressions.Regex.IsMatch(entrada, regex)) {
                return entrada;
            }

            WriteLine($"❌ {errorMsg}");
        }

    }


    string LeerDniValidado() {
        // 8 números y una letra (mayúscula o minúscula)
        const string patronDni = @"^[0-9]{8}[TRWAGMYFPDXBNJZSQVHLCKEtrwagmyfpdxbnjzsqvhlcke]$";
        return LeerCadenaValida("🆔 Introduzca DNI del propietario: ", patronDni,
            "Formato incorrecto (8 números + 1 letra).");
    }

    string LeerMatriculaValida() {
        // Formato 1234ABC o 1234-ABC
        const string patronMatricula = @"^[0-9]{4}[ -]?[B-DF-HJ-NP-TV-Z]{3}$";
        return LeerCadenaValida("🚗 Introduzca Matrícula (1234ABC): ", patronMatricula, "Formato inválido (NNNNLLL).")
            .ToUpper();
    }

    double LeerCilindradaValida() {
        while (true) {
            var entrada = LeerCadenaValida("🔌 Introduzca Cilindrada (0.0 - 3.0): ", @"^[0-3](\.[0-9])?$",
                "Debe ser un número entre 0.0 y 3.0.");
            if (double.TryParse(entrada, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double valor)) {
                return valor;
            }
        }
    }

    Motor LeerMotor() {
        WriteLine("\n⚙️ Seleccione tipo de motor:");
        var opciones = System.Enum.GetValues<Motor>();
        for (int i = 0; i < opciones.Length; i++) {
            WriteLine($"{i}. {opciones[i]}");
        }
        var res = LeerCadenaValida("👉 Selección: ", $"^[0-{opciones.Length - 1}]$", "Opción de motor no válida.");
        return (Motor)int.Parse(res);

    }

    bool PedirConfimacion(string mensaje) {
        Write($"\n❓ {mensaje} (s/n): ");
        var respuesta = ReadKey().KeyChar.ToString().ToLower();
        WriteLine(); // Salto de línea estético
        return respuesta == "s";
    }

// ===============================================================================
// FUNCIONES DE SALIDA (TABLAS)
// ===============================================================================

    void ImprimirTablaVehículos(object datos) {
        WriteLine(new string('=', 100));
        WriteLine(
            $"{"ID",-4} | {"Matrícula",-10} | {"Marca",-12} | {"Modelo",-12} | {"Motor",-10} | {"DNI Propietario",-12}");
        WriteLine(new string('-', 100));

        if (datos is IEnumerable<Vehiculo> lista) {
            foreach (var v in lista) MostrarFila(v);
        }
        else if (datos is Vehiculo v) {
            MostrarFila(v);
        }

        WriteLine(new string('=', 100));

    }

    void MostrarFila(Vehiculo v) {
        WriteLine(
            $"{v.Id,-4} | {v.Matricula,-10} | {v.Marca,-12} | {v.Modelo,-12} | {v.Motor,-10} | {v.DniPropietario,-12}");
    }

    void ImprimirErroresValidacion(IEnumerable<string> errores) {
        WriteLine("\n⚠️ Se han encontrado errores de validación:");
        foreach (var error in errores) {
            WriteLine($"   - {error}");
        }
    }




}