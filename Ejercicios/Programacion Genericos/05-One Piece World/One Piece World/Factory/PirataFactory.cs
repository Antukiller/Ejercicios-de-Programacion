using One_Piece_World.Enum;
using Serilog;

namespace One_Piece_World.Factory;

public static class PirataFactory {
    private static readonly ILogger _log = Log.ForContext(typeof(PirataFactory));
    public static Pirata[] DemoData() {
        _log.Information("Inicializando datos de prueba para Piratas...");
        var listaPiratas = new Pirata[10];
        
        var a1 = new Pirata 
            { Id = 1, NombreCompleto = "Monkey D. Luffy", Apodo = "Sombrero de Paja", Recompensa = 1500000000, Tripulacion = "Mugiwaras", Posicion = PosicionPirata.Capitan };
        var a2 = new Pirata 
            { Id = 2, NombreCompleto = "Roronoa Zoro", Apodo = "Cazador de Piratas", Recompensa = 1100011000, Tripulacion = "Mugiwaras", Posicion = PosicionPirata.ViceCapitán };
        var a3 = new Pirata 
            { Id = 3, NombreCompleto = "Sanji", Apodo = "Pierna Negra", Recompensa = 1032000000, Tripulacion = "Mugiwaras", Posicion = PosicionPirata.Cocinero };
        var a4 = new Pirata 
            { Id = 4, NombreCompleto = "Nami", Apodo = "Gata Ladrona", Recompensa = 366000000, Tripulacion = "Mugiwaras", Posicion = PosicionPirata.Navegante };
        var a5 = new Pirata 
            { Id = 5, NombreCompleto = "Trafalgar Law", Apodo = "Cirujano de la Muerte", Recompensa = 500000000, Tripulacion = "Piratas de Heart", Posicion = PosicionPirata.Capitan };
        var a6 = new Pirata 
            { Id = 6, NombreCompleto = "Eustass Kid", Apodo = "Captain Kid", Recompensa = 470000000, Tripulacion = "Piratas de Kid", Posicion = PosicionPirata.Capitan };
        var a7 = new Pirata 
            { Id = 7, NombreCompleto = "Nico Robin", Apodo = "Niña Demonio", Recompensa = 930000000, Tripulacion = "Mugiwaras", Posicion = PosicionPirata.Arqueologo };
        var a8 = new Pirata 
            { Id = 8, NombreCompleto = "Jinbe", Apodo = "El Caballero del Mar", Recompensa = 1100000000, Tripulacion = "Mugiwaras", Posicion = PosicionPirata.Timonel };
        var a9 = new Pirata 
            { Id = 9, NombreCompleto = "Brook", Apodo = "Soul King", Recompensa = 383000000, Tripulacion = "Mugiwaras", Posicion = PosicionPirata.Musico };
        var a10 = new Pirata
            { Id = 10, NombreCompleto = "Usopp", Apodo = "God Usopp", Recompensa = 500000000, Tripulacion = "Mugiwaras", Posicion = PosicionPirata.Francotirador };
        
        listaPiratas[0] = a1;
        listaPiratas[1] = a2;
        listaPiratas[2] = a3;
        listaPiratas[3] = a4;
        listaPiratas[4] = a5;
        listaPiratas[5] = a6;
        listaPiratas[6] = a7;
        listaPiratas[7] = a8;
        listaPiratas[8] = a9;
        listaPiratas[9] = a10;
        
        return listaPiratas;
    }
}