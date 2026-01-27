using One_Piece_World.Enum;
using Serilog;

namespace One_Piece_World.Factory;

public static class FrutaDelDiabloFactory {
    private static readonly ILogger _log = Log.ForContext(typeof(FrutaDelDiabloFactory));

    public static FrutaDelDiablo[] DemoData() {
        _log.Information("Inicializando datos de prueba para Frutas del Diablo...");
        var listaFrutas = new FrutaDelDiablo[10];

        var f1 = new FrutaDelDiablo 
            { Id = 1, NombreCompleto = "Gomu Gomu no Mi", Apodo = "Hito Hito: Nika", Fruta = TipoFruta.ZoanMitologica, IsDespertada = true };
        var f2 = new FrutaDelDiablo 
            { Id = 2, NombreCompleto = "Mera Mera no Mi", Apodo = "Fruta Fuego", Fruta = TipoFruta.Logia, IsDespertada = false };
        var f3 = new FrutaDelDiablo 
            { Id = 3, NombreCompleto = "Ope Ope no Mi", Apodo = "Cirugía Eterna", Fruta = TipoFruta.Paramecia, IsDespertada = true };
        var f4 = new FrutaDelDiablo 
            { Id = 4, NombreCompleto = "Yami Yami no Mi", Apodo = "Fruta Oscuridad", Fruta = TipoFruta.Logia, IsDespertada = false };
        var f5 = new FrutaDelDiablo 
            { Id = 5, NombreCompleto = "Tori Tori no Mi", Apodo = "Modelo Fénix", Fruta = TipoFruta.ZoanMitologica, IsDespertada = true };
        var f6 = new FrutaDelDiablo 
            { Id = 6, NombreCompleto = "Gura Gura no Mi", Apodo = "Fruta Terremoto", Fruta = TipoFruta.Paramecia, IsDespertada = false };
        var f7 = new FrutaDelDiablo 
            { Id = 7, NombreCompleto = "Hana Hana no Mi", Apodo = "Fruta Flor", Fruta = TipoFruta.Paramecia, IsDespertada = false };
        var f8 = new FrutaDelDiablo 
            { Id = 8, NombreCompleto = "Pika Pika no Mi", Apodo = "Fruta Luz", Fruta = TipoFruta.Logia, IsDespertada = false };
        var f9 = new FrutaDelDiablo 
            { Id = 9, NombreCompleto = "Mochi Mochi no Mi", Apodo = "Paramecia Especial", Fruta = TipoFruta.Paramecia, IsDespertada = true };
        var f10 = new FrutaDelDiablo 
            { Id = 10, NombreCompleto = "Uo Uo no Mi", Apodo = "Modelo Seiryu", Fruta = TipoFruta.ZoanMitologica, IsDespertada = true };

        listaFrutas[0] = f1;
        listaFrutas[1] = f2;
        listaFrutas[2] = f3;
        listaFrutas[3] = f4;
        listaFrutas[4] = f5;
        listaFrutas[5] = f6;
        listaFrutas[6] = f7;
        listaFrutas[7] = f8;
        listaFrutas[8] = f9;
        listaFrutas[9] = f10;

        return listaFrutas;
    }
}