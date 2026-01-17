// See https://aka.ms/new-console-template for more information

using The_Witcher_3;
using The_Witcher_3.Model;

Console.WriteLine("=== INICIO DE COMBATE EN EL CONTINENTE ===\n");

void Separador(string titulo) {
    Console.WriteLine($"\n--- {titulo.ToUpper()} ---");
}
// FASE 1: Equipamiento Inicial
var geralt = new Brujo("Geralt", new RolAcero());
var vesemir = new Brujo("Vesemir", new RolQuen());
var lambert = new Brujo("Lambert", new RolIgni());
var ciri = new Brujo("Ciri", new RolMaestroPociones());

Console.WriteLine(geralt);
((RolAcero)geralt.Estrategia).AsestarGolpe();

Console.WriteLine(vesemir);
((RolQuen)vesemir.Estrategia).LanzarSeñal();

Console.WriteLine(lambert);
((RolIgni)lambert.Estrategia).LanzarSeñal();

Console.WriteLine(ciri);
((RolMaestroPociones)ciri.Estrategia).DestilarPocion();



// FASE 2: El Intercambio
Separador("Intercambio de Roles");
geralt.cambiarEstrategia(new RolQuen());
vesemir.cambiarEstrategia(new RolAcero());
lambert.cambiarEstrategia(new RolMaestroPociones());
ciri.cambiarEstrategia(new RolIgni());

// FASE 3: Verificación de Castings tras el cambio
Separador("Acciones post-intercambio");

Console.WriteLine($"{geralt.Nombre} ahora intenta magia:");
((RolQuen)geralt.Estrategia).LanzarSeñal();

Console.WriteLine($"{vesemir.Nombre} ahora intenta acero:");
((RolAcero)vesemir.Estrategia).AsestarGolpe();

Console.WriteLine($"{lambert.Nombre} ahora intenta hacer pociones:");
((RolMaestroPociones)lambert.Estrategia).DestilarPocion();

Console.WriteLine($"{ciri.Nombre} ahora intenta magia:");
((RolIgni)ciri.Estrategia).LanzarSeñal();

