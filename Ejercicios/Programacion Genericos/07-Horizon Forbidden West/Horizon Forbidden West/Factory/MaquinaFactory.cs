using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Models;

namespace Horizon_Forbidden_West.Factory;

public static class MaquinaFactory {
    public static List<Maquina> GenerarSemilla() => new() {
        new() { Nombre = "Vigía", CodigoGaia = "MAQ-0001-R", Descripcion = "Centinela pequeño", Tipo = TipoMaquina.Reconocimiento, Peligrosidad = NivelAmenaza.Minima, DebilidadElemental = Elementos.Fuego, EsSaboteabale = true },
        new() { Nombre = "Cuellilargo", CodigoGaia = "MAQ-0002-R", Descripcion = "Torre de comunicaciones", Tipo = TipoMaquina.Reconocimiento, Peligrosidad = NivelAmenaza.Elevada, DebilidadElemental = Elementos.Electricidad, EsSaboteabale = true },
        new() { Nombre = "Tronador", CodigoGaia = "MAQ-0003-L", Descripcion = "Depredador alfa", Tipo = TipoMaquina.Lidia, Peligrosidad = NivelAmenaza.Extrema, DebilidadElemental = Elementos.Acido, EsSaboteabale = false },
        new() { Nombre = "Garraigante", CodigoGaia = "MAQ-0004-L", Descripcion = "Oso de combate ígneo", Tipo = TipoMaquina.Lidia, Peligrosidad = NivelAmenaza.Elevada, DebilidadElemental = Elementos.Fuego, EsSaboteabale = true },
        new() { Nombre = "Alasol", CodigoGaia = "MAQ-0005-G", Descripcion = "Máquina voladora solar", Tipo = TipoMaquina.Reguladora, Peligrosidad = NivelAmenaza.Moderada, DebilidadElemental = Elementos.Plasma, EsSaboteabale = true },
        new() { Nombre = "Atronador", CodigoGaia = "MAQ-0006-L", Descripcion = "Coloso mecánico pesado", Tipo = TipoMaquina.Lidia, Peligrosidad = NivelAmenaza.Extrema, DebilidadElemental = Elementos.Hielo, EsSaboteabale = false },
        new() { Nombre = "Ensanchador", CodigoGaia = "MAQ-0007-T", Descripcion = "Transporte de fluidos", Tipo = TipoMaquina.Transporte, Peligrosidad = NivelAmenaza.Moderada, DebilidadElemental = Elementos.AguaPurga, EsSaboteabale = true },
        new() { Nombre = "Acechador", CodigoGaia = "MAQ-0008-L", Descripcion = "Depredador invisible", Tipo = TipoMaquina.Lidia, Peligrosidad = NivelAmenaza.Elevada, DebilidadElemental = Elementos.Electricidad, EsSaboteabale = true },
        new() { Nombre = "Reptivoladora", CodigoGaia = "MAQ-0009-L", Descripcion = "Serpiente de plasma", Tipo = TipoMaquina.Lidia, Peligrosidad = NivelAmenaza.Extrema, DebilidadElemental = Elementos.Plasma, EsSaboteabale = false },
        new() { Nombre = "Topoyuna", CodigoGaia = "MAQ-0010-G", Descripcion = "Minero subterráneo", Tipo = TipoMaquina.Reguladora, Peligrosidad = NivelAmenaza.Elevada, DebilidadElemental = Elementos.Acido, EsSaboteabale = true },
        new() { Nombre = "Recolector", CodigoGaia = "MAQ-0011-T", Descripcion = "Procesador de recursos", Tipo = TipoMaquina.Transporte, Peligrosidad = NivelAmenaza.Moderada, DebilidadElemental = Elementos.Hielo, EsSaboteabale = true },
        new() { Nombre = "Demoledor", CodigoGaia = "MAQ-0012-L", Descripcion = "Furia acorazada", Tipo = TipoMaquina.Lidia, Peligrosidad = NivelAmenaza.Moderada, DebilidadElemental = Elementos.Fuego, EsSaboteabale = true },
        new() { Nombre = "Garriraptor", CodigoGaia = "MAQ-0013-L", Descripcion = "Cazador veloz", Tipo = TipoMaquina.Lidia, Peligrosidad = NivelAmenaza.Moderada, DebilidadElemental = Elementos.Electricidad, EsSaboteabale = true },
        new() { Nombre = "Sombra", CodigoGaia = "MAQ-0014-R", Descripcion = "Ojo en el cielo", Tipo = TipoMaquina.Reconocimiento, Peligrosidad = NivelAmenaza.Moderada, DebilidadElemental = Elementos.Hielo, EsSaboteabale = true },
        new() { Nombre = "Rodador", CodigoGaia = "MAQ-0015-G", Descripcion = "Limpiador de terrenos", Tipo = TipoMaquina.Reguladora, Peligrosidad = NivelAmenaza.Moderada, DebilidadElemental = Elementos.Hielo, EsSaboteabale = true },
        new() { Nombre = "Terremamut", CodigoGaia = "MAQ-0016-L", Descripcion = "Fortaleza andante", Tipo = TipoMaquina.Lidia, Peligrosidad = NivelAmenaza.Extrema, DebilidadElemental = Elementos.Electricidad, EsSaboteabale = false },
        new() { Nombre = "Caminante", CodigoGaia = "MAQ-0017-T", Descripcion = "Bestia de carga", Tipo = TipoMaquina.Transporte, Peligrosidad = NivelAmenaza.Minima, DebilidadElemental = Elementos.Fuego, EsSaboteabale = true },
        new() { Nombre = "Destripador", CodigoGaia = "MAQ-0018-L", Descripcion = "Terror submarino", Tipo = TipoMaquina.Lidia, Peligrosidad = NivelAmenaza.Extrema, DebilidadElemental = Elementos.AguaPurga, EsSaboteabale = false },
        new() { Nombre = "Cangrejo", CodigoGaia = "MAQ-0019-T", Descripcion = "Defensor de convoy", Tipo = TipoMaquina.Transporte, Peligrosidad = NivelAmenaza.Moderada, DebilidadElemental = Elementos.Acido, EsSaboteabale = true },
        new() { Nombre = "Pinchador", CodigoGaia = "MAQ-0020-R", Descripcion = "Explorador ágil", Tipo = TipoMaquina.Reconocimiento, Peligrosidad = NivelAmenaza.Minima, DebilidadElemental = Elementos.Fuego, EsSaboteabale = true }
    };
}