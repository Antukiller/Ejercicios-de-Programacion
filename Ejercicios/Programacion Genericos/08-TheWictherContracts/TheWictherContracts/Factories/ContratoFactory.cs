using TheWictherContracts.Enums;
using TheWictherContracts.Models;

public static class ContratosFactory {
    public static IEnumerable<ContratoBase> Seed() {
        var lista = new List<ContratoBase>();

        // --- 20 CONTRATOS DE MONSTRUOS (Cacerías de Bestias y Seres Sobrenaturales) ---
        lista.Add(new ContratoMonstruo(1, "El Diablo del Pozo", 2, 50.0, EspecieCriatura.Espectro));
        lista.Add(new ContratoMonstruo(2, "Grito de la Arpía", 10, 250.0, EspecieCriatura.Híbrido));
        lista.Add(new ContratoMonstruo(3, "La Dama Blanca", 15, 400.0, EspecieCriatura.Espectro));
        lista.Add(new ContratoMonstruo(4, "Muertovivo en las alcantarillas", 8, 150.0, EspecieCriatura.Necrofago));
        lista.Add(new ContratoMonstruo(5, "El rastro del Wyvern", 25, 800.0, EspecieCriatura.Draconico));
        lista.Add(new ContratoMonstruo(6, "Nido de Sumergidos en el Delta", 5, 120.0, EspecieCriatura.Necrofago));
        lista.Add(new ContratoMonstruo(7, "El Terror de la Cueva Susurrante", 18, 450.0, EspecieCriatura.Relicto));
        lista.Add(new ContratoMonstruo(8, "La Bestia de Oxenfurt", 30, 1100.0, EspecieCriatura.Draconico));
        lista.Add(new ContratoMonstruo(9, "El espíritu del bosque", 35, 1500.0, EspecieCriatura.Relicto));
        lista.Add(new ContratoMonstruo(10, "Sangre en los muelles", 28, 950.0, EspecieCriatura.Vampiro));
        lista.Add(new ContratoMonstruo(11, "El Ogro del Paso de Montaña", 22, 600.0, EspecieCriatura.Ogroido));
        lista.Add(new ContratoMonstruo(12, "Problemas de Insectoides en el huerto", 6, 180.0, EspecieCriatura.Insectoide));
        lista.Add(new ContratoMonstruo(13, "El Golem de la Torre Abandonada", 32, 1200.0, EspecieCriatura.Elementoide));
        lista.Add(new ContratoMonstruo(14, "La Maldición del Hombre Lobo", 16, 500.0, EspecieCriatura.Maldito));
        lista.Add(new ContratoMonstruo(15, "Lobos rabiosos en el bosque", 3, 40.0, EspecieCriatura.Animales));
        lista.Add(new ContratoMonstruo(16, "El Cyclope del Valle Olvidado", 38, 1800.0, EspecieCriatura.Ogroido));
        lista.Add(new ContratoMonstruo(17, "Un Ekimmara en el sótano", 24, 750.0, EspecieCriatura.Vampiro));
        lista.Add(new ContratoMonstruo(18, "Gárgolas en las Ruinas Élficas", 26, 850.0, EspecieCriatura.Elementoide));
        lista.Add(new ContratoMonstruo(19, "El Acechador de las Nieblas", 20, 550.0, EspecieCriatura.Necrofago));
        lista.Add(new ContratoMonstruo(20, "Ululante de las Cumbres", 14, 300.0, EspecieCriatura.Híbrido));

        // --- 20 CONTRATOS DE ASALTO (Operaciones contra Humanos y Fortalezas) ---
        // (id, titulo, nivel, recompensa, numeroEnemigos, requiereSigilo)
        lista.Add(new ContratoAsalto(21, "Desahucio de Bandidos", 5, 300.0, 5, false));
        lista.Add(new ContratoAsalto(22, "Infiltración en el Fuerte Blanco", 20, 1200.0, 12, true));
        lista.Add(new ContratoAsalto(23, "Sabotaje de Suministros Redanianos", 12, 600.0, 4, true));
        lista.Add(new ContratoAsalto(24, "Limpieza de Desertores", 15, 500.0, 15, false));
        lista.Add(new ContratoAsalto(25, "Asalto a la Prisión de Oxenfurt", 45, 3000.0, 25, true));
        lista.Add(new ContratoAsalto(26, "El Campamento de la Rosa Blanca", 18, 700.0, 10, false));
        lista.Add(new ContratoAsalto(27, "Recuperación de la Escuela de la Grulla", 35, 2000.0, 14, true));
        lista.Add(new ContratoAsalto(28, "Emboscada al Convoy Negro", 22, 900.0, 20, false));
        lista.Add(new ContratoAsalto(29, "Silenciar al Espía en Wyzima", 28, 1100.0, 3, true));
        lista.Add(new ContratoAsalto(30, "Ataque al Nido de Cuervos", 30, 1400.0, 18, false));
        lista.Add(new ContratoAsalto(31, "Rescate de Rehenes en el Molino", 7, 350.0, 6, true));
        lista.Add(new ContratoAsalto(32, "Saqueo de la Armería Imperial", 40, 2500.0, 22, true));
        lista.Add(new ContratoAsalto(33, "Defensa de la Aldea de Brevo", 14, 450.0, 12, false));
        lista.Add(new ContratoAsalto(34, "El Tesoro del Capitán Pirata", 25, 1000.0, 15, false));
        lista.Add(new ContratoAsalto(35, "Infiltración en la Logia", 42, 2800.0, 5, true));
        lista.Add(new ContratoAsalto(36, "Venganza de los Non-Humanos", 16, 550.0, 10, false));
        lista.Add(new ContratoAsalto(37, "Sabotaje de los Barcos Nilfgaardianos", 33, 1600.0, 8, true));
        lista.Add(new ContratoAsalto(38, "Asalto a la Fortaleza de Kaer Almhult", 38, 2200.0, 30, false));
        lista.Add(new ContratoAsalto(39, "Escoltar al Carromato de Alquimia", 10, 400.0, 8, false));
        lista.Add(new ContratoAsalto(40, "Duelo de Honor en el Torneo", 20, 1500.0, 1, false));

        return lista;
    }
}