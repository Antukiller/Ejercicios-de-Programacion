// See https://aka.ms/new-console-template for more information

// --- ACTO 1: ESPECIALISTAS ---

using Solo_Leveling;

var chaHaeIn = new Cazador<RolAsesino>("Cha Hae-In", new RolAsesino());
chaHaeIn.Estilo.PrepararInventario(chaHaeIn.Nombre);
chaHaeIn.Estilo.EjecutarAtaque(chaHaeIn.Nombre);
Console.WriteLine();

// --- ACTO 2: MONARCA Y COVARIANZA ---
var jinWoo = new MonarcaSombras<IEstrategiaCombate>("Sung Jin-Woo", new RolAsesino());


var sombras = new EjercitoSombras<Sombra>();
sombras.AgregarSombra(new Sombra("Igris", "Caballero", 100));
sombras.AgregarSombra(new Sombra("Beru", "General", 500));
sombras.AgregarSombra(new Sombra("Kiba", "Caballero de elite", 250));

IAlmacenSombras<Entidad> almacenSombras = sombras;
Entidad a = almacenSombras.ObtenerSombra(0);
Entidad b = almacenSombras.ObtenerSombra(1);
Entidad c = almacenSombras.ObtenerSombra(2);
Console.WriteLine($"Entidad 1: {a.Nombre}");
Console.WriteLine($"Entidad 2: {b.Nombre}");
Console.WriteLine($"Entidad 3: {c.Nombre}");
Console.WriteLine();


// --- ACTO 3: PORTAL Y CONTRAVARIANZA ---
var portalGeneral = new PortalEvaluacion<Entidad>();
IEvaluadorAsosciacion<CazadorMagico> evaluadorMagos = portalGeneral; // in T funciona aquí
        
var mago = new CazadorMagico("Choi Jong-In", "S") { CapacidadMana = 50000 };
evaluadorMagos.analizar(mago);

// --- ACTO 4: ACCIÓN ---
Console.WriteLine("\n--- INCURSIÓN EN LA MAZMORRA ---");
jinWoo.Estilo.PrepararInventario(jinWoo.Nombre);
jinWoo.EjecutarHabilidadUnica();

jinWoo.CambiarEstilo(new RolMago());
jinWoo.EjecutarHabilidadUnica();

Console.WriteLine($"\n[INFO] Registro: Sombra detectada -> {sombras.ObtenerSombra(0).Nombre}");
Console.WriteLine(($"INFO] Registro: Sombra detectada -> {sombras.ObtenerSombra(1).Nombre}"));