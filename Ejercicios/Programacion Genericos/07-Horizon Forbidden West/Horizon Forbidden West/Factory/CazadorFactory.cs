using Horizon_Forbidden_West.Enums;
using Horizon_Forbidden_West.Models;

namespace Horizon_Forbidden_West.Factory;

public static class CazadorFactory {
    public static List<Cazador> GenerarSemilla() => new() {
        new() { Nombre = "Aloy", CodigoGaia = "CZR-0001-N", Descripcion = "Buscadora Nora", Tribu = TipoTribu.Nora, Rango = RangoCazador.Buscadora, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.AnalisisDeMaquinas },
        new() { Nombre = "Erend", CodigoGaia = "CZR-0002-O", Descripcion = "Capitán Vanguardia", Tribu = TipoTribu.Oseram, Rango = RangoCazador.Vanguardia, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.BalisticaDeFelchas },
        new() { Nombre = "Varl", CodigoGaia = "CZR-0003-N", Descripcion = "Guerrero Leal", Tribu = TipoTribu.Nora, Rango = RangoCazador.Buscadora, Entrenamiento = CicloEntrenamiento.Iniciado, Especialidad = Especializacion.SigiloYSupervivencias },
        new() { Nombre = "Kotallo", CodigoGaia = "CZR-0004-T", Descripcion = "Mariscal Tenakth", Tribu = TipoTribu.Tenakth, Rango = RangoCazador.Mariscal, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.BalisticaDeFelchas },
        new() { Nombre = "Zo", CodigoGaia = "CZR-0005-U", Descripcion = "Cantora Utaru", Tribu = TipoTribu.Utaru, Rango = RangoCazador.Buscadora, Entrenamiento = CicloEntrenamiento.Iniciado, Especialidad = Especializacion.IngenieriaDeCalderos },
        new() { Nombre = "Talanah", CodigoGaia = "CZR-0006-C", Descripcion = "Halcón Solar", Tribu = TipoTribu.Banuk, Rango = RangoCazador.Mariscal, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.AnalisisDeMaquinas },
        new() { Nombre = "Hekarro", CodigoGaia = "CZR-0007-T", Descripcion = "Gran Jefe", Tribu = TipoTribu.Tenakth, Rango = RangoCazador.Mariscal, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.ProtocolosDeGaia },
        new() { Nombre = "Sona", CodigoGaia = "CZR-0008-N", Descripcion = "Caudilla Nora", Tribu = TipoTribu.Nora, Rango = RangoCazador.Vanguardia, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.SigiloYSupervivencias },
        new() { Nombre = "Petra", CodigoGaia = "CZR-0009-O", Descripcion = "Forjadora Libre", Tribu = TipoTribu.Oseram, Rango = RangoCazador.Iniciado, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.BalisticaDeFelchas },
        new() { Nombre = "Dekka", CodigoGaia = "CZR-0010-T", Descripcion = "Capellana Tierras Bajas", Tribu = TipoTribu.Tenakth, Rango = RangoCazador.Mariscal, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.ProtocolosDeGaia },
        new() { Nombre = "Avad", CodigoGaia = "CZR-0011-C", Descripcion = "Rey Sol Carja", Tribu = TipoTribu.Banuk, Rango = RangoCazador.Mariscal, Entrenamiento = CicloEntrenamiento.Iniciado, Especialidad = Especializacion.ProtocolosDeGaia },
        new() { Nombre = "Aratak", CodigoGaia = "CZR-0012-B", Descripcion = "Caudillo Banuk", Tribu = TipoTribu.Banuk, Rango = RangoCazador.Vanguardia, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.SigiloYSupervivencias },
        new() { Nombre = "Ourea", CodigoGaia = "CZR-0013-B", Descripcion = "Chamán del Tajo", Tribu = TipoTribu.Banuk, Rango = RangoCazador.Buscadora, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.IngenieriaDeCalderos },
        new() { Nombre = "Drakka", CodigoGaia = "CZR-0014-T", Descripcion = "Líder del Desierto", Tribu = TipoTribu.Tenakth, Rango = RangoCazador.Iniciado, Entrenamiento = CicloEntrenamiento.Iniciado, Especialidad = Especializacion.BalisticaDeFelchas },
        new() { Nombre = "Yarra", CodigoGaia = "CZR-0015-T", Descripcion = "Comandante Desertora", Tribu = TipoTribu.Tenakth, Rango = RangoCazador.Mariscal, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.SigiloYSupervivencias },
        new() { Nombre = "Fashav", CodigoGaia = "CZR-0016-T", Descripcion = "Mediador entre culturas", Tribu = TipoTribu.Tenakth, Rango = RangoCazador.Mariscal, Entrenamiento = CicloEntrenamiento.Iniciado, Especialidad = Especializacion.ProtocolosDeGaia },
        new() { Nombre = "Kue", CodigoGaia = "CZR-0017-U", Descripcion = "Defensor Cantollano", Tribu = TipoTribu.Utaru, Rango = RangoCazador.Iniciado, Entrenamiento = CicloEntrenamiento.Iniciado, Especialidad = Especializacion.AnalisisDeMaquinas },
        new() { Nombre = "Vala", CodigoGaia = "CZR-0018-N", Descripcion = "Aspirante a Valiente", Tribu = TipoTribu.Nora, Rango = RangoCazador.Iniciado, Entrenamiento = CicloEntrenamiento.Iniciado, Especialidad = Especializacion.BalisticaDeFelchas },
        new() { Nombre = "Bahl", CodigoGaia = "CZR-0019-O", Descripcion = "Artillero de Élite", Tribu = TipoTribu.Oseram, Rango = RangoCazador.Vanguardia, Entrenamiento = CicloEntrenamiento.Iniciado, Especialidad = Especializacion.BalisticaDeFelchas },
        new() { Nombre = "Nil", CodigoGaia = "CZR-0020-C", Descripcion = "Cazador Sombrío", Tribu = TipoTribu.Banuk, Rango = RangoCazador.Vanguardia, Entrenamiento = CicloEntrenamiento.Veterano, Especialidad = Especializacion.SigiloYSupervivencias }
    };
}