using One_Piece_World.Enum;
using Serilog;

namespace One_Piece_World.Factory;

public static class MarineFactory {
    private static readonly ILogger _log = Log.ForContext(typeof(MarineFactory));

    public static Marine[] DemoData() {
        _log.Information("Inicializando datos de prueba para Marines...");
        var listaMarines = new Marine[10];
        
        var m1 = new Marine 
            { Id = 1, NombreCompleto = "Sakazuki", Apodo = "Akainu", Rango = RangoMarine.AlmiranteDeFlota, BaseAsignada = "New Marineford" };
        var m2 = new Marine 
            { Id = 2, NombreCompleto = "Borsalino", Apodo = "Kizaru", Rango = RangoMarine.Almirante, BaseAsignada = "Sabaody" };
        var m3 = new Marine 
            { Id = 3, NombreCompleto = "Issho", Apodo = "Fujitora", Rango = RangoMarine.Almirante, BaseAsignada = "Dressrosa" };
        var m4 = new Marine 
            { Id = 4, NombreCompleto = "Kuzan", Apodo = "Aokiji", Rango = RangoMarine.Almirante, BaseAsignada = "Punk Hazard" };
        var m5 = new Marine 
            { Id = 5, NombreCompleto = "Monkey D. Garp", Apodo = "El Héroe", Rango = RangoMarine.ViceAlmirante, BaseAsignada = "Marineford" };
        var m6 = new Marine 
            { Id = 6, NombreCompleto = "Smoker", Apodo = "El Malhumorado", Rango = RangoMarine.ViceAlmirante, BaseAsignada = "G-5" };
        var m7 = new Marine 
            { Id = 7, NombreCompleto = "Tashigi", Apodo = "Coleccionista de Katanas", Rango = RangoMarine.Capitan, BaseAsignada = "G-5" };
        var m8 = new Marine 
            { Id = 8, NombreCompleto = "Koby", Apodo = "Héroe de Rocky Port", Rango = RangoMarine.Capitan, BaseAsignada = "SWORD" };
        var m9 = new Marine 
            { Id = 9, NombreCompleto = "Hina", Apodo = "La Jaula Negra", Rango = RangoMarine.ContraAlmirante, BaseAsignada = "Marineford" };
        var m10 = new Marine 
            { Id = 10, NombreCompleto = "Tsuru", Apodo = "La Gran Estratega", Rango = RangoMarine.ViceAlmirante, BaseAsignada = "Marineford" };

        listaMarines[0] = m1;
        listaMarines[1] = m2;
        listaMarines[2] = m3;
        listaMarines[3] = m4;
        listaMarines[4] = m5;
        listaMarines[5] = m6;
        listaMarines[6] = m7;
        listaMarines[7] = m8;
        listaMarines[8] = m9;
        listaMarines[9] = m10;

        return listaMarines;
    }
}