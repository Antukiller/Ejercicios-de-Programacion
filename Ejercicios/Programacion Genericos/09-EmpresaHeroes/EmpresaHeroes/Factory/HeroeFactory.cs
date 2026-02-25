using EmpresaHeroes.Models;

namespace EmpresaHeroes.Factory;

using EmpresaHeroes.Models;

public static class HeroesFactory {
    /// <summary>
    /// Genera la semilla de datos inicial con 45 héroes usando los constructores de tus records.
    /// </summary>
    /// <returns>Lista de héroes para cargar en el sistema</returns>
    public static IEnumerable<Heroe> Seed() {
        var lista = new List<Heroe>();

        // --- GUERREROS (15) ---
        // Usamos el constructor primario (nombre, poderBase) y el inicializador de objetos { }
        lista.Add(new Guerrero("Alaric el Fuerte", 75.5) { Nivel = 85, Energia = 90, Experiencia = 40 });
        lista.Add(new Guerrero("Borg Rompemuros", 60.0) { Nivel = 42, Energia = 88, Experiencia = 15 });
        lista.Add(new Guerrero("Sir Cedric", 82.0) { Nivel = 95, Energia = 70, Experiencia = 50 });
        lista.Add(new Guerrero("Dara la Invicta", 70.5) { Nivel = 66, Energia = 95, Experiencia = 30 });
        lista.Add(new Guerrero("Einar el Gelido", 45.0) { Nivel = 30, Energia = 80, Experiencia = 10 });
        lista.Add(new Guerrero("Fenris Colmillo", 35.0) { Nivel = 12, Energia = 99, Experiencia = 5 });
        lista.Add(new Guerrero("Gunnar Hierro", 58.0) { Nivel = 55, Energia = 60, Experiencia = 25 });
        lista.Add(new Guerrero("Hilda Valquiria", 72.0) { Nivel = 78, Energia = 85, Experiencia = 35 });
        lista.Add(new Guerrero("Ivar Deshuesado", 55.0) { Nivel = 48, Energia = 92, Experiencia = 20 });
        lista.Add(new Guerrero("Jora la Tenaz", 40.0) { Nivel = 22, Energia = 85, Experiencia = 8 });
        lista.Add(new Guerrero("Kaelen de Astora", 90.0) { Nivel = 99, Energia = 50, Experiencia = 55 });
        lista.Add(new Guerrero("Leif el Rojo", 48.0) { Nivel = 35, Energia = 75, Experiencia = 12 });
        lista.Add(new Guerrero("Morgra la Fiera", 65.0) { Nivel = 61, Energia = 80, Experiencia = 28 });
        lista.Add(new Guerrero("Niles el Escudo", 42.0) { Nivel = 29, Energia = 90, Experiencia = 11 });
        lista.Add(new Guerrero("Orik el Martillo", 62.0) { Nivel = 50, Energia = 70, Experiencia = 24 });

        // --- MAGOS (15) ---
        lista.Add(new Mago("Archimago Valerius", 95.0) { Nivel = 98, Energia = 40, Experiencia = 60 });
        lista.Add(new Mago("Belladona Oscura", 78.0) { Nivel = 72, Energia = 80, Experiencia = 35 });
        lista.Add(new Mago("Cyrus el Igneo", 66.0) { Nivel = 55, Energia = 65, Experiencia = 25 });
        lista.Add(new Mago("Dorian el Sabio", 50.0) { Nivel = 33, Energia = 90, Experiencia = 15 });
        lista.Add(new Mago("Elora del Viento", 58.0) { Nivel = 45, Energia = 85, Experiencia = 20 });
        lista.Add(new Mago("Fausto el Gris", 85.0) { Nivel = 88, Energia = 55, Experiencia = 45 });
        lista.Add(new Mago("Gideon el Runico", 42.0) { Nivel = 21, Energia = 95, Experiencia = 10 });
        lista.Add(new Mago("Hecate la Bruja", 70.0) { Nivel = 67, Energia = 70, Experiencia = 30 });
        lista.Add(new Mago("Ignis Malcor", 62.0) { Nivel = 50, Energia = 60, Experiencia = 22 });
        lista.Add(new Mago("Jaina la Celeste", 75.0) { Nivel = 77, Energia = 75, Experiencia = 38 });
        lista.Add(new Mago("Kasper el Mudo", 55.0) { Nivel = 39, Energia = 99, Experiencia = 18 });
        lista.Add(new Mago("Luna de Plata", 35.0) { Nivel = 15, Energia = 90, Experiencia = 5 });
        lista.Add(new Mago("Morgana Le Fay", 88.0) { Nivel = 92, Energia = 50, Experiencia = 55 });
        // Usamos nombres sin acentos para evitar problemas de encoding en consola
        lista.Add(new Mago("Nyx la Sombria", 64.0) { Nivel = 58, Energia = 82, Experiencia = 26 });
        lista.Add(new Mago("Ozarus el Viejo", 82.0) { Nivel = 80, Energia = 35, Experiencia = 42 });

        // --- ARQUEROS (15) ---
        lista.Add(new Arquero("Artemis Sombra", 80.0) { Nivel = 90, Energia = 85, Experiencia = 45 });
        lista.Add(new Arquero("Bran el Halcon", 58.0) { Nivel = 44, Energia = 92, Experiencia = 20 });
        lista.Add(new Arquero("Calypsa la Veloz", 72.0) { Nivel = 68, Energia = 98, Experiencia = 30 });
        lista.Add(new Arquero("Dante Ojo Aguila", 60.0) { Nivel = 52, Energia = 80, Experiencia = 25 });
        lista.Add(new Arquero("Eryas el Palido", 45.0) { Nivel = 27, Energia = 85, Experiencia = 12 });
        lista.Add(new Arquero("Finn el Cazador", 38.0) { Nivel = 19, Energia = 95, Experiencia = 8 });
        lista.Add(new Arquero("Gala de Bosques", 74.0) { Nivel = 75, Energia = 70, Experiencia = 35 });
        lista.Add(new Arquero("Halcon Nocturno", 78.0) { Nivel = 82, Energia = 75, Experiencia = 40 });
        lista.Add(new Arquero("Iria Rastreadora", 52.0) { Nivel = 36, Energia = 90, Experiencia = 15 });
        lista.Add(new Arquero("Jarek el Certero", 64.0) { Nivel = 59, Energia = 65, Experiencia = 28 });
        lista.Add(new Arquero("Kira Silenciosa", 56.0) { Nivel = 48, Energia = 99, Experiencia = 22 });
        lista.Add(new Arquero("Lorne el Errante", 48.0) { Nivel = 31, Energia = 82, Experiencia = 14 });
        lista.Add(new Arquero("Mika la Agil", 32.0) { Nivel = 15, Energia = 95, Experiencia = 6 });
        lista.Add(new Arquero("Nylo Ballestero", 68.0) { Nivel = 63, Energia = 70, Experiencia = 32 });
        lista.Add(new Arquero("Orion el Estelar", 92.0) { Nivel = 99, Energia = 60, Experiencia = 55 });

        return lista;
    }
}