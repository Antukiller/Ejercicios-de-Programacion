// See https://aka.ms/new-console-template for more information

using The_Witcher_3Genericos.Models;

Console.WriteLine("Hola Continente");

Console.WriteLine("--- ACTO 1: EL BRUJO GENÉRICO ---");

Brujo<RolIgni> geralt = new Brujo<RolIgni>("Geralt de Rivia", new RolIgni());
geralt.Estrategia.PrepararInventario(geralt.Nombre);
geralt.Estrategia.LanzarSeñal(geralt.Nombre);

Brujo<RolAcero> ciri = new Brujo<RolAcero>("Cirilla", new RolAcero());
ciri.Estrategia.PrepararInventario(ciri.Nombre);
ciri.Estrategia.AsestarGolpe(ciri.Nombre);


Console.WriteLine("\n--- ACTO 2: COVARIANZA (SALIDA) ---");
CofreAlquimico<Pocion> cofrePocion = new CofreAlquimico<Pocion>();
cofrePocion.AgregarItem(new Pocion("Golondrina", 0.5) { DuracionEfecto = 5});
cofrePocion.AgregarItem(new Pocion("Buho real", 1) {DuracionEfecto = 10});
cofrePocion.AgregarItem(new Pocion("Sangre Negra", 0.8) {DuracionEfecto = 8});


IInventarioConsulta<Suministro> inventarioGeneral = cofrePocion;

Suministro s = inventarioGeneral.ObtenerItem(0);
Suministro i = inventarioGeneral.ObtenerItem(1);
Suministro j = inventarioGeneral.ObtenerItem(2);
Console.WriteLine($"Suministro 1: {s.Nombre}");
Console.WriteLine($"Suministro 2: {i.Nombre}");
Console.WriteLine($"Suministro 3: {j.Nombre}");


Console.WriteLine("\n--- ACTO 3: CONTRAVARIANZA (ENTRADA) ---");

IProcesadorAlquimico<Suministro> labGeneral = new LaboratorioAlquimico<Suministro>();
IProcesadorAlquimico<Extracto> procesadorExtractos = labGeneral;

Extracto extractoGraveir = new Extracto("Extracto de Graveir", 0.2) { NivelToxicidad = 50, DuracionEfecto = 180};
procesadorExtractos.analizar(extractoGraveir);