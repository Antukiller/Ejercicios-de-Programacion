using Horizon_Forbidden_West.Collections;
using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Models;

namespace Horizon_Forbidden_West.Factory;

public static class MaquinaFactory {
    public static ILista<Maquina> Seed() {
        var lista = new Lista<Maquina>();
        
        lista.AddLast(new Maquina { Nombre = "Vigía", Peligrosidad = NivelAmenaza.Minima, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Atronador", Peligrosidad = NivelAmenaza.Extrema, EsSaboteabale = false });
        lista.AddLast(new Maquina { Nombre = "Tronador", Peligrosidad = NivelAmenaza.Extrema, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Cuellilargo", Peligrosidad = NivelAmenaza.Moderada, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Recolector", Peligrosidad = NivelAmenaza.Minima, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Acechador", Peligrosidad = NivelAmenaza.Elevada, EsSaboteabale = false });
        lista.AddLast(new Maquina { Nombre = "Bégimo", Peligrosidad = NivelAmenaza.Elevada, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Rapaz", Peligrosidad = NivelAmenaza.Moderada, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Alasol", Peligrosidad = NivelAmenaza.Moderada, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Topotopo", Peligrosidad = NivelAmenaza.Elevada, EsSaboteabale = false });
        lista.AddLast(new Maquina { Nombre = "Garrirraptor", Peligrosidad = NivelAmenaza.Elevada, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Encorvado", Peligrosidad = NivelAmenaza.Moderada, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Demoledor", Peligrosidad = NivelAmenaza.Elevada, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Incendiario", Peligrosidad = NivelAmenaza.Elevada, EsSaboteabale = false });
        lista.AddLast(new Maquina { Nombre = "Garrahelada", Peligrosidad = NivelAmenaza.Extrema, EsSaboteabale = false });
        lista.AddLast(new Maquina { Nombre = "Garrardiente", Peligrosidad = NivelAmenaza.Extrema, EsSaboteabale = false });
        lista.AddLast(new Maquina { Nombre = "Reptiviento", Peligrosidad = NivelAmenaza.Extrema, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Alasangre", Peligrosidad = NivelAmenaza.Elevada, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Rodador", Peligrosidad = NivelAmenaza.Moderada, EsSaboteabale = true });
        lista.AddLast(new Maquina { Nombre = "Pastador", Peligrosidad = NivelAmenaza.Minima, EsSaboteabale = true });
        
        return lista;
    }
}