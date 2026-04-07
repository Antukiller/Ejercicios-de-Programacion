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
        WriteLine($"{(int)OpcionMenu.ListarVehiculos}. 📜 Listar Vehiculo");
        WriteLine($"{(int)OpcionMenu.AnadirVehiculo}. ➕ Añadir Vehiculo");
        WriteLine($"{(int)OpcionMenu.ActualizarVehiculo}. 📝 Actualizar Vehiculo");
        WriteLine($"{(int)OpcionMenu.EliminarVehiculo}. 🗑️ Eliminar Vehiculo");
        WriteLine($"{(int)OpcionMenu.InformeVehiculo}. 📊 Informe los Vehiculos");
        
        WriteLine("\n💾 --- 4. Importar/Exportar datos ---");
        WriteLine(new string('-', 80));
        WriteLine($"{(int)OpcionMenu.ImportarDatos}. 📥 Importar los datos desde fichero.");
        WriteLine($"{(int)OpcionMenu.ExportarDatos}. 📤 Exportar los datos a fichero.");
        
        WriteLine("\n📀 --- 5. Copias de seguridad ---");
        WriteLine(new string('-', 80));
        WriteLine($"{(int)OpcionMenu.RealizarBackup}. 💾 Crear Backup");
        WriteLine($"{(int)OpcionMenu.RestaurarBackup}. ♻️ Restaurar Backup");
        
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
        var modelo = LeerCadenaValida();
        var marca = LeerCadenaValida();
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

        var dni = LeerCadenaValida();
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
    
}